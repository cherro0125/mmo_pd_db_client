//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mmo_pd_db_client
{
    using System;
    using System.Collections.Generic;
    
    public partial class WYGLAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WYGLAD()
        {
            this.POSTACIEs = new HashSet<POSTACIE>();
        }
    
        public decimal ID { get; set; }
        public string SEX { get; set; }
        public decimal HEIGHT { get; set; }
        public decimal CHEST_WIDTH { get; set; }
        public string SKIN_COLOR { get; set; }
        public string HAIR_COLOR { get; set; }
        public string EYE_COLOR { get; set; }
        public bool HAIR_TYPE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POSTACIE> POSTACIEs { get; set; }
    }
}
