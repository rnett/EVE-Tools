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
    
    public partial class ore
    {
        public int typeID { get; set; }
        public string name { get; set; }
        public int Tritanium { get; set; }
        public int Pyerite { get; set; }
        public int Mexallon { get; set; }
        public int Isogen { get; set; }
        public int Nocxium { get; set; }
        public int Zydrine { get; set; }
        public int Megacyte { get; set; }
        public int Morphite { get; set; }
    
        public virtual invType invType { get; set; }
    }
}
