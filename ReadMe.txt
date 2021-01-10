1.GET Method
http://localhost:3232/api/Teacher/GetFreeTeachers?dateCode=1&timeSlot=2

2.GET Method
http://localhost:3232/api/Teacher/GetTeacherTimeTable?teacherCode=T0001

3.GET Method
http://localhost:3232/api/Teacher/ApplyLeave?date=2021-01-10 00:00:00.000&teachercode=T0001

4.GET Method
http://localhost:3232/api/Teacher/GetLeaveTeachers?dateCode=1&timeSlot=2

5.POST Method
http://localhost:3232/api/Main/AssignTeachers
Body:
{
  "TeacherCode": "T0001",
  "ClassName": "6A",
  "DateCode": 1,
  "TimeSlotCode": "2"

}

**DB Script attached here.
**teachers can View there Time Table Using NO2 Get Method.
**To Assign Teacher when Teacher Absent.need to get Leave teacher using NO4 get method.after that
Using NO1 get method we can get free teachers.and using NO5 post method we can assign a teacher.

