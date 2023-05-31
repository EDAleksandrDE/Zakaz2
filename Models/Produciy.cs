using System;

namespace Zakaz.Name
{
    public class Game
    {
        public int ZakazId { get; set; }
        public string NameORG { get; set; }
        public string Adres { get; set; }
        public string NomerTEL { get; set; }
        public int SostZakazId { get; internal set; }
    }
}