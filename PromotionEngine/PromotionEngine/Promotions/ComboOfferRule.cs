using PromotionEngine.Models;
using PromotionEngine.Promotions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Promotions
{
    public class ComboOfferRule : IPromotionRule
    {
        public Order ApplyPromotion(Order order)
        {
            foreach (var prod in order.Cart.Products)
            {
                if (Eligible(prod))
                {
                    foreach (var comboOffer in prod.ComboOfferPromotions)
                    {
                        var comboProduct = order.Cart.Products.FirstOrDefault(x => x.Sku == comboOffer.Product.Sku);

                        var min = comboProduct.ItemCount > prod.ItemCount ? prod.ItemCount : comboProduct.ItemCount;

                        var rem = prod.ItemCount - min;

                        if (comboProduct != null)                        
                            prod.ApplyOffer((min * (comboOffer.ComboAmount / 2)) + (rem * prod.Price));                        
                    }
                }
            }

            return order;
        }

        static bool Eligible(Product product)
        {
            if (product.OfferApplied || product.ComboOfferPromotions ==null) return false;
            return true;
        }
    }
}
