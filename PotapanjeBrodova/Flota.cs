using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public class Flota
    {
        public void DodajBrod(Brod b)
        {
            brodovi.Add(b);
        }

        public IEnumerable<Brod> Brodovi
        {
<<<<<<< HEAD
            get { return Brodovi; }
=======
            get { return brodovi; }
        }

        public int BrojBrodova
        {
            get { return brodovi.Count; }
        }

        public RezultatGađanja Gađaj(Polje polje)
        {
            foreach (Brod b in brodovi)
            {
                var rezultat = b.Gađaj(polje);
                if (rezultat != RezultatGađanja.Promašaj)
                    return rezultat;
            }
            return RezultatGađanja.Promašaj;
>>>>>>> 768604e6bc8fc3019b2b3706ed47d63e961fd9a7
        }

        List<Brod> brodovi = new List<Brod>();
    }
}
