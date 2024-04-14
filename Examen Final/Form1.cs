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
            // Validation de l'entr�e num�rique pour l'ID de l'�tudiant.
            if (!int.TryParse(textId.Text, out int idEtudiant))
            {
                MessageBox.Show("Le num�ro de l'�tudiant doit �tre num�rique.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortie pr�coce en cas d'�chec de validation.
            }

            // Validation de l'entr�e num�rique pour le num�ro du cours.
            if (!int.TryParse(textNumeroCours.Text, out int numeroCours))
            {
                MessageBox.Show("Le num�ro du cours doit �tre num�rique.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortie pr�coce en cas d'�chec de validation.
            }

            // V�rification de la s�lection d'un titre de cours dans le ComboBox.
            if (comboTitreCours.SelectedItem == null)
            {
                MessageBox.Show("Veuillez s�lectionner un titre de cours.", "S�lection Manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sortie pr�coce si aucun titre de cours n'est s�lectionn�.
            }

            // Validation et conversion de la note saisie en nombre flottant.
            if (!float.TryParse(textNote.Text, out float valeurNote))
            {
                MessageBox.Show("La note doit �tre un nombre valide.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sortie pr�coce si la note n'est pas valide.
            }

            // Cr�ation des instances avec les donn�es valid�es.
            Etudiant nouvelEtudiant = new Etudiant(idEtudiant, textNom.Text, textPrenom.Text);
            Cours nouveauCours = new Cours(numeroCours, textCodeCours.Text, comboTitreCours.SelectedItem.ToString());
            Note nouvelleNote = new Note(idEtudiant, numeroCours, valeurNote);

            // Chemin vers le dossier o� les informations des �tudiants seront stock�es.
            string dossierEtudiants = Path.Combine(Application.StartupPath, "Etudiant");
            Directory.CreateDirectory(dossierEtudiants); // Assure la cr�ation du dossier s'il n'existe pas d�j�.

            // Formatage du nom de fichier pour inclure � la fois le nom, le pr�nom de l'�tudiant, et son ID.
            string fileName = $"{nouvelEtudiant.Nom} {nouvelEtudiant.Prenom}.txt";
            string filePath = Path.Combine(dossierEtudiants, fileName);

            // Enregistrement des informations de l'�tudiant, du cours et de la note dans le fichier.
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


            // Confirmation de l'ajout r�ussi des informations et rafra�chissement de l'affichage
            MessageBox.Show("Les informations de l'�tudiant, du cours, et de la note ont �t� ajout�es avec succ�s.", "Ajout R�ussi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnEffacer_Click(object sender, EventArgs e)
        {
            // Effacer le contenu des contr�les TextBox
            textId.Text = "";
            textNom.Text = "";
            textPrenom.Text = "";
            textNumeroCours.Text = "";
            textCodeCours.Text = "";

            // R�initialiser la s�lection du ComboBox
            comboTitreCours.SelectedIndex = -1; // Cela suppose que votre ComboBox s'appelle comboTitre

            // Effacer la note ou la r�initialiser
            textNote.Text = "";

            // Effacer le contenu du RichTextBox
            LectureFichier.Text = "";
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textId.Text, out int id))
            {
                MessageBox.Show("L'ID doit �tre num�rique.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dossierEtudiants = Path.Combine(Application.StartupPath, "Etudiant");
            if (!Directory.Exists(dossierEtudiants))
            {
                MessageBox.Show("Le dossier des �tudiants n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recherche dans tous les fichiers .txt du dossier pour trouver celui qui correspond � l'ID.
            string[] fichiersEtudiants = Directory.GetFiles(dossierEtudiants, "*.txt");
            string fichierEtudiantTrouve = null;

            foreach (string fichier in fichiersEtudiants)
            {
                using (StreamReader sr = new StreamReader(fichier))
                {
                    string contenuFichier = sr.ReadToEnd();
                    // Si le contenu du fichier contient la ligne avec l'ID, nous avons trouv� le fichier correspondant.
                    if (contenuFichier.Contains($"Numero d'Etudiant: {id}"))
                    {
                        fichierEtudiantTrouve = fichier;
                        break; // Arr�ter la recherche d�s qu'on trouve le fichier.
                    }
                }
            }

            if (fichierEtudiantTrouve != null)
            {
                // Affichage du contenu du fichier trouv�.
                using (StreamReader sr = new StreamReader(fichierEtudiantTrouve))
                {
                    LectureFichier.Text = sr.ReadToEnd();
                    MessageBox.Show("�tudiant trouv� et affich�.", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Aucun �tudiant trouv� avec cet ID.", "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Configurer les polices
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12, FontStyle.Regular);

            // D�finir les marges
            float startX = 100f;
            float startY = 100f;
            float offset = 20f; // Espacement entre les lignes

            // Imaginons que LectureFichier.Text contient les donn�es s�par�es par des lignes
            // et que chaque ligne a des �l�ments s�par�s par des virgules.
            string[] lines = LectureFichier.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            float currentY = startY;

            // Imprimer les lignes
            foreach (string line in lines)
            {
                // S�parer les champs et les traiter
                string[] fields = line.Split(',');

                // Assurez-vous que la ligne contient au moins un champ avant d'essayer d'imprimer
                if (fields.Length > 0)
                {
                    // Imprimer le premier champ en gras (en-t�te)
                    e.Graphics.DrawString(fields[0], boldFont, Brushes.Black, startX, currentY);

                    // Imprimer les autres champs avec la police normale
                    float currentX = startX + 100; // D�caler la position de la premi�re valeur � droite de l'en-t�te
                    for (int i = 1; i < fields.Length; i++)
                    {
                        e.Graphics.DrawString(fields[i], regularFont, Brushes.Black, currentX, currentY);
                        currentX += 100; // Supposer que chaque champ est espac� de 100 unit�s
                    }
                }

                currentY += offset; // Aller � la ligne suivante
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
