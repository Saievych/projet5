using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial class DbCompetence
    {
            public int _id { get; set; }
            public string _semestre { get; set; }
            public string _code { get; set; }
            public string _description { get; set; }
            public string _link { get; set; }

            public virtual ICollection<competud> _competuds { get; set; }       
            public virtual ICollection<cour> _cours { get; set; }          
            public virtual ICollection<competence> _competences_Par { get; set; }
            public virtual ICollection<competence> _competences_Son { get; set; }
            public virtual ICollection<professeur> _professeurs { get; set; }

            public DbCompetence()
            {
            this._competuds = new List<competud>();
            this._cours = new List<cour>();
            this._competences_Par = new List<competence>();
            this._competences_Son = new List<competence>();
            this._professeurs = new List<professeur>();
            }
    }
    }



