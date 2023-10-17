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
                    return $" {Cost:0} Р ";
                else
                    return $"{Cost - (Cost * (decimal)Discount / 100) : 0} Р ";
            }
        }
        public string Testimonials
        {
            get
            {
                var count = 0;
                foreach (var a in Feedback)
                {
                    count++;
                }
                return $" {count} отзывов";
            }
        }
        public string Reviews
        {
            get
            {
                if (Feedback.Count != 0)
                {
                    return Feedback.Average(x => x.Evaluation).ToString("F1");
                }
                else
                    return null;
                
                //decimal sum = 0;
                //var count = 0;
                //foreach (var a in Feedback)
                //{
                //    sum += a.Evaluation;
                //    count++;
                //}
                //if (sum > 0 && count>0)
                //    return $"{(sum / count)}  ";
                //else
                //    return $"{0}  ";
            }
        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                {
                    return Visibility.Collapsed;
                }
                else
                    return Visibility.Visible;
            }
        }

    }
}
