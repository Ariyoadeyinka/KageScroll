using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinobiLibrary
{
    public class Anbu:Shinobi
    {
        public string CodeName
        {
            get;
        }

        public Anbu(string firstname, string lastname, int missioncompleted, int missionassigned, int chakralevel, DateTime dob, bool isactive, string specialty, string codename)
            : base(firstname, lastname, missioncompleted, missionassigned, chakralevel, dob, isactive, specialty)
        {
            CodeName = codename;
        }
    }
}
