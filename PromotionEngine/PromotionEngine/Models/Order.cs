using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Order
    {
        public Cart Cart { get; set; }
        public Promotion AppliedPromotion { get; set; }
        public Int32 Discount { get; set; }
        public decimal TotalAmount { get; private set; }
        public decimal Amount { get; private set; }

        public void CalculateTotalAmount() {

            this.Amount = Cart.Products.Where(x => !x.OfferApplied).Sum(x => x.ItemCount*x.Price) +
                 Cart.Products.Where(x => x.OfferApplied).Sum(x => x.TotalPrice);
        }
    }
}
