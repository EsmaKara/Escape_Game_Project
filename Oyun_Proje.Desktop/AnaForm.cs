using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace Oyun_Proje.Desktop
{
    public partial class AnaForm : Form
    {
        Bloks blok;
        Karakter karakter;
        Timer zamanlayici;
        Oyun oyun;
        Sabit_Tuzak sbtTuzak;
        bool basladiMi;
        public AnaForm()
        {
            DoubleBuffered = true;
            InitializeComponent();

            karakter = new Karakter();
            zamanlayici = new Timer();
            oyun = new Oyun();
            blok = new Bloks();
            sbtTuzak = new Sabit_Tuzak();
            basladiMi = false;

            KeyDown += AnaForm_KeyDown;
            Paint += AnaForm_Paint;
            zamanlayici.Tick += Zamanlayici_Tick;
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            
        }

        private void AnaForm_Paint(object sender, PaintEventArgs e)
        {

            if (basladiMi == true)
            {
                sbtTuzak.SabitTuzakCiz(e.Graphics, karakter);
                blok.BlokEkle(e.Graphics);
                karakter.KarakterCiz(e.Graphics);
            }
            for (int i = 0; i < 10; i++)
            {
                if (sbtTuzak.tuzaklar[i] != null)
                    if (karakter.X == sbtTuzak.tuzaklar[i].X && karakter.Y == sbtTuzak.tuzaklar[i].Y)
                    {
                        blok.BlokEkle(e.Graphics);
                        sbtTuzak.SabitTuzakGoster(e.Graphics, karakter);
                        karakter.KarakterCiz(e.Graphics);
                    }
            }
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            karakter.HareketEt(e);
            if(e.KeyCode == Keys.P)
            {

            }
            Invalidate();
            if(karakter.Can != 0)
                sbtTuzak.CanAzalt(karakter);
            else
            {
                zamanlayici.Stop();
                this.Controls.Clear();
                karakter = new Karakter();
                Invalidate();
                sbtTuzak.SabitTuzakOlustur();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length != 0)
            {
                this.Controls.Clear();
                zamanlayici.Start();
                basladiMi = true;
                Invalidate();
                sbtTuzak.SabitTuzakOlustur();
            }
        }
    }
}
