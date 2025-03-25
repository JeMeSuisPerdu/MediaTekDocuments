# MediatekDocuments README Compl�mentaire
Cette application permet de g�rer les documents (livres, DVD, revues) d'une m�diath�que. Elle a �t� cod�e en C# sous Visual Studio 2019. C'est une application de bureau, pr�vue d'�tre install�e sur plusieurs postes acc�dant � la m�me base de donn�es.<br>
L'application exploite une API REST pour acc�der � la BDD MySQL. Des explications sont donn�es plus loin, ainsi que le lien de r�cup�ration.
## Ajouts r�alis�s
### Gestion des commandes de livres et DVD
<br>
Ajout de la table Suivi dans la base de donn�es, reli�e � CommandeDocument.<br>
![img1](https://monportefolioanis.go.yj.fr/photo_readme_AP2/commandedocument_idsuivi.png)<br>

Nouvelle interface graphique pour g�rer les commandes de livres et de DVD.<br>
![img2](https://monportefolioanis.go.yj.fr/photo_readme_AP2/onglets_creer.png)<br>
Tri des listes sur les colonnes disponibles.<br>

Affichage des informations d'un livre/DVD et des commandes associ�es, tri�es par date d�croissante.<br>

Ajout d'une nouvelle commande via un groupbox.<br>

Modification de l'�tape de suivi avec des r�gles de progression stricte.<br>
![img3](https://monportefolioanis.go.yj.fr/photo_readme_AP2/modification_securiser.png)<br>

Alerte en cas de tentative de modification sans ligne s�lectionn�e au pr�alable.<br>
![img4](https://monportefolioanis.go.yj.fr/photo_readme_AP2/alerte_modification.png)<br>

Suppression de commande uniquement si elle n'est pas livr�e.<br>

Ajout d'un trigger qui, lorsque la commande est marqu�e comme "livr�e", g�n�re les exemplaires correspondants dans Exemplaire.<br>

### Gestion des commandes de revues
<br>
Nouvelle interface graphique pour g�rer les commandes de revues.<br>
![img5](https://monportefolioanis.go.yj.fr/photo_readme_AP2/onglet_abonnement.png)<br>
Possibilit� de s�lectionner une revue et d'afficher les abonnements associ�s.<br>

Ajout d'une nouvelle commande d'abonnement avec saisie des informations. L'id de commande est auto incr�ment� gr�ce � l'ajout d'une table abonnement et commandeabonnement'<br>
![img6](https://monportefolioanis.go.yj.fr/photo_readme_AP2/commande_abonnement.png)<br>
Suppression d'une commande de revue uniquement si aucun exemplaire n'y est rattach�.<br>

Ajout d'une alerte automatique affichant les abonnements se terminant dans moins de 30 jours.<br>
![img7](https://monportefolioanis.go.yj.fr/photo_readme_AP2/alerte_abonnement_fin.png)<br>

### Mise en place de l'authentification
<br>
Ajout des tables Utilisateur et Service pour g�rer les acc�s.<br>
![img8](https://monportefolioanis.go.yj.fr/photo_readme_AP2/user_service_table.png)<br>

Fen�tre d'authentification � l'ouverture de l'application.<br>
![img9](https://monportefolioanis.go.yj.fr/photo_readme_AP2/connexion_form.png)<br>
Gestion des droits d'acc�s : certains onglets deviennent invisibles ou inactifs selon l'utilisateur.<br>

Blocage complet pour le service "Culture" avec fermeture automatique de l'application.<br>

Restriction de l'alerte de fin d'abonnement aux utilisateurs concern�s.<br>

### Corrections de S�curit�
<br>
#### Probl�me 1 : Stockage des informations sensibles
<br>
S�curisation des identifiants de connexion en les stockant dans App.config plut�t que directement dans le code.<br>

#### Probl�me 2 : Protection des routes
<br>
Ajout d'une r�gle dans le fichier .htaccess pour retourner une erreur 400 en cas d'URL vide<br>

### R�cup�ration de l'Application et de l'API
<br>
#### O� t�l�charger l'application ?
<br>
L'application peut �tre r�cup�r�e sur le d�p�t suivant :<br> 
https://github.com/JeMeSuisPerdu/MediaTekDocuments <br>
#### Installation et ex�cution de l'application
<br>Une fois l'application t�l�charg�e, ex�cutez le fichier MediatekDocument.msi pour l'installer.<br>
L'ex�cutable sera install� dans le dossier de d�bogage de l'application.<br>
Voici le chemin : MediaTekDocuments\MediaTekDocumentsSetup\Release<br>
#### API en ligne et r�cup�ration en local
<br>
L'API est configur�e pour �tre utilis�e directement par l'application.
Si vous souhaitez la consulter ou l'ex�cuter en local, vous pouvez la r�cup�rer sur le d�p�t suivant :<br>
https://github.com/JeMeSuisPerdu/rest_mediatekdocuments <br>