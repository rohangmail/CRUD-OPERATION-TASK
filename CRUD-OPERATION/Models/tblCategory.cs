//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_OPERATION.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> ProductName { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
    }
}