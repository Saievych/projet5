using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial  class ReadCompetence
    {
        public int _id { get; set; }
        public string _code { get; set; }
        public string _description { get; set; }
        public string _link { get; set; }
        //public string _cours { get; set; }
        //public string _semestre { get; set; }
        public virtual ICollection<ReadCompEtud_Comp> _competuds { get; set; }
        //public virtual ICollection<ReadCours> _cours { get; set; }          
        public virtual ICollection<CompRelation> _competences_Par { get; set; }
        public virtual ICollection<CompRelation> _competences_Son { get; set; }
        //public virtual ICollection<Professeur> _prof { get; set; }

        public ReadCompetence()
        {
            this._competuds = new List<ReadCompEtud_Comp>();
            // this._cours = new List<ReadCours>();
            this._competences_Par = new List<CompRelation> ();
            this._competences_Son = new List<CompRelation> ();
            //this._prof = new List<Professeur>();
        }
    }
}
