﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entity_Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HitechTruckMngtSystmDataBaseFileEntities : DbContext
    {
        public HitechTruckMngtSystmDataBaseFileEntities()
            : base("name=HitechTruckMngtSystmDataBaseFileEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserRoleType> UserRoleTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<EmailMaster> EmailMasters { get; set; }
        public virtual DbSet<EmailConfig> EmailConfigs { get; set; }
        public virtual DbSet<mstSupplierTransporter> mstSupplierTransporter { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<mstStoredTareRecords> mstStoredTareRecords { get; set; }
        public virtual DbSet<transNormalWeight> transNormalWeight { get; set; }
        public virtual DbSet<transPublicWeight> transPublicWeight { get; set; }
    }
}
