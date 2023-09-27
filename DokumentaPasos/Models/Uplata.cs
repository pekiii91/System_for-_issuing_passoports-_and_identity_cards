//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DokumentaPasos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Uplata
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uplata()
        {
            this.Pasos = new HashSet<Paso>();
        }

        [Key]
        public int UplataID { get; set; }

        [Required(ErrorMessage = "Please your obrazac putne isprave")]
        [Display(Name = "Obrazac Putne Isprave")]
        public string ObrzacPutneIsprave { get; set; }

        [Required(ErrorMessage = "Please your administrativna taksa")]
        [Display(Name = "Administrativna Taksa")]
        public string AdministrativnaTaksa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paso> Pasos { get; set; }
    }
}
