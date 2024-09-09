using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiG060
{
    internal class DersNotu
    {
        public string DersAdi;
        public float Not;
        public DersNotu(float not, string ders)
        {
            this.DersAdi = ders;
            this.Not = not;
        }
    }
}
