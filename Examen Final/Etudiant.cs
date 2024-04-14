using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final
{
    public class Etudiant
    {
        public int NumeroEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        // Constructeur
        public Etudiant(int numero, string nom, string prenom)
        {
            NumeroEtudiant = numero;
            Nom = nom;
            Prenom = prenom;
        }
    }
}
