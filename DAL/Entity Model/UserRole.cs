//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class UserRole
    {
        public System.Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public System.Guid UserRoleType { get; set; }
    
        public virtual UserRoleType UserRoleType1 { get; set; }
    }
}
