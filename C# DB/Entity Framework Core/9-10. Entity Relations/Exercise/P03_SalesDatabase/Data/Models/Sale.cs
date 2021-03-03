﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        
        public int SaleId { get; set; }
        public DateTime Date { get; set; }

        // [ForeignKey(nameof(Product))] // ??
        public int ProductId { get; set; } // nav prop
        public Product Product { get; set; }

        // [ForeignKey(nameof(Customer))] // ??
        public int CustomerId { get; set; } // nav prop
        public Customer Customer { get; set; }

        // [ForeignKey(nameof(Store))] // ???
        public int StoreId { get; set; } // nav prop
        public Store Store { get; set; }


    }
}
