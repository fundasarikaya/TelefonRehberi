using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities;

namespace TelefonRehberi.Core
{
    public class DatabaseLogicLayer
    {
        List<RehberKayit> Kayitlarim;
        public DatabaseLogicLayer()
        {
            Kayitlarim = new List<RehberKayit>();
            VeriTabaniKontrol();
        }

        private void VeriTabaniKontrol()
        {
            bool KlasorKontrol = Directory.Exists(@"C:\TelefonRehberiDB");
            if(!KlasorKontrol)
            {
                Directory.CreateDirectory(@"C:\Users\Funda\Desktop\Telefon Rehberi\TelefonRehberiDB");
                Kullanici Demo = new Kullanici();
                Demo.ID = Guid.NewGuid();
                Demo.KullaniciAdi = "Demo";
                Demo.KullaniciSifre = "Demo";

                List<Kullanici> kullanicilarim = new List<Kullanici>();
                kullanicilarim.Add(Demo);

                string JsonKullaniciText = Newtonsoft.Json.JsonConvert.SerializeObject(kullanicilarim);
                File.WriteAllText(@"C:\Users\Funda\Desktop\Telefon Rehberi\TelefonRehberiDB\kullanici.json",JsonKullaniciText);

            }
        }

        public int YeniKayit(RehberKayit K)
        {
            int Sonuc = 0;
            try
            {
                RehberKayitlariGetir();//list<rehberkayita> veri varsa onu doldurmuş oluruz yoksa bellekte hic bir degeri yoktu o sekilde yeni deger eklemek üzere bekler
                Kayitlarim.Add(K); //data kontrolu bu katmanda yapılmaz buraya data temiz geldi kabul edilri
                JsonDBGuncelle();//var ise üzerine yazar yoksa yeni json oluşturur
            }
            catch (Exception ex)
            {
                Sonuc = 0;
            }
            return Sonuc;
        }
        public List<RehberKayit> RehberKayitlariGetir()
        {
            if(File.Exists(@"C:\Users\Funda\Desktop\Telefon Rehberi\TelefonRehberiDB\rehber.json"))
            {
             string JsonDBText=File.ReadAllText(@"C:\Users\Funda\Desktop\Telefon Rehberi\TelefonRehberiDB\rehber.json");
                Kayitlarim = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RehberKayit>>(JsonDBText);
                //listrehberkayita cevir jsondbtexti

            }
            return Kayitlarim;
        }
        public int KullaniciKontrol(Kullanici kullanici)
        {
            int KullaniciSonuc = 0;
            if(File.Exists(@"C:\Users\Funda\Desktop\Telefon Rehberi\TelefonRehberiDB\kullanici.json"))
            {
                string JsonKullaniciText = File.ReadAllText(@"C:\Users\Funda\Desktop\Telefon Rehberi\TelefonRehberiDB\kullanici.json");
                //bu datayı bir texte cevir dedik
                List<Kullanici> kullanicilar = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kullanici>>(JsonKullaniciText);
                //o texti kullanici listesine at
                KullaniciSonuc = kullanicilar.FindAll(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.KullaniciSifre == kullanici.KullaniciSifre).ToList().Count();
                
            }
            return KullaniciSonuc;
        }
        #region Yardimci Metotlar
        private void JsonDBGuncelle()
        {
            if (Kayitlarim != null && Kayitlarim.Count > 0)
            {
                string JsonDB = Newtonsoft.Json.JsonConvert.SerializeObject(Kayitlarim);
                //jsona cevirdik.
                File.WriteAllText(@"C:\Users\Funda\Desktop\Telefon Rehberi\TelefonRehberiDB\rehber.json",JsonDB);
                //varsa override yapar yoksa oluşturur.
                
            }
        }
        #endregion
    }
}

//21.11   214.video
