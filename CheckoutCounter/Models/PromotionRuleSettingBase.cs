using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutCounter.Models
{
    public class PromotionRuleSettingBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public decimal Amount { get; set; }
        public bool CanGetBonusRepeatedly { get; set; }
    }
}
