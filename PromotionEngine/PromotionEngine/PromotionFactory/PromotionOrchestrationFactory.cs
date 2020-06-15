using PromotionEngine.Models;
using PromotionEngine.PromotionFactory.Interface;
using PromotionEngine.Promotions;
using PromotionEngine.Promotions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.PromotionFactory
{
    public class PromotionOrchestrationFactory : IPromotionOrchestrationFactory
    {
        public Order GetPromotionRule(Order order)
        {
            //DI here
            order = new BundleOfferRule().ApplyPromotion(order);
            order = new ComboOfferRule().ApplyPromotion(order);
           
            return order;
        }
    }
}
