using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial class DbCours
    {
       

        public int _id { get; set; }
        public string _nom { get; set; }
        public string _lien { get; set; }
        public string _desc { get; set; }        
        public virtual ICollection<competence> _competences { get; set; }
        public virtual ICollection<etudiant> _etudiants { get; set; }
        public virtual ICollection<professeur> _professeurs { get; set; }

        public DbCours()
        {
            this._competences = new List<competence>();
            this._etudiants = new List<etudiant>();
            this._professeurs = new List<professeur>();
        }
    }
}

