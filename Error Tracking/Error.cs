//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Error_Tracking
{
    using System;
    using System.Collections.Generic;
    
    public partial class Error
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public string Resolution { get; set; }
        public int SoftwareKey { get; set; }
    
        public virtual Software Software { get; set; }
    }
}
