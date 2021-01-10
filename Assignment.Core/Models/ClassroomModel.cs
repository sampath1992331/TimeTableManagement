using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ClassroomModel
    {
       
        public string ClassName { get; set; }
        public string DateCode { get; set; }
        public string TimeSlotCode { get; set; }
        public string SubjectCode { get; set; }

        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }
}
