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
    
    public partial class mapConstellationJump
    {
        public Nullable<int> fromRegionID { get; set; }
        public int fromConstellationID { get; set; }
        public int toConstellationID { get; set; }
        public Nullable<int> toRegionID { get; set; }
    
        public virtual mapConstellation fromConstellation { get; set; }
        public virtual mapConstellation toConstellation { get; set; }
        public virtual mapRegion fromRegion { get; set; }
        public virtual mapRegion toRegion { get; set; }
    }
}
