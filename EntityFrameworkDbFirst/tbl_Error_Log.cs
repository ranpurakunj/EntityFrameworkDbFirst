//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkDbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Error_Log
    {
        public int Error_Id { get; set; }
        public string Page_Name { get; set; }
        public string Method_Name { get; set; }
        public string Error_Msg { get; set; }
        public string Stack_Trace { get; set; }
        public Nullable<System.DateTime> Created_DateTime { get; set; }
    }
}
