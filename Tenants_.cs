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
    
    public partial class Tenants_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tenants_()
        {
            this.PavilionsLease_ = new HashSet<PavilionsLease_>();
        }
    
        public int TenantId { get; set; }
        public Nullable<int> RentId { get; set; }
        public string TenantName { get; set; }
        public string TenantPhone { get; set; }
        public string TenantAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PavilionsLease_> PavilionsLease_ { get; set; }
    }
}
