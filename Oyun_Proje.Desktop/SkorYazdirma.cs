using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    internal class SkorYazdirma
    {
        public static List<Label> labelListe = new List<Label>();

        private static Label[] lblAd = new Label[5];
        private static Label[] lblPuan = new Label[5];

        private static string[] isimDizisi = new string[5];
        private static int[] puanDizisi = { 0, 0, 0, 0, 0 };

        public static List<Label> Yazdir(string isim, int puan)
        {
            for (int i = 0; i < 5; i++)
            {
                lblAd[i] = new Label();
                lblPuan[i] = new Label();   
                lblAd[i].Location = new Point(20, 60);
                lblAd[i].ForeColor = Color.Black;
                lblPuan[i].Location = new Point(210, 60);
                lblPuan[i].ForeColor = Color.Black;
            }
            

            for (int i = 0; i < 5; i++)
            {
                if (puan > puanDizisi[i])
                {
                    puanDizisi[i] = puan;
                    isimDizisi[i] = isim;
                    break;
                }
            }
            for (int j = 0; j < isimDizisi.Length; j++)
            {
                if (isimDizisi[j] != null)
                {
                    lblAd[j].Text = (j + 1) + ")           " + isimDizisi[j] + "\n";
                    lblPuan[j].Text = Convert.ToString(puanDizisi[j]) + "\n";

                    labelListe.Add(lblAd[j]);
                    labelListe.Add(lblPuan[j]);
                }
            }

            return labelListe;
        }

    }
}
