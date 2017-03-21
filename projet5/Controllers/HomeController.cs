using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projet5.Models;


namespace projet5.Controllers
{
    public class HomeController : Controller
    {
        private DbConnection db = new DbConnection();

        public List<Anne> getEtudiants()
        {
            List<Anne> TmpAnne = new List<Anne>();
            var Etudiant = from etudiant in db.etudiants
                           select new DbEtudiants
                           {
                               _id = etudiant.identifiant,
                               _annee = etudiant.annee,
                               _nom = etudiant.nom,
                               _prenom = etudiant.prenom,
                               _parcours = etudiant.parcours,
                               _domaine = etudiant.domaine,
                               _mail = etudiant.mel,
                               _competuds = etudiant.competuds.ToList<competud>()
                           };

            TmpAnne.Add(new Anne { _anne = "L1", });
            TmpAnne.Add(new Anne { _anne = "L2", });
            TmpAnne.Add(new Anne { _anne = "L3", });
            TmpAnne.Add(new Anne { _anne = "M1", });
            TmpAnne.Add(new Anne { _anne = "M2", });
            foreach (DbEtudiants etud in Etudiant)
            {
                
                ReadEtud tmp = new ReadEtud();
                tmp._id = etud._id;
                tmp._nom = etud._nom;
                tmp._prenom = etud._prenom;
                tmp._parcours = etud._parcours;
                tmp._mail = etud._mail;
                tmp._domaine = etud._domaine;
                for (int i = 0; i < etud._cours.Count(); i++)
                {
                    tmp._cours.Add(new ReadCours
                    {
                        _id = etud._cours.ElementAt(i).Cours_id,
                        _nom = etud._cours.ElementAt(i).Cours_nom,
                        _lien = etud._cours.ElementAt(i).Cours_lien,
                        _desc = etud._cours.ElementAt(i).Cours_desc
                    });
                }
                for (int i = 0; i < etud._competuds.Count(); i++)
                    tmp._competuds.Add(new ReadCompEtud_Etud
                    {
                        _CompetenceId = etud._competuds.ElementAt(i).CompEtud_CompetenceId,
                        _Etat = etud._competuds.ElementAt(i).CompEtud_Etat
                    });
                switch (etud._annee)
                {
                    case "L1":
                        TmpAnne.Find(q => q._anne == "L1")._etudiants.Add(tmp);
                        break;
                    case "L2":
                        TmpAnne.Find(q => q._anne == "L2")._etudiants.Add(tmp);
                        break;
                    case "L3":
                        TmpAnne.Find(q => q._anne == "L3")._etudiants.Add(tmp);
                        break;
                    case "M1":
                        TmpAnne.Find(q => q._anne == "M1")._etudiants.Add(tmp);
                        break;
                    case "M2":
                        TmpAnne.Find(q => q._anne == "M2")._etudiants.Add(tmp);
                        break;
                    default:
                        break;
                }
            }
            return TmpAnne;
        }
        public CompNotes getData()
        {
            int n = 10;
            CompNotes Notes = new CompNotes();
            List<Semestre> TmpSem = new List<Semestre>();
            List<Anne> TmpAnne = getEtudiants();

            var competence = from competences in db.competences
                              select new DbCompetence
                              {
                                  _id = competences.Competence_id,
                                  _semestre = competences.Semestre,
                                  _code = competences.Code,
                                  _description = competences.Description,
                                  _link = competences.WWW,
                                  _competuds = competences.competuds.ToList<competud>(),
                                  _cours = competences.cours.ToList<cour>(),
                                  _professeurs = competences.professeurs.ToList<professeur>()
                                  
                              };

            for (int i = 0; i < n; i++)
                TmpSem.Add(new Semestre { _semestre = "S" + (i + 1).ToString(), });
            foreach (DbCompetence comp in competence)
            {
                ReadCompetence tmp = new ReadCompetence();
                tmp._code = comp._code;
                tmp._description = comp._description;
                tmp._id = comp._id;
                tmp._link = comp._link;
                for (int i = 0; i < comp._competuds.Count(); i++)
                    tmp._competuds.Add(new ReadCompEtud_Comp
                    {
                        _EtudiantId = comp._competuds.ElementAt(i).CompEtud_EtudiantId,
                        _Etat = comp._competuds.ElementAt(i).CompEtud_Etat
                    });
                List<Professeur> tmp_prof = new List<Professeur>();
                for (int i = 0; i < comp._professeurs.Count(); i++)
                    tmp_prof.Add(new Professeur
                    {
                        Professeur_id = comp._professeurs.ElementAt(i).Professeur_id,
                        Professeur_nom = comp._professeurs.ElementAt(i).Professeur_nom,
                        Professeur_prenom = comp._professeurs.ElementAt(i).Professeur_prenom
                    });
                switch (comp._semestre)
                {
                    case "S1":
                        if (TmpSem.Find(q => q._semestre == "S1")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S1")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S1")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    case "S2":
                        if (TmpSem.Find(q => q._semestre == "S2")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S2")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S2")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    case "S3":
                        if (TmpSem.Find(q => q._semestre == "S3")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S3")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S3")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    case "S4":
                        if (TmpSem.Find(q => q._semestre == "S4")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S4")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S4")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    case "S5":
                        if (TmpSem.Find(q => q._semestre == "S5")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S5")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S5")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    case "S6":
                        if (TmpSem.Find(q => q._semestre == "S6")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S6")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S6")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                              }
                        break;
                    case "S7":
                        if (TmpSem.Find(q => q._semestre == "S7")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S7")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S7")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    case "S8":
                        if (TmpSem.Find(q => q._semestre == "S8")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S8")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S8")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    case "S9":
                        if (TmpSem.Find(q => q._semestre == "S9")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S9")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S9")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                          }
                        break;
                    case "S10":
                        if (TmpSem.Find(q => q._semestre == "S10")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom) == null)
                        {
                            Cours c = new Cours();
                            c._nom = comp._cours.First<cour>().Cours_nom;
                            c._id = comp._cours.First<cour>().Cours_id;
                            c._competences.Add(tmp);
                            c._prof = null;
                            TmpSem.Find(q => q._semestre == "S10")._cours.Add(c);
                        }
                        else
                        {
                            TmpSem.Find(q => q._semestre == "S10")._cours.ToList().Find(f => f._nom == comp._cours.First<cour>().Cours_nom)._competences.Add(tmp);
                        }
                        break;
                    
