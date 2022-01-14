using RAP.Research;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Control
{
    class ResearcherController
    {
        //创建 list 储存 数据对象 （将被加载的 ，已完成赋值在 ERDAdapter）

        public static List<Researcher> Researchers = new List<Researcher>();
        public static Researcher detail = null;
        //1.
        public static void LoadReseachers(string name="",string level="")
        {
            Researchers = EADAdapter.fetchBasicResearcherDetails( name ,  level);
        }


        private static ObservableCollection<Researcher> visibleResearchers = new ObservableCollection<Researcher>();
        // public ObservableCollection<Employee> VisibleWorkers { get { return viewableStaff; } set { } }

        //2.通过类别过滤 LINQ
        public static void FilterBy(EmploymentLevel level)
        {
            var filtered = from Researcher r in Researchers
                           where r.Position.Level == level
                           select r;
            visibleResearchers.Clear();
            filtered.ToList().ForEach(visibleResearchers.Add);
        }


        //3.通过姓名过滤 LINQ
        public static void FilterByName(String name)
        {
            var filtered = from Researcher r in Researchers
                           where r.GivenName.Contains(name) || r.FamilyName.Contains(name)
                           select r;
            visibleResearchers.Clear();
            filtered.ToList().ForEach(visibleResearchers.Add);
        }

        //4.
        public static void LoadResearcherDetails(int id)
        {
            Researcher r = new Researcher();
            r.ID = id;
            detail= EADAdapter.completeResearcherDetails(r);
        }
    }
}
