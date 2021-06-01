using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjautumis_Rekisterointi_Lomake
{
    public partial class Kirjautumis_Rekisterointi_Lomake : Form
    {
        public Kirjautumis_Rekisterointi_Lomake()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // näytetään kuva panelissa (suljetaan ja pienennetään)
            panel3.BackgroundImage = Image.FromFile("../../kuvat/Ylapalkki.png");
        }
        private void sulje_painike_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Pienenna_painike_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        // kun tämä timeri käynnistyy, näytämme vain rekisteröitymisosuuden
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(panel2.Location.X > -420)
            {
                panel2.Location = new Point(panel2.Location.X - 30, panel2.Location.Y);
            }
            else
            {
                timer1.Stop();
                mene_kirjautumiseen_label.Enabled = true;
                mene_rekisteroitymiseen_label.Enabled = true;

            }
        }
        // kun tämä timeri käynnistyy, näytämme vain kirjautumisosuuden
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.X < 0)
            {
                panel2.Location = new Point(panel2.Location.X + 30, panel2.Location.Y);
            }
            else
            {
                timer2.Stop();
                mene_kirjautumiseen_label.Enabled = true;
                mene_rekisteroitymiseen_label.Enabled = true;

            }
        }



        private void mene_kirjautumiseen_label_Click(object sender, EventArgs e)
        {
            timer2.Start();
            mene_rekisteroitymiseen_label.Enabled = false;
            mene_kirjautumiseen_label.Enabled = false;
        }

        private void mene_rekisteroitymiseen_label_Click(object sender, EventArgs e)
        {
            timer1.Start();
            mene_rekisteroitymiseen_label.Enabled = false;
            mene_kirjautumiseen_label.Enabled = false;
        }

        private void Selaa_kuvia_Click(object sender, EventArgs e)
        {
            // valitse ja näytä kuva kuvalaatikossa
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Valitse kuva(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if(opf.ShowDialog() == DialogResult.OK)
            {
                LT_kuvaboksi.Image = Image.FromFile(opf.FileName);
            }
        }

        private void rekisteroidy_nappi_Click(object sender, EventArgs e)
        {
            string etunimi = LT_etunimi_tekstiboksi.Text;
            string sukunimi = LT_sukunimi_tekstiboksi.Text;
            string kayttajatunnus = LT_kayttajatunnus_tekstiboksi.Text;
            string salasana = LT_salasana_tekstiboksi.Text;

            KAYTTAJA kayttaja = new KAYTTAJA(); 

            if(tarkastaKentat("rekisteroi"))
            {
                MemoryStream kuva = new MemoryStream();
                LT_kuvaboksi.Image.Save(kuva, LT_kuvaboksi.Image.RawFormat);

                // Meidän täytyy tarkastaa, onko käyttäjätunnus jo käytössä
                // Mikäli ei ole, lisäämme uuden käyttäjän tietokantaan
                // Tämän teemme KAYTTAJA-luokan avulla
                if (!kayttaja.kayttajatunnusOlemassa(kayttajatunnus))
                {
                    if (kayttaja.lisaaKayttaja(etunimi, sukunimi, kayttajatunnus, salasana, kuva))
                    {
                        MessageBox.Show("Rekisteröinti onnistui", "Rekisteröinti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Jotain meni pieleen", "Rekisteröinti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Tämä käyttäjätunnus on jo olemassa, kokeile jotain toista", "Epäkelpo käyttäjätunnus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("* Vaaditut kentät - Etunimi / Sukunimi / Käyttäjätunnus / Salasana", "Rekisteröinti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        // luodaan funktio, jolla tarkastetaan, onko tyhjiä kenttiä
        public bool tarkastaKentat(string toiminto)
        {
            bool tarkasta = false;
            if(toiminto == "rekisteroi")
            {
                if(LT_etunimi_tekstiboksi.Text.Equals("") || LT_sukunimi_tekstiboksi.Text.Equals("") || LT_kayttajatunnus_tekstiboksi.Equals("") || LT_salasana_tekstiboksi.Equals("") || LT_kuvaboksi.Image == null)
                {
                    tarkasta = false;
                }
                else
                {
                    tarkasta = true;
                }
            }
            else if(toiminto == "kirjaudu")
            {
                if(TK_kayttajatunnus_tekstiboksi.Equals("") || TK_salasana_tekstiboksi.Equals(""))
                {
                    tarkasta = false;
                }
                else
                {
                    tarkasta = true;
                }
            }
            return tarkasta;
        }
    }
}
