using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Constant
{
    public static class MessageConstants
    {
        public static string BannerAddSuccessMessage { get; } = "Banner Added Sucessfully.";
        public static string CategoryAddSuccessMessage { get; } = "Category Added Sucessfully.";
        public static string CategoryUpdateSuccessMessage { get; } = "Category Updated Sucessfully.";
        public static string FilterAddSuccessMessage { get; } = "Filter Added Sucessfully.";
        public static string FilterUpdateSuccessMessage { get; } = "Filter Updated Sucessfully.";
        public static string NotificationAddSuccessMessage { get; } = "Notification Added Sucessfully.";
        public static string CategoryDeleteSuccessMessage { get; } = "Category Deleted Sucessfully.";
        public static string CategoryDeleteFailedMessage { get; } = "Category Deletion Failed. Make sure, there are no products with this category";
        public static string FilterDeleteSuccessMessage { get; } = "Filter Deleted Sucessfully.";
        public static string FilterDeleteFailedMessage { get; } = "Something went wrong.";
        public static string BannerDeleteSuccessMessage { get; } = "Banner Ad Deleted Sucessfully";
        public static string BannerDeleteFailedMessage { get; } = "Something went wrong.";
        public static string NotificationDeleteSuccessMessage { get; } = "Notification Deleted Sucessfully";
        public static string NotificationDeleteFailedMessage { get; } = "Something went wrong.";
        public static object ProductAddSuccessMessage { get; set; } = "Product Added Sucessfully.";
        public static object ProductUpdateSuccessMessage { get; set; } = "Product Updated Sucessfully.";
        public static object ProductDeletedSuccessMessage { get; set; } = "Product Deleted Sucessfully.";
        public static object ProductDeletionFailedMessage { get; set; } = "Something went wrong.";
        public static object DeliveryStatusUpdated { get; set; } = "Delivery status updated successfully.";
    }
}
