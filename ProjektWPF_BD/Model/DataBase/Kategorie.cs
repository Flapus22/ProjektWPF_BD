using System;
using System.Collections.Generic;

#nullable disable

namespace ProjektWPF_BD.Model
{
    public partial class Kategorie
    {
        public int Idkategorii { get; set; }
        public string NazwaKategorii { get; set; }
        public string Opis { get; set; }
        public byte[] Rysunek { get; set; }
    }
}
