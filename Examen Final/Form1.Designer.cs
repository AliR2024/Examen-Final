namespace Examen_Final
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textNom = new TextBox();
            label3 = new Label();
            textPrenom = new TextBox();
            label4 = new Label();
            textNumeroCours = new TextBox();
            label5 = new Label();
            textCodeCours = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textNote = new TextBox();
            btnRechercher = new Button();
            comboTitreCours = new ComboBox();
            LectureFichier = new RichTextBox();
            BtnEffacer = new Button();
            btnImprimer = new Button();
            btnAjouter = new Button();
            printDocument = new System.Drawing.Printing.PrintDocument();
            SuspendLayout();
            // 
            // textId
            // 
            textId.BorderStyle = BorderStyle.FixedSingle;
            textId.Location = new Point(172, 150);
            textId.Name = "textId";
            textId.Size = new Size(179, 27);
            textId.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 157);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 1;
            label1.Text = "Id Etudiant";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(54, 193);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 3;
            label2.Text = "Nom";
            // 
            // textNom
            // 
            textNom.BorderStyle = BorderStyle.FixedSingle;
            textNom.Location = new Point(172, 186);
            textNom.Name = "textNom";
            textNom.Size = new Size(308, 27);
            textNom.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(54, 229);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 5;
            label3.Text = "Prenom";
            // 
            // textPrenom
            // 
            textPrenom.BorderStyle = BorderStyle.FixedSingle;
            textPrenom.Location = new Point(172, 222);
            textPrenom.Name = "textPrenom";
            textPrenom.Size = new Size(308, 27);
            textPrenom.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(54, 268);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 7;
            label4.Text = "Numero Cours";
            // 
            // textNumeroCours
            // 
            textNumeroCours.BorderStyle = BorderStyle.FixedSingle;
            textNumeroCours.Location = new Point(172, 261);
            textNumeroCours.Name = "textNumeroCours";
            textNumeroCours.Size = new Size(308, 27);
            textNumeroCours.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(54, 305);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 9;
            label5.Text = "Code Cours";
            // 
            // textCodeCours
            // 
            textCodeCours.BorderStyle = BorderStyle.FixedSingle;
            textCodeCours.Location = new Point(172, 298);
            textCodeCours.Name = "textCodeCours";
            textCodeCours.Size = new Size(308, 27);
            textCodeCours.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(54, 342);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 11;
            label6.Text = "Titre Cours";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(54, 378);
            label7.Name = "label7";
            label7.Size = new Size(43, 20);
            label7.TabIndex = 13;
            label7.Text = "Note";
            // 
            // textNote
            // 
            textNote.BorderStyle = BorderStyle.FixedSingle;
            textNote.Location = new Point(172, 371);
            textNote.Name = "textNote";
            textNote.Size = new Size(308, 27);
            textNote.TabIndex = 12;
            // 
            // btnRechercher
            // 
            btnRechercher.FlatStyle = FlatStyle.System;
            btnRechercher.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRechercher.ForeColor = SystemColors.ActiveBorder;
            btnRechercher.Location = new Point(347, 149);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(133, 29);
            btnRechercher.TabIndex = 14;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // comboTitreCours
            // 
            comboTitreCours.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTitreCours.FormattingEnabled = true;
            comboTitreCours.Items.AddRange(new object[] { "Assurance de qualité logicielle", "Développement d'applications mobiles pour Android", "Introduction aux bases de données", "Introduction à la programmation Web client", "Programmation orientée objet en C#", "Statistiques" });
            comboTitreCours.Location = new Point(172, 334);
            comboTitreCours.Name = "comboTitreCours";
            comboTitreCours.Size = new Size(308, 28);
            comboTitreCours.TabIndex = 15;
            // 
            // LectureFichier
            // 
            LectureFichier.BorderStyle = BorderStyle.FixedSingle;
            LectureFichier.Location = new Point(497, 148);
            LectureFichier.Name = "LectureFichier";
            LectureFichier.Size = new Size(455, 250);
            LectureFichier.TabIndex = 16;
            LectureFichier.Text = "";
            // 
            // BtnEffacer
            // 
            BtnEffacer.BackColor = Color.Red;
            BtnEffacer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            BtnEffacer.ForeColor = SystemColors.ButtonHighlight;
            BtnEffacer.Location = new Point(347, 458);
            BtnEffacer.Name = "BtnEffacer";
            BtnEffacer.Size = new Size(133, 29);
            BtnEffacer.TabIndex = 18;
            BtnEffacer.Text = "Effacer";
            BtnEffacer.UseVisualStyleBackColor = false;
            BtnEffacer.Click += BtnEffacer_Click;
            // 
            // btnImprimer
            // 
            btnImprimer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnImprimer.Location = new Point(819, 113);
            btnImprimer.Name = "btnImprimer";
            btnImprimer.Size = new Size(133, 29);
            btnImprimer.TabIndex = 19;
            btnImprimer.Text = "Imprimer";
            btnImprimer.UseVisualStyleBackColor = true;
            btnImprimer.Click += btnImprimer_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAjouter.Location = new Point(172, 458);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(133, 29);
            btnAjouter.TabIndex = 20;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // printDocument
            // 
            printDocument.PrintPage += printDocument_PrintPage;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(1006, 690);
            Controls.Add(btnAjouter);
            Controls.Add(btnImprimer);
            Controls.Add(BtnEffacer);
            Controls.Add(LectureFichier);
            Controls.Add(comboTitreCours);
            Controls.Add(btnRechercher);
            Controls.Add(label7);
            Controls.Add(textNote);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textCodeCours);
            Controls.Add(label4);
            Controls.Add(textNumeroCours);
            Controls.Add(label3);
            Controls.Add(textPrenom);
            Controls.Add(label2);
            Controls.Add(textNom);
            Controls.Add(label1);
            Controls.Add(textId);
            Name = "Form1";
            Text = "Gestion ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textId;
        private Label label1;
        private Label label2;
        private TextBox textNom;
        private Label label3;
        private TextBox textPrenom;
        private Label label4;
        private TextBox textNumeroCours;
        private Label label5;
        private TextBox textCodeCours;
        private Label label6;
        private Label label7;
        private TextBox textNote;
        private Button btnRechercher;
        private ComboBox comboTitreCours;
        private RichTextBox LectureFichier;
        private Button BtnEffacer;
        private Button btnImprimer;
        private Button btnAjouter;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}
