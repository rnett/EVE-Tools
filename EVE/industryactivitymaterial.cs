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
    
    public partial class industryActivityMaterial
    {
        public int blueprintTypeID { get; set; }
        public byte activityID { get; set; }
        public int materialTypeID { get; set; }
        public Nullable<int> quantity { get; set; }
    
        public virtual industryActivity industryActivity { get; set; }
        public virtual invType materialType { get; set; }
    }
}
