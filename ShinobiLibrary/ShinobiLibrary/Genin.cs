using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinobiLibrary
{
    public class Genin: Shinobi
    {
        private string assignedSensei;
        private bool requiresSupervision;

        public string AssignedSensei
        {
            get => assignedSensei;
            set => assignedSensei = value;
        }

        public bool RequiresSupervision
        {
            get => requiresSupervision;
            set
            {
                if (value == true)
                    requiresSupervision = value;
                else
                    throw new Exception("Every Genin needs a supervisor");
            }
        }

        public Genin(string firstname, string lastname, int missioncompleted, int missionassigned, int chakralevel, DateTime dob, bool isactive, string specialty, string assignedSensei, bool requiresSupervision)
            : base( firstname,  lastname,  missioncompleted,  missionassigned,  chakralevel,  dob,  isactive,  specialty)
        {
            AssignedSensei = assignedSensei;
            RequiresSupervision = requiresSupervision;
        }
    }
}
