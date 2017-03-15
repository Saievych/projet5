using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace projet5.Models
{
    public partial class DbEtudiants
    {
        public int _id { get; set; }
        public string _nom { get; set; }
        public string _prenom { get; set; }
        public string _annee { get; set; }
        public string _parcours { get; set; }
        public string _domaine { get; set; }
        public string _mail { get; set; }
        public virtual ICollection<competud> _competuds { get; set; }
        public virtual ICollection<cour> _cours { get; set; }

        public DbEtudiants()
        {
            this._competuds = new List<competud>();
            this._cours = new List<cour>();
        }

    }
}

