using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet5.Models
{
    public partial class JSON
    {
        public virtual ICollection<JsonCompetence> competences { get; set; }
        public virtual ICollection<Anne> annes { get; set; }
        public JSON()
        {
            this.annes = new List<Anne>();
            this.competences = new List<JsonCompetence>();

        }
    }
}



