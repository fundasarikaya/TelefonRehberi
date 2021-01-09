using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities;

namespace TelefonRehberi.BLL
{
    public class BusinessLogicLayer
    {
        TelefonRehberi.Core.DatabaseLogicLayer DLL;
        //bll üzerinde işlemler yapılır data alıp verebilmesi icin dll cagırılmalı
        public BusinessLogicLayer()
        {
            //bll cagıran aynı zamanda dll cagırmış olsun diye new yapıyoruz
            DLL = new Core.DatabaseLogicLayer();
        }
        public int KullaniciKontrol(string KullaniciAdi,string KullaniciSifre)
        {
            int Sonuc = 0;
            if(!string.IsNullOrEmpty(KullaniciAdi)&&!string.IsNullOrEmpty(KullaniciSifre))
            {
                Kullanici kullanici = new Kullanici();
                kullanici.KullaniciAdi = KullaniciAdi;
                kullanici.KullaniciSifre = KullaniciSifre;
                Sonuc = DLL.KullaniciKontrol(kullanici);
            }
            else
            {
                Sonuc = -100;//eksik parametre hatası
            }
            return Sonuc;
        }
        public int YeniKayit(Guid ID,string Isim,string Soyisim,string TelefonI,string TelefonII,string TelefonIII,string Adres,string Email,string WebSitesi,string Aciklama)
        //aynı ismi veriyoruzki karışıklık olmasın//user interfaceden gelecegi icin parametre olarak giriyoruz
        {
            //datamızı iceriye parcalı olarak aldık
            int Sonuc = 0;
            if(ID!=Guid.Empty&&!string.IsNullOrEmpty(Isim)&&!string.IsNullOrEmpty(Soyisim)&&!string.IsNullOrEmpty(TelefonI))//bunlar dolu olmak zorunda
            {
                RehberKayit Kayit = new RehberKayit(); //dll e gondermek icin
                Kayit.ID = ID;
                Kayit.Isim = Isim;
                Kayit.Soyisim = Soyisim;
                Kayit.TelefonI = TelefonI;
                Kayit.TelefonII = TelefonII;
                Kayit.TelefonIII = TelefonIII;
                Kayit.Adres = Adres;
                Kayit.Email = Email;
                Kayit.WebSitesi = WebSitesi;
                Kayit.Aciklama = Aciklama;

                Sonuc= DLL.YeniKayit(Kayit);
            }
            else
            {
                Sonuc = -100;//eksik parametre hatası
            }
            return Sonuc;
        }

    }
}