                    default:
                        break;
                }
            }
            var bdCours = from cour in db.cours
                          select new DbCours
                          {
                              _id = cour.Cours_id,
                              _desc = cour.Cours_desc,
                              _lien = cour.Cours_lien,
                              _nom = cour.Cours_nom,
                              _etudiants = cour.etudiants.ToList<etudiant>(),
                              _professeurs = cour.professeurs.ToList<professeur>()

                              };
            
            foreach (DbCours cours in bdCours)
            {
                Cours tmpCours = new Cours();
                tmpCours._nom = cours._nom;
                for (int i=0; i< cours._professeurs.Count();i++)
                    tmpCours._prof.Add(new Professeur
                    {
                        Professeur_id = cours._professeurs.ElementAt(i).Professeur_id,
                        Professeur_nom = cours._professeurs.ElementAt(i).Professeur_nom,
                        Professeur_prenom = cours._professeurs.ElementAt(i).Professeur_prenom
                    });
             foreach(Semestre sem in TmpSem)
                    if ((sem._cours.ToList().Find(q => q._nom == cours._nom)) != null)
                        sem._cours.ToList().Find(q => q._nom == cours._nom)._prof = tmpCours._prof;
            }
            Notes.annes = TmpAnne;
            Notes.semesters = TmpSem;
            return Notes;

        }

        public JSON getJson()
        {
            JSON Notes = new JSON();
            List<JsonCompetence> TmpComp = new List<JsonCompetence>();
            List<Anne> TmpAnne = getEtudiants();

            var competence = from competences in db.competences
                              select new DbCompetence
                              {
                                  _id = competences.Competence_id,
                                  _semestre = competences.Semestre,
                                  _code = competences.Code,
                                  _description = competences.Description,
                                  _link = competences.WWW,
                                  _competuds = competences.competuds.ToList<competud>(),
                                  _cours = competences.cours.ToList<cour>(),
                                  _professeurs = competences.professeurs.ToList<professeur>(),
                                  _competences_Son = competences.competences.ToList<competence>(),
                                  _competences_Par = competences.competences1.ToList<competence>() 
                              };

           
            foreach (DbCompetence comp in competence)
            {
                JsonCompetence tmp = new JsonCompetence();
                tmp._code = comp._code;
                tmp._description = comp._description;
                tmp._id = comp._id;
                tmp._link = comp._link;
                tmp._semestre = comp._semestre; 
                tmp._cours = comp._cours.First<cour>().Cours_nom;
                for (int i = 0; i < comp._competences_Par.Count(); i++)
                    tmp._competences_Par.Add(new CompRelation
                    {
                        _id = comp._competences_Par.ElementAt(i).Competence_id,
                        _code = comp._competences_Par.ElementAt(i).Code
                    });
                for (int i = 0; i < comp._competences_Son.Count(); i++)
                    tmp._competences_Son.Add(new CompRelation
                    {
                        _id = comp._competences_Son.ElementAt(i).Competence_id,
                        _code = comp._competences_Son.ElementAt(i).Code
                    });
                for (int i = 0; i < comp._professeurs.Count(); i++)
                    tmp._prof.Add(new Professeur
                    {
                        Professeur_id = comp._professeurs.ElementAt(i).Professeur_id,
                        Professeur_nom = comp._professeurs.ElementAt(i).Professeur_nom,
                        Professeur_prenom =comp._professeurs.ElementAt(i).Professeur_prenom
                    });
                
                  
                    TmpComp.Add(tmp);
                
            }
            //int m = 
            //    TmpAnne.Find((q => q._anne == "L1"))._etudiants.Count<ReadEtud>() + 
            //    TmpAnne.Find((q => q._anne == "L2"))._etudiants.Count<ReadEtud>() +
            //    TmpAnne.Find((q => q._anne == "L3"))._etudiants.Count<ReadEtud>() + 
            //    TmpAnne.Find((q => q._anne == "M1"))._etudiants.Count<ReadEtud>() +
            //    TmpAnne.Find((q => q._anne == "M2"))._etudiants.Count<ReadEtud>();


            Notes.annes = TmpAnne;
            Notes.competences = TmpComp;
            return Notes;

        }




        public ActionResult Index()
        {
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(getJson());

            ViewBag.VB = sJSON;
           CompNotes test = getData();
            return View(getData());
    }

        public ActionResult About()
        {
            ViewBag.Message = "Projet5";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}