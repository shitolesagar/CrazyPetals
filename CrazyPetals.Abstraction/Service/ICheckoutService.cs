using CrazyPetals.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface ICheckoutService
    {
        AddToCartResponse AddToCart(AddToCart request);

        IncDecProductResponse IncDecProductQuantity(IncDecProductResource request);

        Task<GetCartListResponse> GetCartList(string AppId, int ApplicationUserId);

        CommonAddressResponse AddAddress(UsersAddress request);

        CommonAddressResponse EditAddress(UsersAddress request);

        CommonAddressResponse DeleteAddress(DeleteAddressResource request);

        Task<AddressListResponse> GetAddressList(string AppId, int ApplicationUserId);

        Task<PriceDetailsResponse> GetPriceDetails(string AppId, int ApplicationUserId);

        Task<CommonResponse> PlaceOrder(PlaceOrderResource request);
    }
}
