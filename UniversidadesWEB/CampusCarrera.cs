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
    using System.Collections.Generic;
    
    public partial class CampusCarrera
    {
        public int idCam { get; set; }
        public int idIns { get; set; }
        public int idCar { get; set; }
        public string blank { get; set; }
    
        public virtual Campus Campus { get; set; }
        public virtual InstitucionCarrera InstitucionCarrera { get; set; }
    }
}
