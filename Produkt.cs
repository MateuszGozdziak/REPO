using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfficientBook
{
    public class Produkt
    {
        public int Cena_Brutto { get; set; }
        public int Cena_Netto { get; set; }
        public int Id_Produktu { get; set; }
        public int Ilosc_Dostepnych { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string Marka { get; set; }
        public int Vat { get; set; }

    }
}
