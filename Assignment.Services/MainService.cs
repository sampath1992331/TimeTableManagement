using Core.Common;
using Core.Data;
using Core.Models;
using Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Services
{
    public class MainService:IMainService
    {
        private readonly ITTMUnitOfWork unitOfWork;
        private readonly IResponse APIresponse;
        private readonly ILogger<MainService> logger;

        public MainService(ITTMUnitOfWork unitOfWork, IResponse APIresponse, ILogger<MainService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.APIresponse = APIresponse;
            this.logger = logger;
        }

        public Response GetLeaveTeachersByDate(DateTime date)
        {

            logger.LogInformation("{0} : GetLeaveTeachersByDate -- date:  {1}  ", LogConfigFile.TeachersInfo, date);
            try
            {
            
                int datecode = GetDateCode(date);
                var parameters = new Dictionary<string, Tuple<string, DbType, ParameterDirection>>
                {
                    { "@applicableDate", Tuple.Create(date.ToString(), DbType.DateTime, ParameterDirection.Input) },
                    { "@result", Tuple.Create(1.ToString(), DbType.Int32, ParameterDirection.Output) },
                    { "@dateCode", Tuple.Create(datecode.ToString(), DbType.String, ParameterDirection.Input) },

                };

                var result = unitOfWork.Repository<string>().GetEntitiesBySP("[dbo].[ApplyLeaves]", parameters);

                if (Int32.Parse(result.ToString()) > 0)
                {
                    return APIresponse.GenerateResponseMessage(
                        ApiResponseEnum.Success.ToString(),
                        ApiResponseEnum.Success.GetHashCode().ToString(),
                        "Leave Succesfully apply",
                        result
                        );
                }
                else
                {
                    logger.LogError("{0} : ApplyLeave -- Exception:  {1} ", LogConfigFile.TeachersError, result);
                    return APIresponse.GenerateResponseMessage(
                        ApiResponseEnum.Error.ToString(),
                        ApiResponseEnum.Error.GetHashCode().ToString(),
                        "Leave Apply Failed",
                        null);
                }

            }
            catch (Exception ex)
            {
                logger.LogError("{0} : GetFreeTeachers -- Exception:  {1} ", LogConfigFile.TeachersError, ex.ToString());
                return APIresponse.GenerateResponseMessage(
                    ApiResponseEnum.Error.ToString(),
                    ApiResponseEnum.Error.GetHashCode().ToString(),
                    "Leave Apply Failed",
                    null);
            }
        }
        public Response AssignTeachers(TeacherModel teacherModel)
        {

            logger.LogInformation("{0} : AssignTeachers -- teacherModel:  {1}  ", LogConfigFile.TeachersInfo, teacherModel);
            try
            {

                var parameters = new Dictionary<string, Tuple<string, DbType, ParameterDirection>>
                {
                    { "@newAssignedTeacher", Tuple.Create(teacherModel.TeacherCode.ToString(), DbType.String, ParameterDirection.Input) },
                    { "@className", Tuple.Create(teacherModel.ClassName.ToString(), DbType.String, ParameterDirection.Input) },
                    { "@dateCode", Tuple.Create(teacherModel.DateCode.ToString(), DbType.String, ParameterDirection.Input) },
                    { "@TimeSlotCode", Tuple.Create(teacherModel.TimeSlotCode.ToString(), DbType.String, ParameterDirection.Input) },
                    { "@result", Tuple.Create(0.ToString(), DbType.String, ParameterDirection.Output) },

                };

                var result = unitOfWork.Repository<string>().GetEntitiesBySP("[dbo].[AssignTeachers]", parameters);

                if (Int32.Parse(result.ToString()) > 0)
                {
                    return APIresponse.GenerateResponseMessage(
                        ApiResponseEnum.Success.ToString(),
                        ApiResponseEnum.Success.GetHashCode().ToString(),
                        "Assign Succesfully apply",
                        result
                        );
                }
                else
                {
                    logger.LogError("{0} : AssignTeachers -- Exception:  {1} ", LogConfigFile.TeachersError, result);
                    return APIresponse.GenerateResponseMessage(
                        ApiResponseEnum.Error.ToString(),
                        ApiResponseEnum.Error.GetHashCode().ToString(),
                        "Assign Apply Failed",
                        null);
                }

            }
            catch (Exception ex)
            {
                logger.LogError("{0} : AssignTeachers -- Exception:  {1} ", LogConfigFile.TeachersError, ex.ToString());
                return APIresponse.GenerateResponseMessage(
                    ApiResponseEnum.Error.ToString(),
                    ApiResponseEnum.Error.GetHashCode().ToString(),
                    "Assign Apply Failed",
                    null);
            }
        }
        private int GetDateCode(DateTime date)
        {
            string day = date.DayOfWeek.ToString();
            int datecode = 0;
            switch (day)
            {
                case "Monday":
                    datecode = 1;
                    break;
                case "Tuesday":
                    datecode = 2;
                    break;
                case "Wednesday":
                    datecode = 3;
                    break;
                case "Thursday":
                    datecode = 4;
                    break;
                case "Friday":
                    datecode = 5;
                    break;

            }
            return datecode;
        }
    }
}
