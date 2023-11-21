using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace salonlardapper.Models
{
    public class Malzemeclass
    {
        public int MalzemeNo { get; set; }
        public string MalzemeAdi { get; set; }
        public decimal MalzemeTutar { get; set; }
        public int HizmetNo { get; set; }
        public string Fayda { get; set; }
        public string Acıklama { get; set; }
    }
}