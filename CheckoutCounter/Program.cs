using CheckoutCounter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CheckoutCounter
{
    class Program
    {

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            //var promotionRules = new List<PromotionRuleBase<PromotionRuleSettingBase>>();

            //var buy2AndGet1Free = new BuyXAndGetYFreePromotionRule<BuyXAndGetYFreePromotionRuleSetting>(new BuyXAndGetYFreePromotionRuleSetting()
            //{
            //    Id = 1,
            //    Name = "買二送一唷",
            //    BuyX = 2,
            //    GetYFree = 1
            //});

            //promotionRules.Add(buy2AndGet1Free);


            var promotionRules = new List<PromotionRuleBase>();

            var buy2AndGet1Free = new BuyXAndGetYFreePromotionRule(new BuyXAndGetYFreePromotionRuleSetting()
            {
                Id = 1,
                Name = "買二送一唷",
                BuyX = 2,
                GetYFree = 1
            });

            promotionRules.Add(buy2AndGet1Free);


            var cart = new Cart();
            cart.Add(LoadProducts());

            var checkoutService = new CheckoutService(promotionRules);
            checkoutService.Checkout(cart);

        }

        static IEnumerable<Product> LoadProducts()
        {
            return JsonConvert.DeserializeObject<Product[]>(File.ReadAllText(@"products.json"));
        }
    }
}
