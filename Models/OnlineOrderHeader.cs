using System;
using System.Collections.Generic;

namespace CuisineOrdersAPI.Models
{
    public partial class OnlineOrderHeader
    {
        public int OnlineOrderId { get; set; }
        public int AppOrderId { get; set; }
        public int? OrderNumber { get; set; }
        public string OrderKey { get; set; }
        public string CreatedVia { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public decimal? DiscountTotal { get; set; }
        public decimal? DiscountTax { get; set; }
        public decimal? CartTax { get; set; }
        public decimal? CartTotal { get; set; }
        public bool? PriceIncludesTax { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmployeeNo { get; set; }
        public string PaymentMethod { get; set; }
        public int? TransactionId { get; set; }
        public DateTime? DatePaid { get; set; }
        public string OrderUrl { get; set; }
        public string CustomerNotes { get; set; }
        public string CuisineOrderStatus { get; set; }
        public bool? OrderLinesSaved { get; set; }
    }
}
