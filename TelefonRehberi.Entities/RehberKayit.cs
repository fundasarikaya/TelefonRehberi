using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Entities
{
   public  class RehberKayit
    {
        public Guid ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TelefonI { get; set; }
        public string TelefonII { get; set; }
        public string TelefonIII { get; set; }
        public string Adres { get; set; }
        public string  Email { get; set; }
        public string  WebSitesi { get; set; }
        public string Aciklama { get; set; }
        public override string ToString()
        {
            //override yapıyorum cunku listbox icerisine tip basacagim
            //tipi basınca namespace.class isimi gelmesin diye
            return $"{Isim} {Soyisim}";
        }
    }
}
