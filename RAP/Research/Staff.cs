using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    class Staff : Researcher
    {

        float threeYearAverage;
        /// <summary>
        /// fuctions for calculated data.
        /// </summary>
        public float ThreeYearAverage(List<Publication> publications)
        {
            int currentYear = DateTime.Today.Year;
            int threeYearTotal = (from Publication p in publications
                                  where p.PublicationYear == (currentYear - 1) || p.PublicationYear == (currentYear - 2) || p.PublicationYear == (currentYear - 3)
                                  select p).Count();

            threeYearAverage = threeYearTotal / 3;
            return threeYearAverage;
        }


        public float Performance()
        {

            float tempThreeAver = threeYearAverage;
            Researcher rsMethod = new Researcher();//TODO
            EmploymentLevel level = rsMethod.GetCurrentJob().Level;


            Dictionary<EmploymentLevel, float> ExpPubNumDic = new Dictionary<EmploymentLevel, float>
            {
                {EmploymentLevel.A, 0.5f},
                {EmploymentLevel.B, 1},
                {EmploymentLevel.C, 2},
                {EmploymentLevel.D, 3.2f},
                {EmploymentLevel.E, 4}
            };
            return tempThreeAver / ExpPubNumDic[level];

        }
    }
}
