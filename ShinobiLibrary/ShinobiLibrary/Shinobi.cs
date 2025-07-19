using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinobiLibrary
{
    public abstract class Shinobi
    {
       
        private string firstName;
        private string lastName;
        private int chakraLevel;
        private DateTime dateOfBirth;
        private int missionAssigned;
        private bool isActive;
        private string specialty;
        private int missionCompleted;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    firstName = value;
                else
                    firstName = "Unknown";
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    lastName = value;
                else
                    lastName = "Unknown";
            }
        }

        public int MissionCompleted 
        { 
            get => missionCompleted;
            set {
                if (missionAssigned >= value)
                    missionCompleted = value;
                else
                    throw new Exception("ERROR: Mission Assigned cannot be greater than mission completed");
                
            }
        }

        public int MissionAssigned
        {
            get => missionAssigned;
            set
            {
                if (value >= 0)
                missionAssigned = value;
                else
                    missionAssigned = 0;
            }
        }

        public int ChakraLevel
        {
            get => chakraLevel;
            set
            {
                if (value >= 20)
                    chakraLevel = value;
                else
                    chakraLevel = 20;
            }
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set=> dateOfBirth = value;
        }

        public bool IsActive
        {
            get => isActive;
            set => isActive = value;
        }

        public string Specialty
        {
            get => specialty;
            set
            {
            if(!string.IsNullOrEmpty(value)) 
                    specialty = value;
            else
                    specialty = "Unknown";
            }
        }

       public int Age => DateTime.Now.Year - DateOfBirth.Year;

       public Shinobi(string firstname, string lastname, int missioncompleted, int missionassigned, int chakralevel, DateTime dob, bool isactive, string specialty)
        {
            FirstName = firstname; 
            LastName = lastname;
            MissionAssigned = missionassigned;
            MissionCompleted = missioncompleted;
            ChakraLevel = chakralevel;
            DateOfBirth = dob;
            IsActive = isactive;
            Specialty = specialty;
        }

        public virtual double MissionSuccessRate() {
            if (MissionAssigned == 0)
            {
                return 0;
            }
            else
            {
                return ((double)MissionCompleted / MissionAssigned) * 100;
            }
        }
    }
}
