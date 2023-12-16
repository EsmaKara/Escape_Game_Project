﻿
using System;
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
        Dusen_Tuzak dsnTuzak;
        bool basladiMi;
        private int level;
        private int sayi;
        public AnaForm()
        {
            DoubleBuffered = true;
            InitializeComponent();

            karakter = new Karakter();
            zamanlayici = new Timer();
            oyun = new Oyun();
            blok = new Bloks();
            sbtTuzak = new Sabit_Tuzak();
            dsnTuzak = new Dusen_Tuzak();
            basladiMi = false;
            zamanlayici.Interval = 1000;

            sayi = 0;

            KeyDown += AnaForm_KeyDown;
            Paint += AnaForm_Paint;
            zamanlayici.Tick += Zamanlayici_Tick;
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            dsnTuzak.Hareket();
            Invalidate();
            sayi++;
            if(sayi % 3 == 0)
            {
                dsnTuzak.DusenTuzakOlustur();
            }
        }

        private void AnaForm_Paint(object sender, PaintEventArgs e)
        {
            if (level == 1)
            {
                if (basladiMi == true)
                {
                    sbtTuzak.SabitTuzakCiz(e.Graphics, karakter);
                    blok.BlokEkle(e.Graphics, level);
                    karakter.KarakterCiz(e.Graphics, karakter);
                }
                for (int i = 0; i < 10; i++)
                {
                    if (sbtTuzak.tuzaklar[i] != null)
                        if (karakter.X == sbtTuzak.tuzaklar[i].X && karakter.Y == sbtTuzak.tuzaklar[i].Y)
                        {
                            blok.BlokEkle(e.Graphics, level);
                            sbtTuzak.SabitTuzakGoster(e.Graphics, karakter);
                            karakter.KarakterCiz(e.Graphics, karakter);
                        }
                }
            }

            else if (level == 2)
            {
                blok.BlokEkle(e.Graphics, level);
                dsnTuzak.DusenTuzakCiz(e.Graphics, karakter);
                karakter.KarakterCiz(e.Graphics, karakter);
            }
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {

            }

            karakter.HareketEt(e);
            Invalidate();
            if (level == 1)
            {
                Invalidate();
                if (karakter.Can != 0)
                    sbtTuzak.CanAzalt(karakter);
                else
                {
                    zamanlayici = new Timer();
                    this.Controls.Clear();
                    karakter = new Karakter();
                    Invalidate();
                    sbtTuzak.SabitTuzakOlustur();
                }

                if (karakter.X == 880)
                {
                    zamanlayici.Stop();
                    zamanlayici.Enabled = false;
                    MessageBox.Show("Oh, you are recovering well.");
                    this.Controls.Clear();
                    karakter.Can += 1;
                    karakter.X = 80;
                    karakter.Y = 240;
                    level = 2;
                    Invalidate();
                }
            }
            if (level == 2)
            {
                Invalidate();
                if (karakter.Can != 0)
                    dsnTuzak.CanAzalt(karakter);
                else
                {
                    zamanlayici = new Timer();
                    this.Controls.Clear();
                    karakter = new Karakter();
                    level = 1;
                    Invalidate();
                    sbtTuzak.SabitTuzakOlustur();
                }
                Invalidate();
                if(karakter.X == 160)
                {
                    zamanlayici.Start();
                    zamanlayici.Enabled = true;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length != 0)
            {
                this.Controls.Clear();
                this.Text = "Can't Escape";
                zamanlayici.Start();
                zamanlayici.Enabled = true;
                basladiMi = true;
                level = 1;
                Invalidate();
                sbtTuzak.SabitTuzakOlustur();
            }
        }
    }
}
