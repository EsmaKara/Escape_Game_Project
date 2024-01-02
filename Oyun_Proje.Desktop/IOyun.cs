
/*
                Öğrenci Bilgileri
-------------------------------------------------
  Nesneye Dayalı Programlama Dersi Proje Ödevi

 İsim: Esma KARA
 Numara: B221200007
 Mail: esma.kara4@ogr.sakarya.edu.tr

 Bölüm: Bilişim Sistemleri Mühendisliği /2.sınıf
-------------------------------------------------

 */

using System.Drawing;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    interface IOyun
    {
        // oyun sınıfı için bulundurmasını zorunlu kıldığım fonksiyonlar

        void OyunuYazdir(Graphics ciz, Tuzaklar nesne, Karakter karakter, Surpriz_Kutu srpzKutu, int level);

        void PanelEkranaYazdir(string isim, int level, Karakter karakter, int zamanlayici);

        int PuanHesapla(Karakter karakter, int sayi);

        void HikayeyiGoster(Graphics ciz);

    }
}
