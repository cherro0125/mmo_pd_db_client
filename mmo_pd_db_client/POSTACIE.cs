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
    
    public partial class POSTACIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POSTACIE()
        {
            this.UMIEJETNOSCI_POSTAC = new HashSet<UMIEJETNOSCI_POSTAC>();
        }
    
        public decimal ID { get; set; }
        public string NICKNAME { get; set; }
        public Nullable<decimal> STAT_ID { get; set; }
        public Nullable<decimal> ACC_ID { get; set; }
        public Nullable<decimal> RACE_ID { get; set; }
        public Nullable<decimal> CLASS_ID { get; set; }
        public Nullable<decimal> LOOK_ID { get; set; }
        public Nullable<decimal> POS_ID { get; set; }
    
        public virtual KLASY_POSTACI KLASY_POSTACI { get; set; }
        public virtual KONTA KONTA { get; set; }
        public virtual POZYCJE POZYCJE { get; set; }
        public virtual RASY RASY { get; set; }
        public virtual STATYSTYKI STATYSTYKI { get; set; }
        public virtual WYGLAD WYGLAD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UMIEJETNOSCI_POSTAC> UMIEJETNOSCI_POSTAC { get; set; }
    }
}
