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
            if (!string.IsNullOrEmpty(nomUtilisateur) && !string.IsNullOrEmpty(motDePasse))
            {
                // Crée un objet utilisateur avec les données saisies
                Utilisateur infoUser = new Utilisateur(1, nomUtilisateur, motDePasse, 1);

                // Appel au contrôleur pour récupérer les informations utilisateur
                List<Utilisateur> utilisateurs = controller.GetUserInfo(infoUser);

                // Vérifie si un utilisateur correspond au nom fourni
                Utilisateur utilisateurTrouve = utilisateurs.FirstOrDefault(u =>
                    u.Nom == nomUtilisateur);

                if (utilisateurTrouve != null)
                {
                    // Vérifie le mot de passe hashé
                    if (BCrypt.Net.BCrypt.Verify(motDePasse, utilisateurTrouve.MotDePasse))
                    {
                        // Authentification réussie
                        FrmMediatek accueilForm = new FrmMediatek();

                        if (utilisateurTrouve.IdService == 3) // Service "Culture"
                        {
                            MessageBox.Show("Vous n'avez pas les droits suffisants pour accéder à cette application.",
                                            "Accès refusé",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            Application.Exit(); // Ferme l'application si accès non autorisé
                        }
                        else if (utilisateurTrouve.IdService == 2) // Service "Prêts"
                        {
                            accueilForm.CacherOnglet();
                        }
                        else
                        {
                            accueilForm.AfficherAbonnementsFinDans30Jours();

                        }

                        accueilForm.Owner = this;
                        this.Visible = false;
                        accueilForm.Show();
                    }
                    else
                    {
                        // Mot de passe incorrect
                        MessageBox.Show("Mot de passe incorrect.",
                                        "Erreur d'authentification",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nom d'utilisateur non trouvé
                    MessageBox.Show("Nom d'utilisateur incorrect.",
                                    "Erreur d'authentification",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.",
                                "Erreur de saisie",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
