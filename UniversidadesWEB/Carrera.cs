//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversidadesWEB
{
    using System;
    using System.Collections.ObjectModel ;
    
    public partial class Carrera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carrera()
        {
            this.InstitucionCarrera = new ObservableCollection<InstitucionCarrera>();
        }
    
        public int idCar { get; set; }
        public string nombreCarr { get; set; }
        public string Area { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InstitucionCarrera> InstitucionCarrera { get; set; }
    }
}
