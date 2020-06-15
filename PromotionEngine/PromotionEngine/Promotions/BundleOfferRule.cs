using PromotionEngine.Models;
using PromotionEngine.Promotions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Promotions
{
    public class BundleOfferRule : IPromotionRule
    {       
        public Order ApplyPromotion(Order order)
        {
            foreach (var prod in order.Cart.Products)
            {
                if(Eligible(prod))
                {
                    var itemCount = prod.ItemCount;
                    var bundleCount = prod.BundleOfferPromotions.BundleCount;

                    var p1 = itemCount / bundleCount;
                    var p2 = itemCount % bundleCount;

                    prod.ApplyOffer(p1 * prod.BundleOfferPromotions.BundleAmount + p2 * prod.Price);
                }           
            }
            
            return order;
        }

        static bool Eligible(Product product)
        {
            if (product.OfferApplied || product.BundleOfferPromotions == null) return false;
            return true;
        }        
    }
}
