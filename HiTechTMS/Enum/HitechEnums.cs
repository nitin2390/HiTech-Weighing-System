﻿namespace HitechTMS
{
    public class HitechEnums
    {
        public enum AppRole
        {
            Admin = 0,
            ApplicationUser = 1 
        }

        public enum FrmName
        {
            //File
            ProductDetail =1,
            Supplier = 2,
            Transport = 3,
            StoredTareFile = 4,

            //Config
            AddEditUser = 30
        }

        public enum enumProduct
        {
            Code = 0,
            Name = 1
        }

        public enum enumSupplierTransportfrm
        {
            Id = 0,
            SupplierTransportCode = 1,
            SupplierTransportName = 2,
            Address1 = 3,
            Address2 = 4,
            Address3 = 5,
            Phone = 6,
            Fax = 7,
            Email = 8
        }

        public enum AddUser
        {
            RoleId = 0,
            UserName = 1,
            Password = 2,
            RoleType = 3
        }


        public enum enumStoredTareFilefrm
        {
            Id = 0,
            Truck = 1,
            TruckType = 2,
            TrasnportCode = 3,
            TareWeight = 4,
            DateIn = 5,
            TimeIn = 6
        }


        public enum enumStoredTareFileMode
        {
            Manual = 0,
            Auto =1
        }
    }
}
