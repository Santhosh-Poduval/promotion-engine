using PromotionEngine.Models;
using PromotionEngine.Promotions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.PromotionFactory.Interface
{
    public interface IPromotionOrchestrationFactory
    {
        Order GetPromotionRule(Order order);
    }
}
