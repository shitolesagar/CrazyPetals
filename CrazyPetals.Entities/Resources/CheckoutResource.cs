using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Resources
{
    public class AddToCart
    {
        public int ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public string AppId { get; set; }
    }
    public class AddToCartResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
    }

    //This class is used as a resource to send response of GetCartList Api response
    public class CartResponse
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public int? OriginalPrice { get; set; }
        public int DiscountedPrice { get; set; }

    }

    public class AddToCartResourceWrapper
    {
        public List<CartResponse> CartList { get; set; }
        public int TotalCount { get; set; }
    }
    public class GetCartListResponse
    {
        public bool error { get; set; }
        public string Message { get; set; }
        public List<CartResponse> data { get; set; }
        public int Count { get; set; }
    }

    //This class is used as a resource for adding the new address to database
    public class UsersAddress
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string AppId { get; set; }
        public string MobileNumber { get; set; }
        public string PINCode { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    //This class is used as a resource for sending GetAddressList API response
    public class UsersAddressResponse
    {
        public int Id { get; set; }
        public int? ApplicationUserId { get; set; }
        public string AppId { get; set; }
        public string MobileNumber { get; set; }
        public string PINCode { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string Name { get; set; }
    }
    public class CommonAddressResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
    }

    public class AddressResourceWrapper
    {
        public List<UsersAddressResponse> AddressList { get; set; }
        public int TotalCount { get; set; }
    }
    public class AddressListResponse
    {
        public bool error { get; set; }
        public string Message { get; set; }
        public List<UsersAddressResponse> data { get; set; }
        public int Count { get; set; }
    }

    public class PriceDetailsResource
    {
        public int MRP { get; set; }
        public int ProductDiscounts { get; set; }
        public int DeliveryCharges { get; set; }
        public int SubTotal { get; set; }
    }
    public class PriceDetailsResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public PriceDetailsResource data { get; set; }
    }

    public class OrderDetailsResource
    {
        public int ProductDetailId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }

    public class PlaceOrderResource
    {
        public int MRP { get; set; }
        public int ProductsDiscount { get; set; }
        public int GST { get; set; }
        public int DeliveryCharges { get; set; }
        public int SubTotal { get; set; }
        public int AddressId { get; set; }
        public int ApplicationUserId { get; set; }
        public string AppId { get; set; }
        public List<OrderDetailsResource> OrderDetails { get; set; }
    }

    public class IncDecProductResource
    {
        public int ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string AppId { get; set; }
    }
    public class IncDecProductResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
    }

    public class DeleteAddressResource
    {
        public int Id { get; set; }
    }
}
