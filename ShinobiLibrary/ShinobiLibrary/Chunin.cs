using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinobiLibrary
{
    public class Chunin: Shinobi
    {
        public Chunin(string firstname, string lastname, int missioncompleted, int missionassigned, int chakralevel, DateTime dob, bool isactive, string specialty)
            : base(firstname, lastname, missioncompleted, missionassigned, chakralevel, dob, isactive, specialty)
        { 
        }
    }
}
