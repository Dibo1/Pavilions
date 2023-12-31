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
    
    public partial class Malls_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Malls_()
        {
            this.Pavilions_ = new HashSet<Pavilions_>();
            this.PavilionsLease_ = new HashSet<PavilionsLease_>();
        }
    
        public int MallId { get; set; }
        public string MallName { get; set; }
        public Nullable<int> MallStatusId { get; set; }
        public Nullable<int> PavilionsCount { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<double> BuildingCost { get; set; }
        public Nullable<double> ValueAddedFactor { get; set; }
        public Nullable<int> LevelsCount { get; set; }
        public byte[] MallPicture { get; set; }
    
        public virtual Cities_ Cities_ { get; set; }
        public virtual MallStatuses_ MallStatuses_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pavilions_> Pavilions_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PavilionsLease_> PavilionsLease_ { get; set; }
    }
}
