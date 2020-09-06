using System;
using System.Collections.Generic;
using System.Text;
using CheckoutCounter.Models;
using System.Linq;

namespace CheckoutCounter
{
    /// <summary>
    /// 1. 計算要結帳的商品原價總金額 (未折扣)
    /// 2. 逐一確認每個折扣規則可以折抵的金額
    /// 3. 未折扣總金額 - 所有可折抵的金額 = 最後結帳的價格
    /// 4. 執行後續收款以及成立訂單或列印發票收據等等流程.
    /// </summary>
    public class CheckoutService
    {
        //private IEnumerable<PromotionRuleBase<PromotionRuleSettingBase>> _promotionRules;
        //private CartContext _cartContext;

        //public CheckoutService(IEnumerable<PromotionRuleBase<PromotionRuleSettingBase>> promotionRules)
        //{
        //    _promotionRules = promotionRules;
        //}

        private IEnumerable<PromotionRuleBase> _promotionRules;
        private CartContext _cartContext;

        public CheckoutService(IEnumerable<PromotionRuleBase> promotionRules)
        {
            _promotionRules = promotionRules;
        }



        public void Checkout(Cart cart)
        {
            _cartContext = new CartContext(cart);

            PrintProducts();

            var promotions = ProcessPromotion();

            var billAmount = _cartContext.Products.Sum(x => x.Price) - promotions.Sum(x => x.BonusAmount);







        }


        private void PrintProducts()
        {
            decimal sum = 0m;

            foreach (var product in _cartContext.Products)
            {
                Console.WriteLine($"- {product.Name}      {product.Price:C}");
                sum += product.Price;
            }

            Console.WriteLine($"Total: {sum:C}");
        }

        private IEnumerable<Promotion> ProcessPromotion()
        {
            if (!_cartContext.Products.Any() || _promotionRules == null || !_promotionRules.Any())
            {
                return Enumerable.Empty<Promotion>();
            }

            var promotions = new List<Promotion>();
            foreach (var promotionRule in _promotionRules)
            {
                promotions.AddRange(promotionRule.Process(_cartContext.Products));
            }

            return promotions.AsEnumerable();
        }

    }



    public class CartContext
    {
        private Cart _cart;

        public IEnumerable<Product> Products { get; set; }

        public CartContext(Cart cart)
        {
            _cart = cart;
            Products = cart.GetProductsCopy();
        }

    }

}
