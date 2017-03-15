using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial class ReadEtud
    {
        public int _id { get; set; }
        public string _nom { get; set; }
        public string _prenom { get; set; }
        public string _parcours { get; set; }
        public string _domaine { get; set; }
        public string _mail { get; set; }
        public virtual ICollection<ReadCompEtud_Etud> _competuds { get; set; }
        public virtual ICollection<ReadCours> _cours { get; set; }


        public ReadEtud()
        {
            this._competuds = new List<ReadCompEtud_Etud>();
            this._cours = new List<ReadCours>();
        }
    }
}
