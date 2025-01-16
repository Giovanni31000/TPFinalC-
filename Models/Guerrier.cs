using System;
using System.Collections.Generic;

namespace projetfinal
{
    public class Guerrier : Personnage
    {
        public Guerrier(string nom)
            : base(nom, 100, 50, 0, TypeArmure.Plaques, 0.05, 0.25, 0.10, 50, new List<Competence>
            {
                new Competence("Frappe héroïque", 1, TypeCible.Ennemi, 0),
                new Competence("Cri de bataille", 3, TypeCible.SoiMeme, 0)
            })
        {
        }

        public override void Attaquer(Personnage cible)
        {
            int degats = this.PuissanceAttaquePhysique;
            cible.PointsDeVie -= degats;
            Console.WriteLine($"{this.Nom} attaque {cible.Nom} avec une Frappe héroïque et inflige {degats} dégâts !");
        }

        public override void Defendre()
        {
            Console.WriteLine($"{this.Nom} se prépare à parer les attaques ennemies, augmentant sa chance de parade.");
            this.ChanceParade += 0.1;
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
                if (nomCompetence == "Frappe héroïque")
                {
                    Attaquer(cible);
                }
                else if (nomCompetence == "Cri de bataille")
                {
                    Console.WriteLine($"{this.Nom} utilise {nomCompetence} pour doubler sa puissance d'attaque.");
                    this.PuissanceAttaquePhysique *= 2;
                }
            }
            else
            {
                Console.WriteLine($"{this.Nom} ne possède pas la compétence {nomCompetence}.");
            }
        }

        public override void RecevoirAttaquePhysique(int degats)
        {
            base.RecevoirAttaquePhysique(degats);
            if (new Random().NextDouble() <= 0.25)
            {
                int contreAttaqueDegats = (int)(degats * 0.5);
                Console.WriteLine($"{this.Nom} contre-attaque et inflige {contreAttaqueDegats} dégâts !");
            }
        }
    }
}