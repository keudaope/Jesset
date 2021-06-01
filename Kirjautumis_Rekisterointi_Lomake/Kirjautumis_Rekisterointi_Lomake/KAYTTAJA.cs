using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Kirjautumis_Rekisterointi_Lomake
{
    class KAYTTAJA
    {
        Tietokantani tietokanta = new Tietokantani();
        // funktio, jolla tarkastetaan olemassa oleva käyttäjätunnus
        public bool kayttajatunnusOlemassa(string kayttajatunnus)
        {
            // Tehdään tietokantakyselylauseke: Valitaan kaikki kentät kayttaja-taulukosta, jossa kayttajatunnus
            // vastaa annettua arvoa
            string kysely = "SELECT * FROM `kayttaja` WHERE `kayttajatunnus` = @kt";
            // Yhdistetään kysely tietokantayhteyteen ja tämä kokonaisuus MySqlKomentomuuttujaan komento
            MySqlCommand komento = new MySqlCommand(kysely, tietokanta.yhdista);
            // Lisätään tuohon kyselyyn @kt:n tilalle funktiolle annettu muuttuja
            komento.Parameters.Add("@kt", MySqlDbType.VarChar).Value = kayttajatunnus;
            // Yhdistetään tuo komento MySql adapteriin
            MySqlDataAdapter adapteri = new MySqlDataAdapter(komento);
            // Tehdään taulukkomuuttuja
            DataTable taulukko = new DataTable();
            // Täytetään tuo taulukkomuuttuja edellisen adapterin tuloksella (siis kyselyn vastauksella)
            adapteri.Fill(taulukko);
            // Mikäli vastauksia tulee, se tarkoittaa, että käyttäjä on olemassa, joka on paha juttu
            if(taulukko.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Lisätään uusi käyttäjä lomakkeelta saaduilla arvoilla, jotka on tarkastettu, että eivät ole tyhjiä
        public bool lisaaKayttaja(string enimi, string snimi, string ktunnus, string ssana, MemoryStream kuva)
        {
            // Tehdään tietokantakysely, tällä kertaa siis lisäyskysely
            MySqlCommand komento = new MySqlCommand("INSERT INTO `kayttaja` (`etunimi`,`sukunimi`,`kayttajatunnus`,`salasana`,`kuva`) VALUES (@en, @sn, @kt, @ss, @kv)", tietokanta.yhdista);
            // Lisätään taas tuohon komentomuuttujaan @-muuttujien tilalle funktiolle annetut arvot.
            komento.Parameters.Add("@en", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@sn", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@kt", MySqlDbType.VarChar).Value = ktunnus;
            komento.Parameters.Add("@ss", MySqlDbType.VarChar).Value = ssana;
            komento.Parameters.Add("@kv", MySqlDbType.Blob).Value = kuva.ToArray();
            // Avataan tietokantayhteys
            tietokanta.avaaYhteys();
            // Suoritetaan komento
            if(komento.ExecuteNonQuery() == 1)
            {
                tietokanta.suljeYhteys();
                return true;
            }
            else
            {
                tietokanta.suljeYhteys();
                return false;
            }

        }

    }
}
