using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final
{
    public class Note
    {
        public int NumeroEtudiant { get; set; }
        public int NumeroCours { get; set; }
        public float ValeurNote { get; set; }

        public Note(int numeroEtudiant, int numeroCours, float valeurNote)
        {
            NumeroEtudiant = numeroEtudiant;
            NumeroCours = numeroCours;
            ValeurNote = valeurNote;
        }

        // Méthode pour afficher la note d'un étudiant pour un cours
        public override string ToString()
        {
            return $"Etudiant: {NumeroEtudiant}, Cours: {NumeroCours}, Note: {ValeurNote}";
        }
    }
}

