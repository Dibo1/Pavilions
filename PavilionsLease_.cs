//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pavilions
{
    using System;
    using System.Collections.Generic;
    
    public partial class PavilionsLease_
    {
        public int LeaseId { get; set; }
        public Nullable<int> TenantId { get; set; }
        public Nullable<int> MallId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> PavilionId { get; set; }
        public Nullable<System.DateTime> LeaseStart { get; set; }
        public Nullable<System.DateTime> C_LeaseEnd { get; set; }
    
        public virtual Employees_ Employees_ { get; set; }
        public virtual Malls_ Malls_ { get; set; }
        public virtual Pavilions_ Pavilions_ { get; set; }
        public virtual Tenants_ Tenants_ { get; set; }
    }
}
