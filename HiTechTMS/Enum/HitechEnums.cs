namespace HitechTMS
{
    public class HitechEnums
    {
        public enum AppRole
        {
            Admin = 0,
            ApplicationUser = 1,
            SuperAdmin = 2,
            Supervisor = 3
        }

        public enum enumfrmNormalPendingHeader
        {
            Truck = 0,
            ProductName = 1,
            SupplierName = 2,
            TransporterName = 3,
            ChallanNumber = 4,
            ChallanDate = 5,
            ChallanWeight = 6,
            ChallanWeightUnit = 7,
            GrossWeight = 8,
            TareWeight = 9,
            ProdInOut = 10
        }

        public enum FrmName
        {
            //File
            ProductDetail = 1,
            Supplier = 2,
            Transport = 3,
            StoredTareFile = 4,

            //Weighing 
            NormalWeighing = 21,
            PublicWeighing = 22,
            MultiWeghing = 23,

            NormalPendingFile = 24,
            PublicPendingFile = 25,
            MultiPendingFile = 26,

            NormalCompleteFile = 27,
            PublicCompleteFile = 28,
            MultiCompleteFile = 29,

            //Config
            AddEditUser = 30,
            EmailConfig = 31,
            HyperTerminalConfiguration = 32,
            GenralSetting = 33,
            ShiftAllocation = 34,
            WeighBridgeSetup=35
        }

        public enum enumProduct
        {
            Code = 0,
            Name = 1
        }

        public enum enumProductNormalPublicMulti
        {
            Normal = 0,
            Public = 1,
            Multi = 2
        }

        public enum enumProductInOut
        {
            In = 0,
            Out = 1,
            Other = 2
        }

        public enum enumShiftAllocation
        {
            One = 1,
            Two = 2,
            Three = 3
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

        public enum enumTransPublicWeight
        {
            Id = 0,
            Mode,
            Truck,
            Miscellaneous,
            DateIn,
            DateOut,
            TimeIn,
            TimeOut,
            TareWeight,
            GrossWeight,
            NetWeight,
            ProdInOut,
            IsPending,
            AddedDate,
            UpdatedDate
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
            TransportCode = 3,
            TransportName = 4,
            DateIn = 5,
            TimeIn = 6,
            TareWeight = 7
        }


        public enum enumWeightMode
        {
            Manual = 0,
            Auto = 1,
            Semi = 2
        }


        public enum enumWeightUnit
        {
            t = 0,
            kg = 1
        }

        public enum enumYesNo
        {
            No = 0,
            Yes = 1
        }

        public enum enumTicket
        {
            HalfTicket = 0,
            FullTicket = 1
        }

        public enum enumReportFormat
        {
            Compressed = 0,
            Details = 1
        }
        public enum enumReportPrinting
        {
            Draft = 0,
            Graphical = 1
        }
        public enum enumUnits
        {
            kilogram = 0,
            tonne = 1
        }
    }


}
