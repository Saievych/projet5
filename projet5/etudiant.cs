//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projet5
{
    using System;
    using System.Collections.Generic;
    
    public partial class etudiant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public etudiant()
        {
            this.competuds = new HashSet<competud>();
            this.cours = new HashSet<cour>();
        }
    
        public int identifiant { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string annee { get; set; }
        public string parcours { get; set; }
        public string domaine { get; set; }
        public string mel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<competud> competuds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cour> cours { get; set; }
    }
}