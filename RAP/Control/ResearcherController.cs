using RAP.Research;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Control
{
    class ResearcherController
    {
        //创建 list 储存 数据对象 （将被加载的 ，已完成赋值在 ERDAdapter）


        //1.
        public static void LoadReseachers()
        {

        }

        //2.通过类别过滤 LINQ
        public static void FilterBy(EmploymentLevel level)
        {
            var selected = from Researcher r in Researchers
                           where r.level == level
                           select r;
            visibleResearchers.Clear();
            selected.ToList().ForEach(visibleResearchers.Add);
        }


        //3.通过姓名过滤 LINQ
        public static void FilterByName(String name)
        {
            var selected = from Researcher r in Researchers
                           where r.givenName.Contains(name) || r.familyName.Contains(name)
                           select r;
            visibleResearchers.Clear();
            selected.ToList().ForEach(visibleResearchers.Add);
        }

        //4.
        public static void LoadResearcherDetails()
        {

        }
    }
}
