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
    
    public partial class mapSolarSystemJump
    {
        public Nullable<int> fromRegionID { get; set; }
        public Nullable<int> fromConstellationID { get; set; }
        public int fromSolarSystemID { get; set; }
        public int toSolarSystemID { get; set; }
        public Nullable<int> toConstellationID { get; set; }
        public Nullable<int> toRegionID { get; set; }
    
        public virtual mapConstellation fromConstellation { get; set; }
        public virtual mapConstellation toConstellation { get; set; }
        public virtual mapRegion fromRegion { get; set; }
        public virtual mapRegion toRegion { get; set; }
        public virtual mapSolarSystem fromSystem { get; set; }
        public virtual mapSolarSystem toSystem { get; set; }
    }
}
