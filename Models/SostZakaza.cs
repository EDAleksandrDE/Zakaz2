using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SostZakaz.Name
{
    public class SostZakaza
    {
        public int SostZakazId { get; set; }

        [Required(ErrorMessage="Пожалуйста введите свое Арганизацию")]
        public string Name { get; set; }

        [Required(ErrorMessage="Вы должны указать хотя бы один адрес доставки")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage="Пожалуйста укажите город, куда нужно доставить заказ")]
        public string City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Dispatched { get; set; }

        private List<SostZakaza> sostZakaz;
        private List<SostZakaza> sostZakaza;

        public virtual List<SostZakaza> GetSostZakaz()
        {
            return sostZakaza;
        }

        public virtual void SetSostZakaz(List<SostZakaza> value)
        {
            sostZakaz = value;
        }
    }
    namespace SostZakaz.Name
    {
        public class SostZakaz
        {
            public int SostZakazId { get; set; }
            public SostZakaz Order { get; set; }
            public SostZakaz Zakaz { get; set; }
            public int Quantity { get; set; }
        }
    }
}