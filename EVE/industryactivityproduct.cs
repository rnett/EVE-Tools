//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDEModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class industryActivityProduct
    {
        public int blueprintTypeID { get; set; }
        public byte activityID { get; set; }
        public int productTypeID { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<double> probability { get; set; }
    
        public virtual invType productType { get; set; }
        public virtual industryActivity industryActivity { get; set; }
    }
}
