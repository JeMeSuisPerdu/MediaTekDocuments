using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BCrypt.Net; // Namespace pour bcrypt
using MediaTekDocuments.controller;
using MediaTekDocuments.model;


namespace MediaTekDocuments.view
{
    public partial class AuthForm : Form
    {
        private readonly FrmMediatekController controller;

        public AuthForm()
        {
            InitializeComponent();
            // Initialisation du contrôleur
            controller = new FrmMediatekController();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string nomUtilisateur = txbIdentifiantUser.Text;
            string motDePasse = txbMotDePasseUser.Text;

            // Vérifie si les champs ne sont pas vides
            if (AreFieldsValid(nomUtilisateur, motDePasse))
            {
                Utilisateur utilisateurTrouve = GetUserInfo(nomUtilisateur);

                if (utilisateurTrouve != null && IsPasswordValid(motDePasse, utilisateurTrouve))
                {
                    HandleSuccessfulLogin(utilisateurTrouve);
                }
                else
                {
                    ShowErrorMessage("Nom d'utilisateur incorrect ou mot de passe incorrect.",
                                      "Erreur d'authentification");
                }
            }
            else
            {
                ShowErrorMessage("Veuillez remplir tous les champs.", "Erreur de saisie", MessageBoxIcon.Warning);
            }
        }

        private bool AreFieldsValid(string nomUtilisateur, string motDePasse)
        {
            return !string.IsNullOrEmpty(nomUtilisateur) && !string.IsNullOrEmpty(motDePasse);
        }

        private Utilisateur GetUserInfo(string nomUtilisateur)
        {
            Utilisateur infoUser = new Utilisateur(1, nomUtilisateur, string.Empty, 1);
            List<Utilisateur> utilisateurs = controller.GetUserInfo(infoUser);
            return utilisateurs.Find(u => u.Nom == nomUtilisateur);
        }


        private bool IsPasswordValid(string motDePasse, Utilisateur utilisateur)
        {
            return BCrypt.Net.BCrypt.Verify(motDePasse, utilisateur.MotDePasse);
        }

        private void HandleSuccessfulLogin(Utilisateur utilisateurTrouve)
        {
            FrmMediatek accueilForm = new FrmMediatek();

            if (utilisateurTrouve.IdService == 3) // Service "Culture"
            {
                MessageBox.Show("Vous n'avez pas les droits suffisants pour accéder à cette application.",
                                "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Ferme l'application si accès non autorisé
            }
            else
            {
                ConfigureAccueilForm(utilisateurTrouve, accueilForm);
            }

            accueilForm.Owner = this;
            this.Visible = false;
            accueilForm.Show();
        }

        private void ConfigureAccueilForm(Utilisateur utilisateur, FrmMediatek accueilForm)
        {
            if (utilisateur.IdService == 2) // Service "Prêts"
            {
                accueilForm.CacherOnglet();
            }
            else
            {
                accueilForm.AfficherAbonnementsFinDans30Jours();
            }
        }
        private void ShowErrorMessage(string message, string caption, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }
    }
}
