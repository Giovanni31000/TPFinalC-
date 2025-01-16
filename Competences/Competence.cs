using System;

namespace projetfinal
{
    public enum TypeCible
    {
        SoiMeme,
        Equipe,
        AutrePersonnage,
        Ennemi,
        EquipeEnnemie
    }

    public class Competence
    {
        public string Nom { get; set; }
        public int TempsRecharge { get; set; }
        public TypeCible Cible { get; set; }
        public int CoutMana { get; set; }

        public Competence(string nom, int tempsRecharge, TypeCible cible, int coutMana)
        {
            Nom = nom;
            TempsRecharge = tempsRecharge;
            Cible = cible;
            CoutMana = coutMana;
        }

        public virtual void Utiliser(Personnage utilisateur, Personnage cible)
        {
            Console.WriteLine($"{utilisateur.Nom} utilise {Nom} sur {cible.Nom}.");
        }
    }

    public class FrappeHeroique : Competence
    {
        public FrappeHeroique() : base("Frappe héroïque", 1, TypeCible.Ennemi, 0) { }

        public override void Utiliser(Personnage utilisateur, Personnage cible)
        {
            base.Utiliser(utilisateur, cible);
            int degats = utilisateur.PuissanceAttaquePhysique;
            cible.PointsDeVie -= degats;
            Console.WriteLine($"{cible.Nom} subit {degats} points de dégâts.");
        }
    }

    public class CriDeBataille : Competence
    {
        public CriDeBataille() : base("Cri de bataille", 2, TypeCible.Equipe, 0) { }

        public override void Utiliser(Personnage utilisateur, Personnage cible)
        {
            base.Utiliser(utilisateur, cible);
            foreach (var membre in utilisateur.Equipe)
            {
                membre.PuissanceAttaquePhysique += 25;
                Console.WriteLine($"{membre.Nom} voit sa puissance d'attaque physique augmenter de 25.");
            }
        }
    }

    public class Tourbillon : Competence
    {
        public Tourbillon() : base("Tourbillon", 2, TypeCible.EquipeEnnemie, 0) { }

        public override void Utiliser(Personnage utilisateur, Personnage cible)
        {
            base.Utiliser(utilisateur, cible);
            foreach (var ennemi in utilisateur.EquipeEnnemie)
            {
                int degats = (int)(utilisateur.PuissanceAttaquePhysique * 0.33);
                ennemi.PointsDeVie -= degats;
                Console.WriteLine($"{ennemi.Nom} subit {degats} points de dégâts.");
            }
        }
    }
}

