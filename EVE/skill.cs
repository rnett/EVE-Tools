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
    
    public partial class skill
    {
        public int typeId { get; set; }
        public string typeName { get; set; }
        public int rank { get; set; }
        public int primaryAttr { get; set; }
        public int secondaryAttr { get; set; }
    
        public virtual invType invType { get; set; }
    }
}
