using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAppCommon.ViewModels
{
    public class Student_VM
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string FirstInsertedBy { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        public string GenderDisplay { 
            get {
                if (Gender == "M")
                {
                    return "Male";
                }
                else
                {
                    return "Female";
                }
            }                   
        }
    }
}
