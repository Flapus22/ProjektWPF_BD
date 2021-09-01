using System;
using System.Collections.Generic;

#nullable disable

namespace ProjektWPF_BD.Model
{
    public partial class PozycjeZamówienium
    {
        public int Idzamówienia { get; set; }
        public int Idproduktu { get; set; }
        public decimal CenaJednostkowa { get; set; }
        public short Ilość { get; set; }
        public float Rabat { get; set; }
    }
}
