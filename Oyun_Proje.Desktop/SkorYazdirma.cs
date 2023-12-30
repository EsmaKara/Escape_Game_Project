using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    internal class SkorYazdirma
    {
        public static List<Label> labelListe = new List<Label>();
        private static StreamWriter sw = new StreamWriter("D:\\Kodlar\\CSharp\\Oyun_Proje\\Oyun_Proje.Desktop\\Top5.txt", false, Encoding.ASCII);
        private static StreamReader sr = new StreamReader("D:\\Kodlar\\CSharp\\Oyun_Proje\\Oyun_Proje.Desktop\\Top5.txt");

        private static Label[] lblSira = new Label[5];

        private static string[] isimDizisi = new string[5];
        private static int[] puanDizisi = { 0, 0, 0, 0, 0 };

        public static List<Label> Yazdir(string isim, int puan)
        {
            for (int i = 0; i < 5; i++)
            {
                lblSira[i] = new Label();   
                lblSira[i].Location = new Point(20, 60);
                lblSira[i].ForeColor = Color.Black;
                lblSira[i].Size = new Size(70, 100);
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
                    sw.Write((j + 1) + ")           " + isimDizisi[j] + "\t \t \t" + Convert.ToString(puanDizisi[j]) + "\n");
                    lblSira[j].Text = sr.ReadLine();

                    labelListe.Add(lblSira[j]);
                }
            }
            sw.Close();

            return labelListe;
        }

    }
}
