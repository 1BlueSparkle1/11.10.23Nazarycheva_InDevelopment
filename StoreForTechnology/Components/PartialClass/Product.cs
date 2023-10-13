using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace StoreForTechnology.Components
{
    public partial class Product
    {
        public string CostTime
        {
            get
            {
                if (Discount == 0)
                    return $"{Cost:0} Р";
                else
                    return $"{Cost - (Cost * (decimal)Discount / 100):0} Р";
            }
        }
        public string Testimonials
        {
            get
            {
                var b = 0;
                foreach (var a in Feedback)
                {
                    b++;
                }
                return b.ToString();
            }
        }
        
    }
}
