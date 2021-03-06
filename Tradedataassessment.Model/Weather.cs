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
    
    public partial class Weather : IEntity
    {
        public int Id { get; set; }
        public int City_Id { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<decimal> WindSpeed { get; set; }
        public Nullable<decimal> WindDirection { get; set; }
        public Nullable<long> Sunrise { get; set; }
        public Nullable<long> Sunset { get; set; }
        public Nullable<decimal> Temperature { get; set; }
        public Nullable<decimal> Pressure { get; set; }
        public Nullable<decimal> Humidity { get; set; }
        public Nullable<decimal> TempMin { get; set; }
        public Nullable<decimal> TempMax { get; set; }
        public Nullable<decimal> Cloudiness { get; set; }
    
        public virtual CapitalCity CapitalCity { get; set; }
    }
}
