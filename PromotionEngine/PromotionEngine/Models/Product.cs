using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Product
    {
        public char Sku { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get;  set; }
        public int ItemCount { get; set; }
        public bool OfferApplied { get;  set; }
        public IList<ComboOffer> ComboOfferPromotions { get; set; }
        public BundleOffer BundleOfferPromotions { get; set; }

        public void ApplyOffer(decimal totalPrice)
        {
            OfferApplied = true;
            TotalPrice = totalPrice;
        }
    }
}
