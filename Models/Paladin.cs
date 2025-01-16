using System;
using System.Collections.Generic;

namespace projetfinal
{
    public class Paladin : Personnage
    {
        public Paladin(string nom)
            : base(nom, 95, 40, 40, TypeArmure.Mailles, 0.05, 0.10, 0.20, 50, new List<Competence>
            {
                new Competence("Frappe du croisé", 1, TypeCible.Ennemi, 0),
                new Competence("Jugement", 3, TypeCible.Ennemi, 0),
                new Competence("Eclair lumineux", 5, TypeCible.SoiMeme, 0)
            })
        {
        }

        public override void Attaquer(Personnage cible)
        {
            int degats = this.PuissanceAttaquePhysique;
            cible.PointsDeVie -= degats;
            Console.WriteLine($"{this.Nom} attaque {cible.Nom} avec une Frappe du croisé et inflige {degats} dégâts !");
            Soigner(this, degats / 2);
        }

        public override void Defendre()
        {
            Console.WriteLine($"{this.Nom} se prépare à parer les attaques ennemies, augmentant sa chance de parade.");
            this.ChanceParade += 0.1;
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
                if (nomCompetence == "Frappe du croisé")
                {
                    Attaquer(cible);
                }
                else if (nomCompetence == "Jugement")
                {
                    int degats = this.PuissanceAttaqueMagique;
                    cible.PointsDeVie -= degats;
                    Console.WriteLine($"{this.Nom} utilise {nomCompetence} sur {cible.Nom} et inflige {degats} dégâts !");
                    Soigner(this, degats / 2);
                }
                else if (nomCompetence == "Eclair lumineux")
                {
                    Soigner(this);
                }
            }
            else
            {
                Console.WriteLine($"{this.Nom} ne possède pas la compétence {nomCompetence}.");
            }
        }

        private void Soigner(Personnage cible, int montant)
        {
            cible.PointsDeVie += montant;
            if (cible.PointsDeVie > cible.PointsDeVieMax)
            {
                cible.PointsDeVie = cible.PointsDeVieMax;
            }
            Console.WriteLine($"{this.Nom} se soigne de {montant} points de vie.");
        }
    }
}