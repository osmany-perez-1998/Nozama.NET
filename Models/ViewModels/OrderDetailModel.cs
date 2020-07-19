using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class OrderDetailModel
    {
        public string UserId { get; set; }
        public List<OrderDetails> Products { get; set; }
        public double Price { get; set; }
    }
}