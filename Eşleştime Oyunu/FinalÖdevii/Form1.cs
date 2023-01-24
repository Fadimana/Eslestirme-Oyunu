using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace FinalÖdevii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image[] resimler =
        {
            Properties.Resources.mecnun,
            Properties.Resources.leyla,
            Properties.Resources.dede,
            Properties.Resources.iskender,
            Properties.Resources.ismail,
            Properties.Resources.erdal,
            Properties.Resources.indir,
            Properties.Resources.yavuz,
            Properties.Resources.arkaplan,


        };
        PictureBox ilkkutu;
        int ilkindeks, bulunan, deneme;

        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

        private void Form1_Load(object sender, EventArgs e)
        {
            resimlerikarıştır();
        }
        SoundPlayer player = new SoundPlayer();
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Start();

            player.SoundLocation = @"C:\Users\Dikici\Downloads\Leyla-ile-Mecnun-Jenerik-Main-Title.wav";
            player.Play();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            player.Stop();
            timer1.Stop();
        }

        private void resimlerikarıştır()
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int sayi = rnd.Next(16);//0 dan 15e rastgele değer atıycak
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo - 1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkindeks = indeksNo;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                ilkkutu.Image = Properties.Resources.arkaplan;
                kutu.Image = Properties.Resources.arkaplan;
                if (ilkindeks == indeksNo)
                {
                    bulunan++;
                    ilkkutu.Visible = false;//görünürlüğünü false yaptık
                    kutu.Visible = false;

                    if (bulunan == 8)
                    {
                        MessageBox.Show("TEBRİKLER HEPSİNİ " + deneme + " DENEMEDE BULDUN.");
                        bulunan = 0;
                        deneme = 0;
                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimlerikarıştır();
                    }

                }
                ilkkutu = null;
            }

        }
    }
    }

