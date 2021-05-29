namespace Version1.domainLayer
{
    public static class Errors
    {
        // User Errors
        public const string UserNotFound = "Error : User Not Found";
        public const string UserNameNotAvailable = "Error : User Name Is Not Available";
        public const string UserAlreadyLoggedIn = "Error : User Is Already Logged-In";
        public const string PermissionError = "Error : The Appointer Has No Permssion To Do This";
        public const string NotAnOwner = "Error : This User Is Not An Owner";
        public const string NotAManager = "Error : This User Is Not A Manager";
        public const string AlreadyOwner = "Error : Apointee Is Already An Owner";
        public const string AlreadyManager = "Error : Apointee Is Already A Manager";

        
        // Store Errors

        public const string StoreNotFound = "Error : Store Not Found";
        public const string StoreNameNotAvailable = "Error : Store Name Is Not Availavle";
        public const string ProductNotFound = "Error : Product Not Found";
        public const string ProductBarcodeNotAvailable = "Error : A Product With This Barcode Already Exists";
        
    }
}