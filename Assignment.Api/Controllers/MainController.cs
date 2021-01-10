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
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainService mainService;

        public MainController(IMainService mainService)
        {
            this.mainService = mainService;
        }

        [HttpPost]
        [Route("AssignTeachers")]
        public Response AssignTeachers(TeacherModel teacherModel)
        {
            return mainService.AssignTeachers(teacherModel);
        }
    }
}