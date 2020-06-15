using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Promotions.Interfaces
{
    public interface IPromotionRule
    {
        Order ApplyPromotion(Order order);
    }
}
