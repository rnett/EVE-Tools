//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EVE
{
    using System;
    using System.Collections.Generic;
    
    public partial class industryactivityprobability
    {
        public int typeID { get; set; }
        public int activityID { get; set; }
        public int productTypeID { get; set; }
        public Nullable<decimal> probability { get; set; }
    
        public virtual industryactivity industryactivity { get; set; }
        public virtual invtype invtype { get; set; }
    }
}