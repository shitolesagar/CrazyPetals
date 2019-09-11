using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPetals.Service
{
    public class CheckoutService : ICheckoutService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        private IEmailService _emailService;
        private IProductImagesRepository _productImagesRepository;
        private IUserAddressRepository _userAddressRepository;
        private IOrderSummaryRepository _orderSummaryRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IApplicationUserRepository _applicationUserRepository;
        private IForgotPasswordRepository _forgotPasswordRepository;
        private IAppThemeRepository _appThemeRepository;
        private IVersionControlRepository _versionControlRepository;
        private IBannerRepository _bannerRepository;
        private INotificationRepository _notificationRepository;
        private IFilterRepository _filterRepository;
        private IProductRepository _productRepository;
        private ICartDetailsRepository _cartDetailsRepository;
        private IDelivery_chargeRepository _delivery_chargeRepository;


        public CheckoutService(ICategoryRepository categoryRepository, IDelivery_chargeRepository delivery_chargeRepository, ICartDetailsRepository cartDetailsRepository, IProductRepository productRepository, IFilterRepository filterRepository, INotificationRepository notificationRepository, IBannerRepository bannerRepository, IVersionControlRepository versionControlRepository, IAppThemeRepository appThemeRepository, IEmailService emailService, IForgotPasswordRepository forgotPasswordRepository, IApplicationUserRepository applicationUserRepository, IOrderDetailsRepository orderDetailsRepository, IOrderSummaryRepository orderSummaryRepository, IUserAddressRepository userAddressRepository, IProductImagesRepository productImagesRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _productImagesRepository = productImagesRepository;
            _userAddressRepository = userAddressRepository;
            _orderSummaryRepository = orderSummaryRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _applicationUserRepository = applicationUserRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
            _appThemeRepository = appThemeRepository;
            _emailService = emailService;
            _versionControlRepository = versionControlRepository;
            _bannerRepository = bannerRepository;
            _notificationRepository = notificationRepository;
            _filterRepository = filterRepository;
            _productRepository = productRepository;
            _cartDetailsRepository = cartDetailsRepository;
            _delivery_chargeRepository = delivery_chargeRepository;
        }

        public CheckoutService()
        {

        }

        #region AddToCart
        public AddToCartResponse AddToCart(AddToCart request)
        {

            AddToCartResponse res = new AddToCartResponse();
            var cart = _cartDetailsRepository.FindByApplicationUserId(request.ApplicationUserId);
            foreach (var record in cart)
            {
                if (record.ProductId == request.ProductId)
                {
                    res.error = true;
                    res.Message = StringConstants.ItemExist;
                    return res;
                }
            }
            try
            {
                if (request.AppId == null)
                {
                    res.error = true;
                    res.Message = StringConstants.AppIdNull;
                    return res;
                }
                CartDetails CartItem = new CartDetails()
                {
                    AppId = request.AppId,
                    ApplicationUserId = request.ApplicationUserId,
                    ProductId = request.ProductId,
                    Quantity = 1,
                };
                _cartDetailsRepository.Add(CartItem);
                 _unitOfWork.SaveChanges();
                res.Message = StringConstants.ItemAdded;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region IncDecProductQuantity
        public IncDecProductResponse IncDecProductQuantity(IncDecProductResource request)
        {
            IncDecProductResponse res = new IncDecProductResponse();
            try
            {
                if (request.AppId == null)
                {
                    res.error = true;
                    res.Message = StringConstants.AppIdNull;
                    return res;
                }
                var pro =  _cartDetailsRepository.FindByProductDetailId(request.ProductId, request.AppId, request.ApplicationUserId);
                pro.Quantity = request.Quantity;
                _unitOfWork.SaveChanges();
                res.Message = StringConstants.QuantityUpdated;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region GetCartList
        public async Task<GetCartListResponse> GetCartList(string AppId, int ApplicationUserId)
        {
            GetCartListResponse res = new GetCartListResponse();
            try
            {
                AddToCartResourceWrapper response = new AddToCartResourceWrapper
                {
                    CartList = new List<CartResponse>()
                };
                var CartRecordsList =await  _cartDetailsRepository.GetAllItemsForUser(AppId, ApplicationUserId);
                response.CartList = CartRecordsList.Select(x => new CartResponse()
                {
                    Id = x.Id,
                    ApplicationUserId = x.ApplicationUserId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                }).ToList();
                foreach (var rec in response.CartList)
                {
                    var pro =await  _productRepository.GetProductDetailAsync(rec.ProductId, AppId);
                    rec.ProductName = pro.Name;
                    rec.ProductImageURL = StringConstants.CPImageUrl + pro.ProductImages.Where(y => y.IsMain == true).FirstOrDefault().Image;
                    rec.OriginalPrice = pro.OriginalPrice;
                    rec.DiscountedPrice = pro.DiscountedPrice;
                    rec.ShortDescription = pro.Description;
                }
                response.TotalCount = CartRecordsList.Count;

                res.Message = StringConstants.Success;
                res.data = response.CartList;
                res.Count = response.TotalCount;
                return res;


            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region AddNewAddress
        public CommonAddressResponse AddAddress(UsersAddress request)
        {
            CommonAddressResponse res = new CommonAddressResponse();
            try
            {
                if (request.AppId == null)
                {
                    res.error = true;
                    res.Message = StringConstants.AppIdNull;
                    return res;
                }
                UserAddress add = new UserAddress()
                {
                    AppId = request.AppId,
                    ApplicationUserId = request.ApplicationUserId,
                    MobileNumber = request.MobileNumber,
                    PINCode = request.PINCode,
                    Address = request.Address,
                    Locality = request.Locality,
                };
                _userAddressRepository.Add(add);
                 _unitOfWork.SaveChanges();
                res.Message = StringConstants.AddressAdded;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }

        #endregion

        #region EditAddress
        public CommonAddressResponse EditAddress(UsersAddress request)
        {
            CommonAddressResponse res = new CommonAddressResponse();
            try
            {
                if (request.AppId == null)
                {
                    res.error = true;
                    res.Message = StringConstants.AppIdNull;
                    return res;
                }
                var exadd = _userAddressRepository.FindById(request.Id);
                _userAddressRepository.Remove(exadd);
                 _unitOfWork.SaveChanges();
                UserAddress add = new UserAddress()
                {
                    AppId = request.AppId,
                    ApplicationUserId = request.ApplicationUserId,
                    MobileNumber = request.MobileNumber,
                    PINCode = request.PINCode,
                    Address = request.Address,
                    Locality = request.Locality,
                };
                _userAddressRepository.Add(add);
                 _unitOfWork.SaveChanges();
                res.Message = StringConstants.AddressUpdated;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }

        #endregion


        #region DeleteAddress
        public CommonAddressResponse DeleteAddress(DeleteAddressResource request)
        {
            CommonAddressResponse res = new CommonAddressResponse();
            try
            {
                var rec = _userAddressRepository.FindById(request.Id);
                rec.IsDeleted = true;
                 _unitOfWork.SaveChanges();
                res.Message = StringConstants.AddressDeleted;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region GetAddressList
        public async Task<AddressListResponse> GetAddressList(string AppId, int ApplicationUserId)
        {
            AddressListResponse res = new AddressListResponse();
            try
            {
                AddressResourceWrapper response = new AddressResourceWrapper
                {
                    AddressList = new List<UsersAddressResponse>()
                };

                var AddressRecordsList = await _userAddressRepository.GetAllAddressForUser(AppId, ApplicationUserId);

                response.AddressList = AddressRecordsList.Select(x => new UsersAddressResponse()
                {
                    Id = x.Id,
                    ApplicationUserId = x.ApplicationUserId,
                    AppId = x.AppId,
                    MobileNumber = x.MobileNumber,
                    PINCode = x.PINCode,
                    Address = x.Address,
                    Locality = x.Locality,
                }).ToList();
                foreach (var rec in response.AddressList)
                {
                    var user = _applicationUserRepository.FindById(ApplicationUserId);
                    rec.Name = user.Name;
                }
                response.TotalCount = response.AddressList.Count;
                res.Message = StringConstants.Success;
                res.data = response.AddressList;
                res.Count = response.TotalCount;
                return res;

            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region GetPriceDetails
        public async Task<PriceDetailsResponse> GetPriceDetails(string AppId, int ApplicationUserId)
        {
            PriceDetailsResponse res = new PriceDetailsResponse();
            try
            {
                AddToCartResourceWrapper response = new AddToCartResourceWrapper
                {
                    CartList = new List<CartResponse>()
                };
                var CartRecordsList = await _cartDetailsRepository.GetAllItemsForUser(AppId, ApplicationUserId);
                response.CartList = CartRecordsList.Select(x => new CartResponse()
                {
                    Id = x.Id,
                    ApplicationUserId = x.ApplicationUserId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                }).ToList();
                foreach (var rec in response.CartList)
                {
                    var pro = await _productRepository.GetProductDetailAsync(rec.ProductId, AppId);
                    rec.ProductName = pro.Name;
                    rec.OriginalPrice = pro.OriginalPrice;
                    rec.DiscountedPrice = pro.DiscountedPrice;
                }
                response.TotalCount = CartRecordsList.Count;
                PriceDetailsResource obj = new PriceDetailsResource();
                foreach (var item in response.CartList)
                {
                    if (item.OriginalPrice != null)
                    {
                        obj.MRP = Convert.ToInt32(obj.MRP + (item.OriginalPrice * item.Quantity));
                    }
                    else
                    {
                        obj.MRP = obj.MRP + (item.DiscountedPrice * item.Quantity);
                    }
                    int discount = 0;
                    if (item.OriginalPrice != null)
                    {
                        discount = (Convert.ToInt32(item.OriginalPrice - item.DiscountedPrice)) * item.Quantity;
                    }
                    obj.ProductDiscounts = obj.ProductDiscounts + discount;
                }
                int total = obj.MRP - obj.ProductDiscounts;
                if (total >= 301)
                {
                    var rec = _delivery_chargeRepository.findByMin(301, AppId);
                    obj.DeliveryCharges = rec.DeliveryCharge;
                }
                else if (total >= 101 && total <= 300)
                {
                    var rec = _delivery_chargeRepository.findByMin(101, AppId);
                    obj.DeliveryCharges = rec.DeliveryCharge;
                }
                else if (total >= 1 && total <= 100)
                {
                    var rec = _delivery_chargeRepository.findByMin(1, AppId);
                    obj.DeliveryCharges = rec.DeliveryCharge;
                }
                obj.SubTotal = total + obj.DeliveryCharges;
                res.Message = StringConstants.Success;
                res.data = obj;
                return res;

            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region PlaceOrder
        public async Task<CommonResponse> PlaceOrder(PlaceOrderResource request)
        {
            CommonResponse res = new CommonResponse();
            try
            {
                OrderSummary obj = new OrderSummary()
                {
                    MRP = request.MRP,
                    Discount = request.ProductsDiscount,
                    DeliveryCharges = request.DeliveryCharges,
                    SubTotal = request.SubTotal,
                    UserAddressId = request.AddressId,
                    AppId = request.AppId,
                    ApplicationUserId = request.ApplicationUserId,
                    CreatedDate = DateTime.Now,
                };
                

                _orderSummaryRepository.Add(obj);
                _unitOfWork.SaveChanges();

                foreach (var order in request.OrderDetails)
                {
                    var pro = await _productRepository.GetProductDetailAsync(order.ProductDetailId, request.AppId);
                    int discount = 0;
                    if (pro.OriginalPrice != 0)
                    {
                        discount = Convert.ToInt32(pro.OriginalPrice - pro.DiscountedPrice) * order.Quantity;
                    }
                    OrderDetails ob = new OrderDetails()
                    {
                        OrderSummaryId = obj.Id,
                        ProductId = order.ProductDetailId,
                        Quantity = order.Quantity,
                        AppId = request.AppId,
                        OriginalPrice = pro.OriginalPrice * order.Quantity,
                        DiscountedPrice =pro.DiscountedPrice*order.Quantity
                    
                    };
                    _orderDetailsRepository.Add(ob);
                    _unitOfWork.SaveChanges();

                    var cart = _cartDetailsRepository.FindByProductsDetailId(order.ProductDetailId, request.AppId, request.ApplicationUserId);
                    if (cart != null)
                    {
                        _cartDetailsRepository.Remove(cart);
                        _unitOfWork.SaveChanges();
                    }

                }

                res.Message = StringConstants.OrderPlaced;
                return res;

            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion
    }
}
