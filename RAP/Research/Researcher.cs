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

        public Position Position { get; set; }
        
        //methods below
        public Position GetCurrentJob()
        {
            Position ps = new Position();
            return ps;
        }
        public String CurrentJobTitle()
        {
            return "";//返回信息
        }
        public DateTime CurrentJobStart()
        {
            return DateTime.Now;//返回信息
        }
        public Position GetEarliestJob()
        {
            Position ps = new Position();
            return ps;
        }
        public DateTime EarliestStart()
        {
            return DateTime.Now;//返回信息
        }
        public float Tenure()
        {
            return 0;
        }
        public int PublicationsCount() { return 0; }

    }
}
