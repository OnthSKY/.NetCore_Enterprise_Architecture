using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ListedProducts = "All Product has listed Successfully";
        public static string ListedPersonels = "All Personel has listed Successfully";
        public static string ListedCategroies = "All Categories has listed Successfully";

        public static string AddedProduct = "The Product has Added";
        public static string UpdatedProduct = "The Product has Deleted";
        public static string DeletedProduct = "The Product has Updated";

        public static string FoundProduct = "Product has found Successfully";

        public static string ProductCountOfCategoryLimit = "Category limit has over";

        public static string ProductNameAlreadyExist = "Product name already has use";

        public static string CategoryLimitExceded = "New product has not added because of category limit exceeded";

        public static string AuthorizationDenied = "You dont have a permissin";

        public static string UserRegistered = "User has registered Success";

        public static User UserNotFound { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
    }
}
