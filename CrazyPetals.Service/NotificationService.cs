
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Service.ExtensionMethods;

namespace CrazyPetals.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private IUnitOfWork _unitOfWork;

        public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddNotificationAsync(AddNotificationViewModel model)
        {
            Notification notification = new Notification()
            {
                AppId = StringConstants.AppId,
                CreatedDate = DateTime.Now,
                Title = model.Title,
                Message = model.Message
            };
            _notificationRepository.Add(notification);
            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteNotification(int id)
        {
            Notification notification = await _notificationRepository.FindByIdAsync(id);
            if (notification == null)
                return 0;
            else
            {
                _notificationRepository.Remove(notification);
                var result = await _unitOfWork.SaveChangesAsync();
                return result;
            }
        }

        public async Task<NotificationWrapperViewModel> GetWrapperForIndexView(FilterBase filter)
        {
            NotificationWrapperViewModel ResponseModel = new NotificationWrapperViewModel
            {
                TotalCount = _notificationRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Notification> list = await _notificationRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.NotificationList = list.Select((x, index) => new NotificationListViewModel
            {
                Id = x.Id,
                Message = x.Message,
                SentDate = x.CreatedDate.ToCrazyPattelsPattern(),
                Title = x.Title,
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }
    }
}
