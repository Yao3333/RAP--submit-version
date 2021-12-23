using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{

    public enum Campus { Hobart, Launceston, CradleCoast }
    public enum ResearcherType { Staff, Student }

    class Researcher
    {


        public int ID { get; set; }
        public ResearcherType researcherType { get; set; }
        public String GivenName { get; set; }
        public String FamilyName { get; set; }
        public String Title { get; set; }
        public String Unit { get; set; }
        public String School { get; set; }
        public Campus Campus { get; set; }
        public String Email { get; set; }
        public String Photo { get; set; }



        //methods below
        public Position GetCurrentJob()
        {

        }
        public String CurrentJobTitle() { }
        public DateTime CurrentJobStart() { }
        public Position GetEarliestJob() { }
        public DateTime EarliestStart() { }
        public float Tenure() { }
        public int PublicationsCount() { }

    }
}
