using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Entities
{
    public class Kullanici
    {
        public Guid ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string  KullaniciSifre { get; set; }
    }
}
