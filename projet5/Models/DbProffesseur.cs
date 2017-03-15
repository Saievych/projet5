using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    class DbProffesseur
    {
        public DbProffesseur()
        {
            this._competences = new List<competence>();
            this._cours = new List<cour>();
        }

        public int _profId { get; set; }
        public string _profPrenom { get; set; }
        public string _profNom { get; set; }
        public string _profMail { get; set; }
        public string _profPassword { get; set; }
        public virtual ICollection<competence> _competences { get; set; }
        public virtual ICollection<cour> _cours { get; set; }
    }
}




