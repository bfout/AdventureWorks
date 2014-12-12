//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdventureWorks.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusinessEntity
    {
        public BusinessEntity()
        {
            this.BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            this.BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }
    
        public int BusinessEntityID { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public virtual Person Person { get; set; }
        public virtual Store Store { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
