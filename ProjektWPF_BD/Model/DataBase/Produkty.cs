using System;
using System.Collections.Generic;

#nullable disable

namespace ProjektWPF_BD.Model
{
    public partial class Produkty
    {
        public int Idproduktu { get; set; }
        public string NazwaProduktu { get; set; }
        public int? Iddostawcy { get; set; }
        public int? Idkategorii { get; set; }
        public string IlośćJednostkowa { get; set; }
        public decimal? CenaJednostkowa { get; set; }
        public short? StanMagazynu { get; set; }
        public short? IlośćZamówiona { get; set; }
        public short? StanMinimum { get; set; }
        public bool Wycofany { get; set; }
    }
}
