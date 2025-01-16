using System;
using System.Collections.Generic;

namespace projetfinal
{
    public class Mage : Personnage
    {
        public Mage(string nom)
            : base(nom, 60, 0, 75, TypeArmure.Tissu, 0.05, 0.05, 0.25, 10, new List<Competence>
            {
                new Competence("Eclair de givre", 1, TypeCible.Ennemi, 0),
                new Competence("Barrière de givre", 3, TypeCible.SoiMeme, 0)
            })
        {
        }

        public override void Attaquer(Personnage cible)
        {
            int degats = this.PuissanceAttaqueMagique;
            cible.PointsDeVie -= degats;
            Console.WriteLine($"{this.Nom} attaque {cible.Nom} avec un Eclair de givre et inflige {degats} dégâts !");
        }

        public override void Defendre()
        {
            Console.WriteLine($"{this.Nom} utilise Barrière de givre pour réduire les dégâts des deux prochaines attaques.");
            this.ChanceParade += 0.5;
        }

        public override void Soigner(Personnage cible)
        {
            int soin = (int)(this.PuissanceAttaqueMagique * 1.25);
            cible.PointsDeVie += soin;
            if (cible.PointsDeVie > cible.PointsDeVieMax)
            {
                cible.PointsDeVie = cible.PointsDeVieMax;
            }
            Console.WriteLine($"{this.Nom} utilise Eclair lumineux et se soigne de {soin} points de vie.");
        }

        public override void UtiliserCompetence(string nomCompetence, Personnage cible)
        {
            var competence = this.Competences.Find(c => c.Nom == nomCompetence);
            if (competence != null)
            {
                if (nomCompetence == "Eclair de givre")
                {
                    Attaquer(cible);
                }
                else if (nomCompetence == "Barrière de givre")
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