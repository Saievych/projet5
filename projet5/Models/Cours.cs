using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial class Cours
    {
        public string _nom { get; set; }
        public virtual ICollection<ReadCompetence> _competences { get; set; }
        public virtual ICollection<Professeur> _prof { get; set; }
        public Cours()
        {
            this._prof = new List<Professeur>();
            this._competences = new List<ReadCompetence>();
        }
    }
    
}
