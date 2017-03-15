using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial class Anne
    {
        public string _anne { get; set; }
        public virtual ICollection<ReadEtud> _etudiants { get; set; }

        public Anne()
        {
            this._etudiants = new List<ReadEtud>();
        }
    }
}
