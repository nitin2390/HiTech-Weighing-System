namespace HitechTMS
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
            ProductDetail =1,
            Supplier = 2,
            Transport = 3
        }

        public enum enumProduct
        {
            Code = 0,
            Name = 1
        }
        public enum enumSupplier
        {
            SupplierCode = 0,
            SupplierName = 1,
            Address1 = 2,
            Address2 = 3,
            Address3 = 4,
            Phone = 5,
            Fax = 6,
            email = 7
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
    }
}
