namespace Examen_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Validation de l'entrée numérique pour l'ID de l'étudiant.
            if (!int.TryParse(textId.Text, out int idEtudiant))
            {
                MessageBox.Show("Le numéro de l'étudiant doit être numérique.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortie précoce en cas d'échec de validation.
            }

            // Validation de l'entrée numérique pour le numéro du cours.
            if (!int.TryParse(textNumeroCours.Text, out int numeroCours))
            {
                MessageBox.Show("Le numéro du cours doit être numérique.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortie précoce en cas d'échec de validation.
            }

            // Vérification de la sélection d'un titre de cours dans le ComboBox.
            if (comboTitreCours.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un titre de cours.", "Sélection Manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sortie précoce si aucun titre de cours n'est sélectionné.
            }

            // Validation et conversion de la note saisie en nombre flottant.
            if (!float.TryParse(textNote.Text, out float valeurNote))
            {
                MessageBox.Show("La note doit être un nombre valide.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortie précoce si la note n'est pas valide.
            }

            // Création des instances avec les données validées.
            Etudiant nouvelEtudiant = new Etudiant(idEtudiant, textNom.Text, textPrenom.Text);
            Cours nouveauCours = new Cours(numeroCours, textCodeCours.Text, comboTitreCours.SelectedItem.ToString());
            Note nouvelleNote = new Note(idEtudiant, numeroCours, valeurNote);

            // Chemin vers le dossier où les informations des étudiants seront stockées.
            string dossierEtudiants = Path.Combine(Application.StartupPath, "Etudiant");
            Directory.CreateDirectory(dossierEtudiants); // Assure la création du dossier s'il n'existe pas déjà.

            // Formatage du nom de fichier pour inclure à la fois le nom, le prénom de l'étudiant, et son ID.
            string fileName = $"{nouvelEtudiant.Nom} {nouvelEtudiant.Prenom}.txt";
            string filePath = Path.Combine(dossierEtudiants, fileName);

            // Enregistrement des informations de l'étudiant, du cours et de la note dans le fichier.
            using (StreamWriter sw = new StreamWriter(filePath, true)) // Append set to true to avoid overwriting.
            {
                sw.WriteLine($"Numero d'Etudiant: {nouvelEtudiant.NumeroEtudiant}");
                sw.WriteLine($"Nom: {nouvelEtudiant.Nom}");
                sw.WriteLine($"Prenom: {nouvelEtudiant.Prenom}");
                sw.WriteLine($"Numero du Cours: {nouveauCours.NumeroCours}");
                sw.WriteLine($"Code du Cours: {nouveauCours.Code}");
                sw.WriteLine($"Titre du Cours: {nouveauCours.Titre}");
                sw.WriteLine($"Note: {nouvelleNote.ValeurNote}");
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                LectureFichier.Text = sr.ReadToEnd();
            }


            // Confirmation de l'ajout réussi des informations et rafraîchissement de l'affichage
            MessageBox.Show("Les informations de l'étudiant, du cours, et de la note ont été ajoutées avec succès.", "Ajout Réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnEffacer_Click(object sender, EventArgs e)
        {
            // Effacer le contenu des contrôles TextBox
            textId.Text = "";
            textNom.Text = "";
            textPrenom.Text = "";
            textNumeroCours.Text = "";
            textCodeCours.Text = "";

            // Réinitialiser la sélection du ComboBox
            comboTitreCours.SelectedIndex = -1; // Cela suppose que votre ComboBox s'appelle comboTitre

            // Effacer la note ou la réinitialiser
            textNote.Text = "";

            // Effacer le contenu du RichTextBox
            LectureFichier.Text = "";
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textId.Text, out int id))
            {
                MessageBox.Show("L'ID doit être numérique.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dossierEtudiants = Path.Combine(Application.StartupPath, "Etudiant");
            if (!Directory.Exists(dossierEtudiants))
            {
                MessageBox.Show("Le dossier des étudiants n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recherche dans tous les fichiers .txt du dossier pour trouver celui qui correspond à l'ID.
            string[] fichiersEtudiants = Directory.GetFiles(dossierEtudiants, "*.txt");
            string fichierEtudiantTrouve = null;

            foreach (string fichier in fichiersEtudiants)
            {
                using (StreamReader sr = new StreamReader(fichier))
                {
                    string contenuFichier = sr.ReadToEnd();
                    // Si le contenu du fichier contient la ligne avec l'ID, nous avons trouvé le fichier correspondant.
                    if (contenuFichier.Contains($"Numero d'Etudiant: {id}"))
                    {
                        fichierEtudiantTrouve = fichier;
                        break; // Arrêter la recherche dès qu'on trouve le fichier.
                    }
                }
            }

            if (fichierEtudiantTrouve != null)
            {
                // Affichage du contenu du fichier trouvé.
                using (StreamReader sr = new StreamReader(fichierEtudiantTrouve))
                {
                    LectureFichier.Text = sr.ReadToEnd();
                    MessageBox.Show("Étudiant trouvé et affiché.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Aucun étudiant trouvé avec cet ID.", "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Configurer les polices
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12, FontStyle.Regular);

            // Définir les marges
            float startX = 100f;
            float startY = 100f;
            float offset = 20f; // Espacement entre les lignes

            // Imaginons que LectureFichier.Text contient les données séparées par des lignes
            // et que chaque ligne a des éléments séparés par des virgules.
            string[] lines = LectureFichier.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            float currentY = startY;

            // Imprimer les lignes
            foreach (string line in lines)
            {
                // Séparer les champs et les traiter
                string[] fields = line.Split(',');

                // Assurez-vous que la ligne contient au moins un champ avant d'essayer d'imprimer
                if (fields.Length > 0)
                {
                    // Imprimer le premier champ en gras (en-tête)
                    e.Graphics.DrawString(fields[0], boldFont, Brushes.Black, startX, currentY);

                    // Imprimer les autres champs avec la police normale
                    float currentX = startX + 100; // Décaler la position de la première valeur à droite de l'en-tête
                    for (int i = 1; i < fields.Length; i++)
                    {
                        e.Graphics.DrawString(fields[i], regularFont, Brushes.Black, currentX, currentY);
                        currentX += 100; // Supposer que chaque champ est espacé de 100 unités
                    }
                }

                currentY += offset; // Aller à la ligne suivante
            }

            // Nettoyage des ressources de police
            boldFont.Dispose();
            regularFont.Dispose();

        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
