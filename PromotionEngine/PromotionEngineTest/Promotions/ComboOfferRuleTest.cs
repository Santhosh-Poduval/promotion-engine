using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Models;
using PromotionEngine.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineTest.Promotions
{

    [TestClass]
    public class ComboOfferRuleTest
    {
        readonly ComboOfferRule comboOfferRule;

        public ComboOfferRuleTest()
        {
            comboOfferRule = new ComboOfferRule();
        }

        //Implement test case to check interface implemnted or not
        //[TestMethod]
        //public void Is_Interface_Implement()
        //{
        //}

        [TestMethod]
        public void Apply_Offer_With_Products_Eligible_Combo_And_Not()
        {

            var order = GetOrder();

            var u_Order = comboOfferRule.ApplyPromotion(order);
            u_Order.CalculateTotalAmount();

            Assert.AreEqual(800, u_Order.Amount);
        }
        [TestMethod]
        public void Apply_Offer_With_Products_Eligible_Combo_But_Different_ItemCount()
        {
            var order = GetOrder();
            order.Cart.Products[2].ItemCount = 5;

            var u_Order = comboOfferRule.ApplyPromotion(order);
            u_Order.CalculateTotalAmount();

            Assert.AreEqual(750, u_Order.Amount);
        }

        [TestMethod]
        public void Do_Not_Apply_Offer_With_Products_Already_Offer_Applied()
        {
            var order = GetOrder();
            order.Cart.Products[1].ApplyOffer(50);

            var u_Order = comboOfferRule.ApplyPromotion(order);
            u_Order.CalculateTotalAmount();

            Assert.AreEqual(700, u_Order.Amount);
        }

        [TestMethod]
        public void Do_Not_Apply_Offer_With_Products_With_CombpOfferPromotions_Is_Null()
        {
            var order = GetOrder();
            order.Cart.Products[1].ComboOfferPromotions = null;

            var u_Order = comboOfferRule.ApplyPromotion(order);
            u_Order.CalculateTotalAmount();

            Assert.AreEqual(850, u_Order.Amount);
        }

        public static Order GetOrder()
        {
           var products = GetProducts();
           var cart = new Cart { Products = products };
           var order = new Order
             {
                 Cart = cart
             };

             return order;
        }
        public static IList<Product> GetProducts()
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

                comboOfferPromotionsC.Add(comboD);

                productC.ComboOfferPromotions = comboOfferPromotionsC;

                products.Add(productA);
                products.Add(productC);
                products.Add(productD);

                return products;
        }              
    }
}
