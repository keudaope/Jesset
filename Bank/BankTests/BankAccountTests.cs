using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        // Vaadittu ominaisuus
        [TestMethod]
        // palautettava void, eli ei mit‰‰n, ja ei saa olla parametrej‰
        public void VeloitusSaldoaPienemmallaSummalla_SaldonPaivitys()
        {
            // Alustus
            double aloitusSaldo = 11.99;
            double veloitusSumma = 4.55;
            double odotusjaannos = 7.44;
            BankAccount tili = new BankAccount("Mr. Jyri Lindroos", aloitusSaldo);

            // Toiminta
            tili.Debit(veloitusSumma);

            // Oletuksen tarkastus
            double todellinen = tili.Balance;
            Assert.AreEqual(odotusjaannos, todellinen, 0.001, "Tili‰ ei veloitettu oikein");
        }

        [TestMethod]
        public void VeloitusNollaaPienemmallaSummalla_SaldonPaivitys()
        {
            // Alustus
            double aloitusSaldo = 11.99;
            double veloitusSumma = -100.00;
            BankAccount tili = new BankAccount("Mr. Jyri Lindroos", aloitusSaldo);

            // Toiminta ja oletuksen tarkastus
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => tili.Debit(veloitusSumma));
        }

        [TestMethod]
        public void VeloitusSaldoaSuuremmallaSummalla_SaldonPaivitys()
        {
            // Alustus
            double aloitusSaldo = 11.99;
            double veloitusSumma = 12.50;
            BankAccount tili = new BankAccount("Mr. Jyri Lindroos", aloitusSaldo);

            // Toiminta
            try
            {
                tili.Debit(veloitusSumma);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                // Oletuksen tarkastus
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("Oletettua tapahtumaa ei tapahtunut!");
        }


    }
}
