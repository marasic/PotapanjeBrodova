﻿using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PotapanjeBrodova;

namespace UnitTests
{
    [TestClass]
    public class TestFlote
    {
        [TestMethod]
        public void Flota_DodajBrodZaTriRazličitaBrodaSlažeFlotuOdTriBroda()
        {
            Mreža m = new Mreža(10, 10);
            Flota f = new Flota();

            var p1 = m.DajPoljaZaBrod(Smjer.Horizontalno, new Polje(0, 0), 5);
            Brod b1 = new Brod(p1);
            f.DodajBrod(b1);

            var p2 = m.DajPoljaZaBrod(Smjer.Vertikalno, new Polje(1, 3), 4);
            Brod b2 = new Brod(p2);
            f.DodajBrod(b2);

            var p3 = m.DajPoljaZaBrod(Smjer.Horizontalno, new Polje(4, 5), 3);
            Brod b3 = new Brod(p3);
            f.DodajBrod(b3);

            Assert.AreEqual(3, f.Brodovi.Count());
            Assert.IsTrue(f.Brodovi.Contains(b1));
            Assert.IsTrue(f.Brodovi.Contains(b2));
            Assert.IsTrue(f.Brodovi.Contains(b3));
        }
    }
}
