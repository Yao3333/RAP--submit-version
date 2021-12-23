using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public enum EmploymentLevel { Student, A, B, C, D, E }
    class Position
    {
        /// <summary>
        /// variables used for Position Object
        /// </summary>
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }



        //methods below:
        public string Title()
        {
            Dictionary<EmploymentLevel, string> StaffTitle = new Dictionary<EmploymentLevel, string>
            {
                {EmploymentLevel.Student, "Student"},
                {EmploymentLevel.A, "Post-doc"},
                {EmploymentLevel.B, "Lecturer"},
                {EmploymentLevel.C, "Senior Lecturer"},
                {EmploymentLevel.D, "Associate Professor"},
                {EmploymentLevel.E, "Professor"}
            };
            return StaffTitle[Level];
        }
        public string ToTitle(EmploymentLevel I)
        {
            return Start.ToShortDateString() + "--" + End.ToShortDateString() + Title();

        }
    }
}
