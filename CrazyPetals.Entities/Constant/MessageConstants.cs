using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Constant
{
    public static class MessageConstants
    {
        public static string BannerAddSuccessMessage { get; } = "Banner Added Sucessfully.";
        public static string CategoryAddSuccessMessage { get; } = "Category Added Sucessfully.";
        public static string FilterAddSuccessMessage { get; } = "Filter Added Sucessfully.";
        public static string NotificationAddSuccessMessage { get; } = "Notification Added Sucessfully.";
        public static object CategoryDeleteSuccessMessage { get; } = "Category Deleted Sucessfully.";
        public static object CategoryDeleteFailedMessage { get; } = "Category Deletion Failed. Make sure, there are no products with this category";
    }
}
