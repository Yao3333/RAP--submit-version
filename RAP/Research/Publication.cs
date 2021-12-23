using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public enum OutputType { Conference, Journal, Other }
    class Publication
    {

        public String Doi { get; set; }
        public String Title { get; set; }
        public String Authors { get; set; }
        public int PublicationYear { get; set; }
        public OutputType Type { get; set; }
        public String CiteAs { get; set; }
        public DateTime AvailableDate { get; set; }

        public int Age()
        {
            return DateTime.Today.Year - PublicationYear;

        }
    }
}
