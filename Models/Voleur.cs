using System;
using System.Collections.Generic;

namespace projetfinal
{
    public class Voleur : Personnage
    {
        public Voleur(string nom)
            : base(nom, 80, 55, 0, TypeArmure.Cuir, 0.15, 0.25, 0.25, 50, new List<Competence>
            {
                new Competence("Coup bas", 1, TypeCible.Ennemi, 0),
                new Competence("Evasion", 3, TypeCible.SoiMeme, 0)
            })
        {
        }

        public override void Attaquer(Personnage cible)
        {
            if (this.PointsDeVie <= 0)
            {
                Console.WriteLine($"{this.Nom} est mort et ne peut pas attaquer.");
                return;
            }

            if (cible.PointsDeVie <= 0)
            {
                Console.WriteLine($"{cible.Nom} est déjà mort.");
                return;
            }

            Console.WriteLine($"{this.Nom} prépare une attaque contre {cible.Nom}.");
            int degats = cible.PointsDeVie < cible.PointsDeVieMax / 2 ? (int)(this.PuissanceAttaquePhysique * 1.5) : this.PuissanceAttaquePhysique;
            cible.PointsDeVie -= degats;
            Console.WriteLine($"{this.Nom} attaque {cible.Nom} avec un Coup bas et inflige {degats} dégâts !");
        }

        public override void Defendre()
        {
            Console.WriteLine($"{this.Nom} utilise Evasion pour augmenter ses chances d'esquive et de résistance aux sorts.");
            this.ChanceEsquive = Math.Min(this.ChanceEsquive + 0.2, 0.5);
            this.ChanceResistanceSorts = Math.Min(this.ChanceResistanceSorts + 0.2, 0.5);
        }

        public override void Soigner(Personnage cible)
        {
            Console.WriteLine($"{this.Nom} ne peut pas soigner.");
        }

        public override void UtiliserCompetence(string nomCompetence, Personnage cible)
        {
            var competence = this.Competences.Find(c => c.Nom == nomCompetence);
            if (competence != null)
            {
                if (nomCompetence == "Coup bas")
                {
                    Attaquer(cible);
                }
                else if (nomCompetence == "Evasion")
                {
                    Defendre();
                }
            }
            else
            {
                Console.WriteLine($"{this.Nom} ne possède pas la compétence {nomCompetence}.");
            }
        }
    }
}