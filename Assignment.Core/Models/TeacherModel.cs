using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class TeacherModel
    {
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string SubjectCode { get; set; }
        public string DateCode { get; set; }
        public DateTime LeaveDate { get; set; }
        public string TimeSlotCode { get; set; }
        public string ClassName { get; set; }
    }
}
