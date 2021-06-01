using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
// Meidän täytyy lisätä MySQL Connector, jotta saadaan yhteys MySQL-tietokantaan. Se voidaan hakea MySQL:n sivustolta
// laittamalla Googleen hakusana MySQL Connector NET ja sen jälkeen ajettava ladattu asennusohjelma (mysql-connector-net-8.xxx.xxxx.exe)
// ja napauttamalla oikeanpuoleisella hiirellä tuolta oikealta References-kohtaa ja valitsemalla "Add References..." ja sinne kirjoittamalla oikealle 
// ylhäälle hakukenttään MySql ja sen jälkeen valitsemalla MySQL.Data. Tämän jälkeen otetaan se käyttöön:
using MySql.Data.MySqlClient;
// Nyt voimme käyttää esim. Xamppia ja sillä käynnistää MySQL-palvelin
namespace Kirjautumis_Rekisterointi_Lomake
{
    class Tietokantani
    {
        // varsinainen yhteys
        MySqlConnection yhteys = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=KRLomake");

        // palautetaan yhteys
        public MySqlConnection yhdista
        {
            get
            {
                return yhteys;
            }
        }

        // avaa yhteys
        public void avaaYhteys()
        {
            if(yhteys.State == ConnectionState.Closed)
            {
                yhteys.Open();
            }
        }

        // sulje yhteys
        public void suljeYhteys()
        {
            if (yhteys.State == ConnectionState.Open)
            {
                yhteys.Close();
            }
        }
    }
}
