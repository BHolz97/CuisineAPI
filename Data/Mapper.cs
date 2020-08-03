//using CuisineOrdersAPI.Dtos;
using CuisineOrdersAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

//Custom class to map incoming cuisine order JSON to Database model format
namespace CuisineOrdersAPI.Data
{
    public class Mapper
    {
        public OnlineOrderHeader orderHeader = new OnlineOrderHeader();
        public OnlineOrderLines orderLines = new OnlineOrderLines();

        public void Map(CuisineOrder cuisineOrder)
        {

            ///////////////////////////////////////Header

            orderHeader.AppOrderId = cuisineOrder.id;
            orderHeader.OrderNumber = System.Convert.ToInt32(cuisineOrder.number); 
            orderHeader.OrderKey = cuisineOrder.order_key;
            orderHeader.CreatedVia = cuisineOrder.created_via;
            orderHeader.Version = cuisineOrder.version;
            orderHeader.Status = cuisineOrder.status;
            orderHeader.Currency = cuisineOrder.currency;
            orderHeader.DateCreated = cuisineOrder.date_created;
            orderHeader.DateModified = cuisineOrder.date_modified;
            orderHeader.DiscountTotal = System.Convert.ToDecimal(cuisineOrder.discount_total);
            orderHeader.DiscountTax = System.Convert.ToDecimal(cuisineOrder.discount_tax);
            orderHeader.CartTax = System.Convert.ToDecimal(cuisineOrder.cart_tax);
            orderHeader.CartTotal = System.Convert.ToDecimal(cuisineOrder.total);
            orderHeader.PriceIncludesTax = cuisineOrder.prices_include_tax;
            orderHeader.CustomerId = cuisineOrder.customer_id;
            orderHeader.CustomerFirstName = cuisineOrder.billing.first_name;
            orderHeader.CustomerLastName = cuisineOrder.billing.last_name;
            orderHeader.CustomerEmail = cuisineOrder.billing.email;
            orderHeader.CustomerPhone = cuisineOrder.billing.phone;
            orderHeader.CustomerEmployeeNo = GetCustomerEmployeeNoByRequestAsync().Result; 
            orderHeader.PaymentMethod = cuisineOrder.payment_method;
            orderHeader.TransactionId = System.Convert.ToInt32(cuisineOrder.transaction_id);
            orderHeader.DatePaid = cuisineOrder.date_paid;
            orderHeader.OrderUrl = cuisineOrder._links.self[0].href;
            orderHeader.CustomerNotes = cuisineOrder.customer_note;
            orderHeader.CuisineOrderStatus = cuisineOrder.status;

            /////////////////////////////////////////////////Lines
         
            orderLines.AppOrderLineId = cuisineOrder.line_items[0].id;
            orderLines.AppOrderId = cuisineOrder.id;
            orderLines.ProductId = cuisineOrder.line_items[0].product_id;
            orderLines.Sku = cuisineOrder.line_items[0].sku;
            orderLines.Quantity = cuisineOrder.line_items[0].quantity;
            orderLines.SubTotal = System.Convert.ToDecimal(cuisineOrder.line_items[0].subtotal);
            orderLines.SubTotalTax = System.Convert.ToDecimal(cuisineOrder.line_items[0].subtotal_tax);
            orderLines.Price = cuisineOrder.line_items[0].price;
            orderLines.ProductDescription = cuisineOrder.line_items[0].name;
            orderLines.Category = GetCategoryByRequestAsync().Result;
        }

        public async Task<string> GetCategoryByRequestAsync()
        {
            Product data = new Product();

            var httpClient = HttpClientFactory.Create();
            var url = "https://cuisine2.mooidev.com/wp-json/wc/v3/Products/" + orderLines.ProductId;

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                data = await content.ReadAsAsync<Product>();
                return data.Categories[0].Name;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<string> GetCustomerEmployeeNoByRequestAsync()
        {
            Customer data = new Customer();

            var httpClient = HttpClientFactory.Create();
            var url = "https://cuisine2.mooidev.com/wp-json/wc/v3/customers/" + orderHeader.CustomerId;



            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                data = await content.ReadAsAsync<Customer>(); 

                return data.MetaData.FirstOrDefault(a => a.Key == "employee_number")?.Value;

                throw new Exception();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
