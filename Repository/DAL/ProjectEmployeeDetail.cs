//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectEmployeeDetail
    {
        public decimal Id { get; set; }
        public Nullable<decimal> EmployeeCode { get; set; }
        public string ProjectCode { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
