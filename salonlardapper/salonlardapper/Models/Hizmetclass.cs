using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace salonlardapper.Models
{
    public class Hizmetclass
    {
        public int HizmetNo { get; set; }
        public string HizmetAdi { get; set; }
        public string HizmetAmaci { get; set; }
        public decimal HizmetTutar { get; set; }
        public string OdemeTuru { get; set; }
        public int GorevliNo { get; set; }
    }
}