using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial class CompNotes
    {
        public virtual ICollection<Semestre> semesters { get; set; }
        public virtual ICollection<Anne> annes { get; set; }
        public CompNotes()
        {
            this.annes = new List<Anne>();
            this.semesters = new List<Semestre>();

        }
    }
}
