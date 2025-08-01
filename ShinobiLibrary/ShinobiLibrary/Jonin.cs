using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinobiLibrary
{
    public class Jonin : Shinobi
    {
        private bool isSquadLeader;
        private int missionLed;

        public bool IsSquadLeader
        {
            get => isSquadLeader;
            set => isSquadLeader = value;
        }

        public int MissionLed
        {
            get => missionLed;
            set
            {
                if (value <= MissionAssigned)
                    missionLed = value;
                else
                    throw new Exception("Mission led cannot be less than mission assigned");
            }
        }


        public Jonin(string firstname, string lastname, int missioncompleted, int missionassigned, int chakralevel, DateTime dob, bool isactive, string specialty, bool issquadleader, int missionled)
    : base(firstname, lastname, missioncompleted, missionassigned, chakralevel, dob, isactive, specialty)
        {
            IsSquadLeader = issquadleader;
            MissionLed = missionled;
        }
    }
}
