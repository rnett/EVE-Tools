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
    
    public partial class mapRegion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mapRegion()
        {
            this.constellationJumpsFrom = new HashSet<mapConstellationJump>();
            this.constellationJumpsTo = new HashSet<mapConstellationJump>();
            this.mapConstellations = new HashSet<mapConstellation>();
            this.systemJumpsFrom = new HashSet<mapSolarSystemJump>();
            this.systemJumpsTo = new HashSet<mapSolarSystemJump>();
            this.mapSolarSystems = new HashSet<mapSolarSystem>();
            this.jumpsFrom = new HashSet<mapRegion>();
            this.jumpsTo = new HashSet<mapRegion>();
        }
    
        public int regionID { get; set; }
        public string regionName { get; set; }
        public Nullable<float> x { get; set; }
        public Nullable<float> y { get; set; }
        public Nullable<float> z { get; set; }
        public Nullable<float> x_Min { get; set; }
        public Nullable<float> x_Max { get; set; }
        public Nullable<float> y_Min { get; set; }
        public Nullable<float> y_Max { get; set; }
        public Nullable<float> z_Min { get; set; }
        public Nullable<float> z_Max { get; set; }
        public Nullable<int> factionID { get; set; }
        public Nullable<int> nameID { get; set; }
        public Nullable<int> descriptionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapConstellationJump> constellationJumpsFrom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapConstellationJump> constellationJumpsTo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapConstellation> mapConstellations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapSolarSystemJump> systemJumpsFrom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapSolarSystemJump> systemJumpsTo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapSolarSystem> mapSolarSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapRegion> jumpsFrom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapRegion> jumpsTo { get; set; }
    }
}
