//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using TradedataAssessment.Model.Contracts;

namespace Tradedataassessment.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CapitalCity : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CapitalCity()
        {
            this.Weather = new HashSet<Weather>();
        }
    
        public Nullable<int> Country_Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
    
        public virtual Country Country1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Weather> Weather { get; set; }
    }
}
