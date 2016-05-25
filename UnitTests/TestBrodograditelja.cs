using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TestBrodograditelja
    {

        [TestMethod]
        public void Brodograditelj_SložiFlotuVraćaFlotuSaZadanimBrojemBrodova()
        {
            int redaka = 10;
            int stupaca = 10;
            int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Brodograditelj b = new Brodograditelj();
            var flota = b.SložiFlotu(redaka, stupaca, duljineBrodova);
            Assert.AreEqual(10, flota.BrojBrodova);
            // provjerimo koliko je brodova zadane duljine
            Assert.AreEqual(1, flota.Brodovi.Count(brod => brod.Duljina == 5));
            Assert.AreEqual(2, flota.Brodovi.Count(brod => brod.Duljina == 4));
            Assert.AreEqual(3, flota.Brodovi.Count(brod => brod.Duljina == 3));
            Assert.AreEqual(4, flota.Brodovi.Count(brod => brod.Duljina == 2));
        }

        [TestMethod]
        public void Brodograditelj_DajPoljaZaBrodVraćaListuOd3HorizontalnaPolja()
        {
            Brodograditelj b = new Brodograditelj();
            var polja = b.DajPoljaZaBrod(Smjer.Horizontalno, new Polje(3, 6), 3);
            Assert.AreEqual(3, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(3,6)));
            Assert.IsTrue(polja.Contains(new Polje(3,7)));
            Assert.IsTrue(polja.Contains(new Polje(3,8)));
        }

        [TestMethod]
        public void Brodograditelj_DajPoljaZaBrodVraćaListuOd2VertikalnaPolja()
        {
            Brodograditelj b = new Brodograditelj();
            var polja = b.DajPoljaZaBrod(Smjer.Vertikalno, new Polje(3, 6), 2);
            Assert.AreEqual(2, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(3, 6)));
            Assert.IsTrue(polja.Contains(new Polje(4, 6)));
        }
    }
}
