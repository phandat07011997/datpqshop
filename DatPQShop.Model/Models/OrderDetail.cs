﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPQShop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int OrderID { set; get; }

        [Key]
        public int ProductID { set; get; }

        public int Quantity { set; get; }
        
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
