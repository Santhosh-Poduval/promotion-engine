using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public abstract class Promotion
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Rank { get; set; }
    }

    public class ComboOffer : Promotion
    {
        public Product Product { get; set; }
        public decimal ComboAmount { get; set; }
    }

    public class BundleOffer : Promotion
    {
        public int BundleCount { get; set; }
        public decimal BundleAmount { get; set; }
    }
}
