using System;
using System.Collections.Generic;

namespace Client
{
    public class Permissions
    {
        private enum StorePermissions
        {
            ViewStaffInfo = 0b1,   //1
            ViewAndReplyCustomerInquiries = 0b10,         //2

        }

        public List<string> GetPermissions(int permission)
        {
            var permissions = new List<string>();
            var binary = Convert.ToString(permission, 2);
            
            for (var i = binary.Length - 1; i >= 0; i--)
            {
                var bit = binary[i];
                if (bit.Equals('1'))
                {
                    var enumString = "1";
                    for (var j = binary.Length - i - 1; j > 0; j--)
                        enumString += "0";
                    var enumValue = Convert.ToInt32(enumString, 2);
                    var permissionName = Enum.GetName(typeof(StorePermissions), enumValue);
                    permissions.Add(permissionName);
                }

            }

            return permissions;
        }
        
        public List<string> GetPermissions2(int permission)
        {
            var storePermissions = Enum.GetValues(typeof(StorePermissions));
            var permissions = new List<string>();
            var binary = Convert.ToString(permission, 2).ToCharArray();
            Array.Reverse(binary);
            
            for (var i = 0; i < binary.Length; i++)
            {
                if (!binary[i].Equals('1')) continue;
                var permissionName = Enum.GetName(typeof(StorePermissions), storePermissions.GetValue(i));
                permissions.Add(permissionName);
            }

            return permissions;
        }

        public static bool IsValidPermission(int permission)
        {
            var numOfPermissions = Enum.GetValues(typeof(StorePermissions)).Length;
            double maxVal = 0;
            for (var i = 0; i < numOfPermissions; i++)
            {
                maxVal += Math.Pow(2,i);
            }
            return permission > 0 && permission <= maxVal;
        }
        
    }
}