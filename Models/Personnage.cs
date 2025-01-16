using System;
using System.Collections.Generic;
using System.Linq;

namespace projetfinal
{
    public class Personnage
    {
        public string Nom { get; set; }
        public int PointsDeVie { get; set; }
        public int PointsDeVieMax { get; set; }
        public int PuissanceAttaquePhysique { get; set; }
        public int PuissanceAttaqueMagique { get; set; }
        public TypeArmure Armure { get; set; }
        public double ChanceEsquive { get; set; }
        public double ChanceParade { get; set; }
        public double ChanceResistanceSorts { get; set; }
        public int Vitesse { get; set; }
        public List<Competence> Competences { get; set; }
        public List<Personnage> Equipe { get; set; }
        public List<Personnage> EquipeEnnemie { get; set; }

        public Personnage(string nom, int pointsDeVieMax, int puissanceAttaquePhysique, int puissanceAttaqueMagique, TypeArmure armure, double chanceEsquive, double chanceParade, double chanceResistanceSorts, int vitesse, List<Competence> competences)
        {
            Nom = nom;
            PointsDeVie = pointsDeVieMax;
            PointsDeVieMax = pointsDeVieMax;
            PuissanceAttaquePhysique = puissanceAttaquePhysique;
            PuissanceAttaqueMagique = puissanceAttaqueMagique;
            Armure = armure;
            ChanceEsquive = chanceEsquive;
            ChanceParade = chanceParade;
            ChanceResistanceSorts = chanceResistanceSorts;
            Vitesse = vitesse;
            Competences = competences;
            Equipe = new List<Personnage>();
            EquipeEnnemie = new List<Personnage>();
        }

        public virtual void Attaquer(Personnage cible)
        {
            Console.WriteLine($"{Nom} attaque {cible.Nom}.");
        }

        public virtual void Defendre()
        {
            Console.WriteLine($"{Nom} se défend.");
        }

        public virtual void Soigner(Personnage cible)
        {
            Console.WriteLine($"{Nom} soigne {cible.Nom}.");
        }

        public virtual void UtiliserCompetence(string nomCompetence, Personnage cible)
        {
            var competence = Competences.Find(c => c.Nom == nomCompetence);
            if (competence != null)
            {
                competence.Utiliser(this, cible);
            }
            else
            {
                Console.WriteLine($"{Nom} ne possède pas la compétence {nomCompetence}.");
            }
        }

        public virtual void RecevoirAttaquePhysique(int degats)
        {
            PointsDeVie -= degats;
            Console.WriteLine($"{Nom} reçoit {degats} dégâts.");
        }

        public override string ToString()
        {
            return $"Nom: {Nom}, Points de Vie: {PointsDeVie}/{PointsDeVieMax}, Puissance Attaque Physique: {PuissanceAttaquePhysique}, Puissance Attaque Magique: {PuissanceAttaqueMagique}, Armure: {Armure}, Chance Esquive: {ChanceEsquive}, Chance Parade: {ChanceParade}, Chance Résistance Sorts: {ChanceResistanceSorts}, Vitesse: {Vitesse}, Compétences: {string.Join(", ", Competences.Select(c => c.Nom))}";
        }
    }

    public enum TypeDegat
    {
        Physique,
        Magique
    }
}