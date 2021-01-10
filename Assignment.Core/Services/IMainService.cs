using Core.Common;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IMainService
    {
        Response GetLeaveTeachersByDate(DateTime date);
        Response AssignTeachers(TeacherModel teacherModel);
    }
}
