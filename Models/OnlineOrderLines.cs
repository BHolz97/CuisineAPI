using System;
using System.Collections.Generic;

namespace CuisineOrdersAPI.Models
{
    public partial class OnlineOrderLines
    {
        public int OnlineOrderLineId { get; set; } //Generated
        public int? OnlineOrderHeaderId { get; set; } //Generated
        public int? AppOrderId { get; set; } //HeaderId ----
        public int AppOrderLineId { get; set; } //LineId
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public int? Quantity { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? SubTotalTax { get; set; }
        public decimal? Price { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
    }
}
