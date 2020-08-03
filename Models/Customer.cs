using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CuisineOrdersAPI.Models
{
    public partial class Customer
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

        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty("first_name", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("last_name", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("role", Required = Required.Always)]
        public string Role { get; set; }

        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty("billing", Required = Required.Always)]
        public Ing Billing { get; set; }

        [JsonProperty("shipping", Required = Required.Always)]
        public Ing Shipping { get; set; }

        [JsonProperty("is_paying_customer", Required = Required.Always)]
        public bool IsPayingCustomer { get; set; }

        [JsonProperty("avatar_url", Required = Required.Always)]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("meta_data", Required = Required.Always)]
        public MetaDatum[] MetaData { get; set; }

        //[JsonProperty("_links", Required = Required.Always)]
        //public Links Links { get; set; }
    }

    public partial class Ing
    {
        [JsonProperty("first_name", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("last_name", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("company", Required = Required.Always)]
        public string Company { get; set; }

        [JsonProperty("address_1", Required = Required.Always)]
        public string Address1 { get; set; }

        [JsonProperty("address_2", Required = Required.Always)]
        public string Address2 { get; set; }

        [JsonProperty("city", Required = Required.Always)]
        public string City { get; set; }

        [JsonProperty("postcode", Required = Required.Always)]
        public string Postcode { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public string Country { get; set; }

        [JsonProperty("state", Required = Required.Always)]
        public string State { get; set; }

        [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("phone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
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

    public partial class MetaDatum
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }

        [JsonProperty("value", Required = Required.Always)]
        //public ValueUnion Value { get; set; }
        public dynamic Value { get; set; }
    }

    public partial class ValueClass
    {
        [JsonProperty("ip", Required = Required.Always)]
        public string Ip { get; set; }
    }

    public partial struct ValueUnion
    {
        public string String;
        public string[] StringArray;
        public ValueClass ValueClass;

        public static implicit operator ValueUnion(string String) => new ValueUnion { String = String };
        public static implicit operator ValueUnion(string[] StringArray) => new ValueUnion { StringArray = StringArray };
        public static implicit operator ValueUnion(ValueClass ValueClass) => new ValueUnion { ValueClass = ValueClass };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ValueUnionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ValueUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ValueUnion) || t == typeof(ValueUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new ValueUnion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<ValueClass>(reader);
                    return new ValueUnion { ValueClass = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<string[]>(reader);
                    return new ValueUnion { StringArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type ValueUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ValueUnion)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.StringArray != null)
            {
                serializer.Serialize(writer, value.StringArray);
                return;
            }
            if (value.ValueClass != null)
            {
                serializer.Serialize(writer, value.ValueClass);
                return;
            }
            throw new Exception("Cannot marshal type ValueUnion");
        }

        public static readonly ValueUnionConverter Singleton = new ValueUnionConverter();
    }
}
