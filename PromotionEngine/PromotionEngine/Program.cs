using PromotionEngine.Models;
using PromotionEngine.PromotionFactory;
using PromotionEngine.PromotionFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Program
    {
        protected static void Main(string[] args)
        {
            //Need DI Here....Not implememetd due to lack of time
           var promotionRuleFactory = new PromotionOrchestrationFactory();         
           var order = GetOrder();
           var products = GetProducts();

           order = promotionRuleFactory.GetPromotionRule(order);
           order.CalculateTotalAmount();

           Console.Write(order.Amount);
        }
        
        static Order GetOrder()
        {
            var products = GetProducts();
            var cart = new Cart { Products = products };
            var order = new Order
            {
                Cart = cart
            };

            return order;
        }
        static IList<Product> GetProducts()
        {
            var products = new List<Product>();

            var productA = new Product
            {
                Sku = 'A',
                Price = 50,
                BundleOfferPromotions = new BundleOffer
                {
                    Name = "Bundle A",
                    BundleCount = 3,
                    BundleAmount = 130,
                    Description = "Bundle A",
                    Category = "Bundle Offer"
                },
                ItemCount = 10
            };

            var productB = new Product
            {
                Sku = 'B',
                Price = 30,
                BundleOfferPromotions = new BundleOffer
                {
                    Name = "Bundle B",
                    BundleCount = 2,
                    BundleAmount = 45,
                    Description = "Bundle B",
                    Category = "Bundle Offer"
                },
                ItemCount = 10
            };

            var productC = new Product
            {
                Sku = 'C',
                Price = 20,
                ItemCount = 10
            };

            var comboOfferPromotionsD = new List<ComboOffer>();

            var comboC = new ComboOffer
            {
                Product = productC,
                ComboAmount = 30,
                Category = "combo offer"
            };

            comboOfferPromotionsD.Add(comboC);

            var productD = new Product
            {
                Sku = 'D',
                Price = 15,
                ComboOfferPromotions = comboOfferPromotionsD,
                ItemCount = 10
            };

            var comboOfferPromotionsC = new List<ComboOffer>();

            var comboD = new ComboOffer
            {
                Product = productD,
                ComboAmount = 30,
                Category = "combo offer"
            };

            comboOfferPromotionsC.Add(comboC);

            productC.ComboOfferPromotions = comboOfferPromotionsC;

            products.Add(productA);
            products.Add(productB);
            products.Add(productC);
            products.Add(productD);

            return products;
        }              
    }
}
