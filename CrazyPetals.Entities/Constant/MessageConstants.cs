using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Constant
{
    public static class MessageConstants
    {
        public static string BannerAddSuccessMessage { get; } = "Banner added sucessfully.";
        public static string CategoryAddSuccessMessage { get; } = "Category added sucessfully.";
        public static string CategoryUpdateSuccessMessage { get; } = "Category updated sucessfully.";
        public static string FilterAddSuccessMessage { get; } = "Filter added sucessfully.";
        public static string FilterUpdateSuccessMessage { get; } = "Filter updated sucessfully.";
        public static string NotificationAddSuccessMessage { get; } = "Notification added sucessfully.";
        public static string CategoryDeleteSuccessMessage { get; } = "Category deleted sucessfully.";
        public static string CategoryDeleteFailedMessage { get; } = "Category deletion failed. Make sure, there are no products with this category";
        public static string FilterDeleteSuccessMessage { get; } = "Filter deleted aucessfully.";
        public static string FilterDeleteFailedMessage { get; } = "Something went wrong.";
        public static string BannerDeleteSuccessMessage { get; } = "Banner ad deleted sucessfully";
        public static string BannerDeleteFailedMessage { get; } = "Something went wrong.";
        public static string NotificationDeleteSuccessMessage { get; } = "Notification deleted sucessfully";
        public static string NotificationDeleteFailedMessage { get; } = "Something went wrong.";
        public static object ProductAddSuccessMessage { get; } = "Product added sucessfully.";
        public static object ProductUpdateSuccessMessage { get; } = "Product updated sucessfully.";
        public static object ProductDeletedSuccessMessage { get; } = "Product deleted sucessfully.";
        public static object ProductDeletionFailedMessage { get; } = "Something went wrong.";
        public static object DeliveryStatusUpdated { get; } = "Delivery status updated successfully.";
        public static string LoginError { get; } = "Email or Password is not valid.";
    }
}
