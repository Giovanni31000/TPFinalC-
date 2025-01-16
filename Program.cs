using System;
using System.Collections.Generic;

namespace projetfinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu de personnages !");

            // Exemple de création de personnages
            var guerrier = new Guerrier("Aragorn");
            var mage = new Mage("Gandalf");
            var voleur = new Voleur("Legolas");

            // Initialisation des équipes
            guerrier.Equipe.Add(guerrier);
            guerrier.Equipe.Add(mage);
            guerrier.Equipe.Add(voleur);

            mage.Equipe.Add(guerrier);
            mage.Equipe.Add(mage);
            mage.Equipe.Add(voleur);

            voleur.Equipe.Add(guerrier);
            voleur.Equipe.Add(mage);
            voleur.Equipe.Add(voleur);

            guerrier.EquipeEnnemie.Add(mage);
            guerrier.EquipeEnnemie.Add(voleur);

            mage.EquipeEnnemie.Add(guerrier);
            mage.EquipeEnnemie.Add(voleur);

            voleur.EquipeEnnemie.Add(guerrier);
            voleur.EquipeEnnemie.Add(mage);

            // Affichage des informations des personnages
            Console.WriteLine(guerrier);
            Console.WriteLine(mage);
            Console.WriteLine(voleur);

            // Utilisation des compétences
            guerrier.UtiliserCompetence("Frappe héroïque", mage);
            guerrier.UtiliserCompetence("Cri de bataille", guerrier);
        }
    }
}