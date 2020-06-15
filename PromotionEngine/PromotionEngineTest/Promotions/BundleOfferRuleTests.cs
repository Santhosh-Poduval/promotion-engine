using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Models;
using PromotionEngine.Promotions;
using System.Collections.Generic;

namespace PromotionEngineTest.Promotions
{
    [TestClass]
   public class BundleOfferRuleTests
    {
        readonly BundleOfferRule bundleOfferRule;

        public BundleOfferRuleTests()
        {
            bundleOfferRule = new BundleOfferRule();
        }

        //Implement test case to check interface implemnted or not
        //[TestMethod]
        //public void Is_Interface_Implement()
        //{
        //}

        [TestMethod]
        public void  Apply_Offer_With_Same_Product_Eligible_Combo_And_Not()
        {

            var order = new Order
            {
                Cart = new Cart
                {
                    Products = new List<Product>
                    {
                        new Product
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
                          }
                    }
                }
            };

            var u_Order = bundleOfferRule.ApplyPromotion(order);
            u_Order.CalculateTotalAmount();

            Assert.AreEqual(440, u_Order.Amount);
        }

        [TestMethod]
        public void Do_Not_Apply_Offer_With_Products_Already_Offer_Applied()
        {

            var order = new Order
            {
                Cart = new Cart
                {
                    Products = new List<Product>
                    {
                        new Product
                          {
                                Sku = 'B',
                                Price = 50,
                                BundleOfferPromotions = new BundleOffer
                                     {
                                            Name = "Bundle B",
                                            BundleCount = 3,
                                            BundleAmount = 130,
                                            Description = "Bundle B",
                                            Category = "Bundle Offer"
                                        },

                              ItemCount = 10,
                              OfferApplied =true,
                              TotalPrice = 400
                          },
                        new Product
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
                          }
                    }
                }
            };

            var u_Order = bundleOfferRule.ApplyPromotion(order);
            u_Order.CalculateTotalAmount();

            Assert.AreEqual(840, u_Order.Amount);
        }

        [TestMethod]
        public void Do_Not_Apply_Offer_With_Products_With_BundleOfferPromotions_Is_Null()
        {

            var order = new Order
            {
                Cart = new Cart
                {
                    Products = new List<Product>
                    {
                        new Product
                          {
                                Sku = 'B',
                                Price = 50,
                                ItemCount = 10
                          },
                        new Product
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
                          }
                    }
                }
            };

            var u_Order = bundleOfferRule.ApplyPromotion(order);
            u_Order.CalculateTotalAmount();

            Assert.AreEqual(940, u_Order.Amount);
        }
        
    }
}
