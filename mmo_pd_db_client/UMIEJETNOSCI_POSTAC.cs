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
    
    public partial class UMIEJETNOSCI_POSTAC
    {
        public decimal ID { get; set; }
        public Nullable<decimal> CHAR_ID { get; set; }
        public Nullable<decimal> SKILL_ID { get; set; }
    
        public virtual POSTACIE POSTACIE { get; set; }
        public virtual UMIEJETNOSCI UMIEJETNOSCI { get; set; }
    }
}