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
    
    public partial class Employees_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees_()
        {
            this.PavilionsLease_ = new HashSet<PavilionsLease_>();
        }
    
        public int EmployeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public byte[] EmployeePhoto { get; set; }
    
        public virtual Roles_ Roles_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PavilionsLease_> PavilionsLease_ { get; set; }
    }
}
