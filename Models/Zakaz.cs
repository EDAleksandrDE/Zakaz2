using System.Collections.Generic;
using System.Linq;

namespace Zakaz.Name
{
    public class Zakaz
    {
        private List<ZakaztLine> lineCollection = new List<ZakaztLine>();

        public void AddItem(Zakaz zakaz, int quantity)
        {
            ZakaztLine line = lineCollection
                .Where(p => p.Zakaz.ZakazId == Zakaz.ZakazId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(NewMethod(quantity));
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        private static ZakaztLine NewMethod(int quantity)
        {
            return new ZakaztLine
            {
                Zakaz = Zakaz,
                Quantity = quantity
            };
        }

        public void RemoveLine(Zakaz game)
        {
            lineCollection.RemoveAll(l => l.Zakaz.ZakazId == game.ZakazId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Zakaz.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<ZakaztLine> Lines
        {
            get { return lineCollection; }
        }

        public int ZakazId { get; private set; }
    }

    public class ZakaztLine
    {
        public Game Zakaz { get; set; }
        public int Quantity { get; set; }
    }
}
