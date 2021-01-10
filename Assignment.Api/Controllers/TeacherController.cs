using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Api.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetTeacherTimeTable")]
        public Response GetTeacherTimeTable(string teacherCode)
        {
            return service.GetTeacherTimeTable(teacherCode);
        }

        [HttpGet]
        [Route("GetFreeTeachers")]
        public Response GetFreeTeachers(string dateCode, string timeSlot)
        {
            return service.GetFreeTeachers(dateCode, timeSlot);
        }
        [HttpGet]
        [Route("GetLeaveTeachers")]
        public Response GetLeaveTeachers(string dateCode, string timeSlot)
        {
            return service.GetLeaveTeachers(dateCode, timeSlot);
        }

        [HttpGet]
        [Route("ApplyLeave")]
        public Response ApplyLeave(DateTime date,string teachercode)
        {
            return service.ApplyLeave(date, teachercode);
        }
    }
}