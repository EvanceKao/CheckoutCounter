using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutCounter.Models
{
    //public class BuyXAndGetYFreePromotionRule<TSetting> : PromotionRuleBase<TSetting> where TSetting : BuyXAndGetYFreePromotionRuleSetting
    //{
    //    public BuyXAndGetYFreePromotionRule(TSetting setting) : base(setting)
    //    {
    //    }

    //    public override IEnumerable<Promotion> Process(IEnumerable<Product> products)
    //    {
    //        var countPerGroup = _setting.BuyX + _setting.GetYFree;
    //        var promotions = new List<Promotion>();
    //        var dict = new Dictionary<int, int>();

    //        foreach (var product in products)
    //        {
    //            if (dict.ContainsKey(product.Id))
    //            {
    //                dict[product.Id]++;

    //                if (dict[product.Id] == countPerGroup)
    //                {
    //                    promotions.Add(new Promotion()
    //                    {
    //                        Name = _setting.Name,
    //                        Description = $"商品 [{product.Name}] 買 {_setting.BuyX} 送 {_setting.GetYFree}  {(_setting.CanGetBonusRepeatedly ? string.Empty : "* 每筆交易僅優惠一次")}",
    //                        BonusAmount = product.Price * (decimal)_setting.GetYFree
    //                    });

    //                    if (_setting.CanGetBonusRepeatedly)
    //                    {
    //                        dict.Remove(product.Id);
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                dict[product.Id] = 1;
    //            }
    //        }

    //        return promotions;
    //    }
    //}

    public class BuyXAndGetYFreePromotionRule : PromotionRuleBase
    {
        public BuyXAndGetYFreePromotionRule(BuyXAndGetYFreePromotionRuleSetting setting) : base(setting)
        {
        }

        public override IEnumerable<Promotion> Process(IEnumerable<Product> products)
        {
            var setting = _setting as BuyXAndGetYFreePromotionRuleSetting;

            var countPerGroup = setting.BuyX + setting.GetYFree;
            var promotions = new List<Promotion>();
            var dict = new Dictionary<int, int>();

            foreach (var product in products)
            {
                if (dict.ContainsKey(product.Id))
                {
                    dict[product.Id]++;

                    if (dict[product.Id] == countPerGroup)
                    {
                        promotions.Add(new Promotion()
                        {
                            Name = _setting.Name,
                            Description = $"商品 [{product.Name}] 買 {setting.BuyX} 送 {setting.GetYFree}  {(setting.CanGetBonusRepeatedly ? string.Empty : "* 每筆交易僅優惠一次")}",
                            BonusAmount = product.Price * (decimal)setting.GetYFree
                        });

                        if (_setting.CanGetBonusRepeatedly)
                        {
                            dict.Remove(product.Id);
                        }
                    }
                }
                else
                {
                    dict[product.Id] = 1;
                }
            }

            return promotions;
        }
    }


    public class BuyXAndGetYFreePromotionRuleSetting : PromotionRuleSettingBase
    {
        public int BuyX { get; set; }
        public int GetYFree { get; set; }


    }
}
