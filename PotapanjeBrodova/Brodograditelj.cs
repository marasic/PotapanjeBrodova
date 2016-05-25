using System;
using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public enum Smjer
    {
        Horizontalno,
        Vertikalno
    }
    public class Brodograditelj
    {
        public Brodograditelj()
        {
<<<<<<< HEAD
            //eliminatorPolja = new Klasični
=======
            izbornikPolja = new SlučajniOdabirPočetnogPolja();
            eliminatorPolja = new KlasičniEliminatorPolja();
>>>>>>> 768604e6bc8fc3019b2b3706ed47d63e961fd9a7
        }

        public Brodograditelj(IOdabirPočetnogPoljaZaBrod odabirPočetnogPolja, IEliminatorPolja eliminator)
        {
<<<<<<< HEAD
            Flota f = new Flota();
            // napravi mrežu
            Mreža m = new Mreža(redaka, stupaca);
            // za svaku duljinu broda:
            for (int i = 0; i < duljineBrodova.Length; ++i)
            {
                // od mreže zatraži slobodna polja
                var slobodnaPolja = m.DajSlobodnaPolja();
                // izaberi početno polje za brod
                var pp = IzaberiPočetnoPolje(slobodnaPolja, duljineBrodova[i]);
                var pbr = DajPoljaZaBrod(pp.Item1, pp.Item2, duljineBrodova[i]);
                

                // napravi brod i dodaj ga u flotu

                Brod b = new Brod(pbr);
                f.DodajBrod(b);

                // mreži kaži da eliminira polja od i oko broda
            }
            return f;
        }

        public IEnumerable<Polje> DajPoljaZaBrod(Smjer smjer, Polje početno, int duljinaBroda)
        {
            int redak = početno.Redak;
            int stupac = početno.Stupac;
            int deltaRedak = smjer == Smjer.Horizontalno ? 0 : 1;
            int deltaStupac = smjer == Smjer.Vertikalno ? 0 : 1;
            List<Polje> polja = new List<Polje>();

            for (int i = 0; i < duljinaBroda; ++i)
            {
                polja.Add(new Polje(redak, stupac));
                redak += deltaRedak;
                stupac += deltaStupac;
            }
            return polja;
        }
        public Tuple<Smjer, Polje> IzaberiPočetnoPolje(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            var horizontalnaPolja = DajHorizontalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            var vertikalnaPolja = DajVertikalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            int ukupnoKandidata = horizontalnaPolja.Count() + vertikalnaPolja.Count();
            Random slučajni = new Random();
            int izbor = slučajni.Next(0, ukupnoKandidata);
            if (izbor >= horizontalnaPolja.Count())
            { 
            return  new Tuple<Smjer,Polje>(Smjer.Vertikalno, vertikalnaPolja.ElementAt(izbor - horizontalnaPolja.Count()));
            }
            return  new Tuple<Smjer,Polje>(Smjer.Horizontalno, horizontalnaPolja.ElementAt(izbor));
        }

        public IEnumerable<Polje> DajHorizontalnaPočetnaPolja(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
=======
            izbornikPolja = odabirPočetnogPolja;
            eliminatorPolja = eliminator;
        }

        public Flota SložiFlotu(int redaka, int stupaca, int[] duljineBrodova)
>>>>>>> 768604e6bc8fc3019b2b3706ed47d63e961fd9a7
        {
            const int brojPokušaja = 5;
            for (int i = 0; i < brojPokušaja; ++i)
            {
                try
                {
                    Mreža mreža = new Mreža(redaka, stupaca);
                    return SložiBrodove(duljineBrodova, mreža);
                }
                catch (ApplicationException) { }
            }
            // ako ne uspije složiti niti nakon 5 pokušaja, baca iznimku
            throw new ApplicationException();
        }

<<<<<<< HEAD
       
        public IEnumerable<Polje> DajVertikalnaPočetnaPolja(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
=======
        private Flota SložiBrodove(int[] duljineBrodova, Mreža mreža)
>>>>>>> 768604e6bc8fc3019b2b3706ed47d63e961fd9a7
        {
            Flota flota = new Flota();
            // za svaku duljinu broda:
            for (int i = 0; i < duljineBrodova.Length; ++i)
            {
                var slobodnaPolja = mreža.DajSlobodnaPolja();
                var pp = izbornikPolja.IzaberiPočetnoPolje(slobodnaPolja, duljineBrodova[i]);
                var pbr = mreža.DajPoljaZaBrod(pp.Smjer, pp.Polje, duljineBrodova[i]);
                Brod b = new Brod(pbr);
                flota.DodajBrod(b);
                EliminirajPoljaOkoBroda(mreža, pbr);
            }
            return flota;
        }

        private void EliminirajPoljaOkoBroda(Mreža mreža, IEnumerable<Polje> brodskaPolja)
        {
<<<<<<< HEAD
            int redak = p.Redak;
            int stupac = p.Stupac;
            for (int s = stupac + 1; s < stupac + duljinaBroda; ++s)
                if (!slobodnaPolja.Contains(new Polje(redak, s)))
                    return false;
                return true;
        }

        bool ImaDovoljnoPoljaIspod(Polje p, IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            int redak = p.Redak;
            int stupac = p.Stupac;
            for (int r = redak + 1; r < stupac + duljinaBroda; ++r)
                if (!slobodnaPolja.Contains(new Polje(r, stupac)))
                    return false;
            return true;
        }
=======
            IEnumerable<Polje> zaEliminirati = eliminatorPolja.PoljaKojaTrebaUklonitiOkoBroda(brodskaPolja, mreža.Redaka, mreža.Stupaca);
            foreach (Polje p in zaEliminirati)
                mreža.EliminirajPolje(p);
        }

        IOdabirPočetnogPoljaZaBrod izbornikPolja;
        IEliminatorPolja eliminatorPolja;
>>>>>>> 768604e6bc8fc3019b2b3706ed47d63e961fd9a7
    }
}
