//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class rentals_details
    {
        public int RentalDetails_id { get; set; }
        public int rent_id { get; set; }
        public System.DateTime date { get; set; }
        public string status { get; set; }
    
        public virtual Rentals Rentals { get; set; }
    }
}