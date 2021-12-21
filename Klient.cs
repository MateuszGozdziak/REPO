using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfficientBook
{
    internal class Klient
    {
        public int ID_Klienta { get; set; }
        public string Nazwa_Firmy { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int NIP { get; set; }
        public int Numer_Telefonu { get; set;}
        public string Email { get; set; }
        public string Adres { get; set; }
    }
}
