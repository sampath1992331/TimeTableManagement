using Core.Common;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Services
{
    public interface ITeacherService
    {
        Response GetTeacherTimeTable(string teacherCode);
        Response GetFreeTeachers(string dateCode, string timeSlot);
        Response ApplyLeave(DateTime date, string teachercode);
        Response GetLeaveTeachers(string dateCode, string timeSlot);
    }
}
