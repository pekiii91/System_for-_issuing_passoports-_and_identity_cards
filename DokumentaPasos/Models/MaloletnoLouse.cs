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

    public partial class MaloletnoLouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaloletnoLouse()
        {
            this.Pasos = new HashSet<Paso>();
        }

        [Key]
        public int MaloletnoLiceID { get; set; }

        [Required(ErrorMessage = "Please your uverenje o drzavljanstvu")]
        [Display(Name = "Uverenje O Drzavljanstvu")]
        public string UverenjeODrzavljanstvu { get; set; }

        [Required(ErrorMessage = "Please your izvod maticne knjige rodjenih")]
        [Display(Name = "Izvod Maticne Knjige Rodjenih")]
        public string IzvodMaticneKnjigeRodjenih { get; set; }

        [Required(ErrorMessage = "Please your uplacene naknade")]
        [Display(Name = "Uplacene Naknade")]
        public string UplaceneNaknade { get; set; }

        [Required(ErrorMessage = "Please your saglasnost roditelja")]
        [Display(Name = "Saglasnost Roditelja")]
        public string SaglasnostRoditelja { get; set; }

        [Required(ErrorMessage = "Please your fotografija")]
        public string Fotografija { get; set; }

        [Required(ErrorMessage = "Please your rok vazenja")]
        [Display(Name = "Rok Vazenja")]
        public string RokVazenja { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paso> Pasos { get; set; }
    }
}
