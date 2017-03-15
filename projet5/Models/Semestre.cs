using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial  class Semestre
    {
        public string _semestre { get; set; }
        public virtual ICollection<Cours> _cours { get; set; }
        public Semestre()
        {
            this._cours = new List<Cours>();
        }
    }
}
