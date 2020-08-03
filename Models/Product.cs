using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace CuisineOrdersAPI.Models
{
    public partial class Product
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("slug", Required = Required.Always)]
        public string Slug { get; set; }

        [JsonProperty("permalink", Required = Required.Always)]
        public Uri Permalink { get; set; }

        [JsonProperty("date_created", Required = Required.Always)]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("date_created_gmt", Required = Required.Always)]
        public DateTimeOffset DateCreatedGmt { get; set; }

        [JsonProperty("date_modified", Required = Required.Always)]
        public DateTimeOffset DateModified { get; set; }

        [JsonProperty("date_modified_gmt", Required = Required.Always)]
        public DateTimeOffset DateModifiedGmt { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }

        [JsonProperty("featured", Required = Required.Always)]
        public bool Featured { get; set; }

        [JsonProperty("catalog_visibility", Required = Required.Always)]
        public string CatalogVisibility { get; set; }

        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty("short_description", Required = Required.Always)]
        public string ShortDescription { get; set; }

        [JsonProperty("sku", Required = Required.Always)]
        public string Sku { get; set; }

        [JsonProperty("price", Required = Required.Always)]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long Price { get; set; }

        [JsonProperty("regular_price", Required = Required.Always)]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long RegularPrice { get; set; }

        [JsonProperty("sale_price", Required = Required.Always)]
        public string SalePrice { get; set; }

        [JsonProperty("date_on_sale_from", Required = Required.AllowNull)]
        public object DateOnSaleFrom { get; set; }

        [JsonProperty("date_on_sale_from_gmt", Required = Required.AllowNull)]
        public object DateOnSaleFromGmt { get; set; }

        [JsonProperty("date_on_sale_to", Required = Required.AllowNull)]
        public object DateOnSaleTo { get; set; }

        [JsonProperty("date_on_sale_to_gmt", Required = Required.AllowNull)]
        public object DateOnSaleToGmt { get; set; }

        [JsonProperty("price_html", Required = Required.Always)]
        public string PriceHtml { get; set; }

        [JsonProperty("on_sale", Required = Required.Always)]
        public bool OnSale { get; set; }

        [JsonProperty("purchasable", Required = Required.Always)]
        public bool Purchasable { get; set; }

        [JsonProperty("total_sales", Required = Required.Always)]
        public long TotalSales { get; set; }

        [JsonProperty("virtual", Required = Required.Always)]
        public bool Virtual { get; set; }

        [JsonProperty("downloadable", Required = Required.Always)]
        public bool Downloadable { get; set; }

        [JsonProperty("downloads", Required = Required.Always)]
        public object[] Downloads { get; set; }

        [JsonProperty("download_limit", Required = Required.Always)]
        public long DownloadLimit { get; set; }

        [JsonProperty("download_expiry", Required = Required.Always)]
        public long DownloadExpiry { get; set; }

        [JsonProperty("external_url", Required = Required.Always)]
        public string ExternalUrl { get; set; }

        [JsonProperty("button_text", Required = Required.Always)]
        public string ButtonText { get; set; }

        [JsonProperty("tax_status", Required = Required.Always)]
        public string TaxStatus { get; set; }

        [JsonProperty("tax_class", Required = Required.Always)]
        public string TaxClass { get; set; }

        [JsonProperty("manage_stock", Required = Required.Always)]
        public bool ManageStock { get; set; }

        [JsonProperty("stock_quantity", Required = Required.AllowNull)]
        public object StockQuantity { get; set; }

        [JsonProperty("stock_status", Required = Required.Always)]
        public string StockStatus { get; set; }

        [JsonProperty("backorders", Required = Required.Always)]
        public string Backorders { get; set; }

        [JsonProperty("backorders_allowed", Required = Required.Always)]
        public bool BackordersAllowed { get; set; }

        [JsonProperty("backordered", Required = Required.Always)]
        public bool Backordered { get; set; }

        [JsonProperty("sold_individually", Required = Required.Always)]
        public bool SoldIndividually { get; set; }

        [JsonProperty("weight", Required = Required.Always)]
        public string Weight { get; set; }

        [JsonProperty("dimensions", Required = Required.Always)]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("shipping_required", Required = Required.Always)]
        public bool ShippingRequired { get; set; }

        [JsonProperty("shipping_taxable", Required = Required.Always)]
        public bool ShippingTaxable { get; set; }

        [JsonProperty("shipping_class", Required = Required.Always)]
        public string ShippingClass { get; set; }

        [JsonProperty("shipping_class_id", Required = Required.Always)]
        public long ShippingClassId { get; set; }

        [JsonProperty("reviews_allowed", Required = Required.Always)]
        public bool ReviewsAllowed { get; set; }

        [JsonProperty("average_rating", Required = Required.Always)]
        public string AverageRating { get; set; }

        [JsonProperty("rating_count", Required = Required.Always)]
        public long RatingCount { get; set; }

        [JsonProperty("related_ids", Required = Required.Always)]
        public long[] RelatedIds { get; set; }

        [JsonProperty("upsell_ids", Required = Required.Always)]
        public object[] UpsellIds { get; set; }

        [JsonProperty("cross_sell_ids", Required = Required.Always)]
        public object[] CrossSellIds { get; set; }

        [JsonProperty("parent_id", Required = Required.Always)]
        public long ParentId { get; set; }

        [JsonProperty("purchase_note", Required = Required.Always)]
        public string PurchaseNote { get; set; }

        [JsonProperty("categories", Required = Required.Always)]
        public Category[] Categories { get; set; }

        [JsonProperty("tags", Required = Required.Always)]
        public object[] Tags { get; set; }

        [JsonProperty("images", Required = Required.Always)]
        public Image[] Images { get; set; }

        [JsonProperty("attributes", Required = Required.Always)]
        public object[] Attributes { get; set; }

        [JsonProperty("default_attributes", Required = Required.Always)]
        public object[] DefaultAttributes { get; set; }

        [JsonProperty("variations", Required = Required.Always)]
        public object[] Variations { get; set; }

        [JsonProperty("grouped_products", Required = Required.Always)]
        public object[] GroupedProducts { get; set; }

        [JsonProperty("menu_order", Required = Required.Always)]
        public long MenuOrder { get; set; }

        [JsonProperty("meta_data", Required = Required.Always)]
        public MetaDatum[] MetaData { get; set; }

        [JsonProperty("better_featured_image", Required = Required.AllowNull)]
        public object BetterFeaturedImage { get; set; }

        [JsonProperty("_links", Required = Required.Always)]
        public Links Links { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("slug", Required = Required.Always)]
        public string Slug { get; set; }
    }

    public partial class Dimensions
    {
        [JsonProperty("length", Required = Required.Always)]
        public string Length { get; set; }

        [JsonProperty("width", Required = Required.Always)]
        public string Width { get; set; }

        [JsonProperty("height", Required = Required.Always)]
        public string Height { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("date_created", Required = Required.Always)]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("date_created_gmt", Required = Required.Always)]
        public DateTimeOffset DateCreatedGmt { get; set; }

        [JsonProperty("date_modified", Required = Required.Always)]
        public DateTimeOffset DateModified { get; set; }

        [JsonProperty("date_modified_gmt", Required = Required.Always)]
        public DateTimeOffset DateModifiedGmt { get; set; }

        [JsonProperty("src", Required = Required.Always)]
        public Uri Src { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long Name { get; set; }

        [JsonProperty("alt", Required = Required.Always)]
        public string Alt { get; set; }
    }

    //public partial class Links
    //{
    //    [JsonProperty("self", Required = Required.Always)]
    //    public Collection[] Self { get; set; }

    //    [JsonProperty("collection", Required = Required.Always)]
    //    public Collection[] Collection { get; set; }
    //}

    //public partial class Collection
    //{
    //    [JsonProperty("href", Required = Required.Always)]
    //    public Uri Href { get; set; }
    //}

    //public partial class MetaDatum
    //{
    //    [JsonProperty("id", Required = Required.Always)]
    //    public long Id { get; set; }

    //    [JsonProperty("key", Required = Required.Always)]
    //    public string Key { get; set; }

    //    [JsonProperty("value", Required = Required.Always)]
    //    public string Value { get; set; }
    //}
}


