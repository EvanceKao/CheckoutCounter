using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutCounter.Models
{
    //public abstract class PromotionRuleBase<TSetting> where TSetting : PromotionRuleSettingBase
    //{
    //    protected TSetting _setting;

    //    private PromotionRuleBase()
    //    {
    //    }

    //    public PromotionRuleBase(TSetting setting)
    //    {
    //        _setting = setting;
    //    }

    //    public abstract IEnumerable<Promotion> Process(IEnumerable<Product> products);



    //}


    public abstract class PromotionRuleBase
    {
        protected PromotionRuleSettingBase _setting;

        private PromotionRuleBase()
        {
        }

        public PromotionRuleBase(PromotionRuleSettingBase setting)
        {
            _setting = setting;
        }

        public abstract IEnumerable<Promotion> Process(IEnumerable<Product> products);



    }

}
