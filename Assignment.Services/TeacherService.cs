using Core.Common;
using Core.Data;
using Core.Models;
using Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace Services
{
    public class TeacherService:ITeacherService
    {
        private readonly ITTMUnitOfWork unitOfWork;
        private readonly IResponse APIresponse;
        private readonly ILogger<TeacherService> logger;


        public TeacherService(ITTMUnitOfWork unitOfWork, IResponse APIresponse, ILogger<TeacherService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.APIresponse = APIresponse;
            this.logger = logger;
        }
    

        public Response GetTeacherTimeTable(string teacherCode)
        {
            logger.LogInformation("{0} : GetTeacherTimeTable -- teacherCode:  {1} ", LogConfigFile.TeachersInfo,teacherCode);
            try 
            { 
                var parameters = new Dictionary<string, Tuple<string, DbType, ParameterDirection>>
                {
                    { "TeacherCode", Tuple.Create(teacherCode, DbType.String, ParameterDirection.Input) },   
                };

                var timetable = unitOfWork.Repository<TeacherModel>().GetEntitiesBySP("GetTeacherTimeTable", parameters);
                return APIresponse.GenerateResponseMessage(
                    ApiResponseEnum.Success.ToString(), 
                    ApiResponseEnum.Success.GetHashCode().ToString(),
                    "Teachers Time Table",
                    timetable
                    );
            }
            catch(Exception ex)
            {
                logger.LogError("{0} : GetTeacherTimeTable -- Exception:  {1} ", LogConfigFile.TeachersError, ex.ToString());
                return APIresponse.GenerateResponseMessage(
                    ApiResponseEnum.Error.ToString(),
                    ApiResponseEnum.Error.GetHashCode().ToString(),
                    "Teachers Time Table",
                    null);
            }
        }

        public Response GetFreeTeachers(string dateCode, string timeSlot)
        {
            logger.LogInformation("{0} : GetTeacherTimeTable -- dateCode:  {1} -- timeSlot: {2} ", LogConfigFile.TeachersInfo, dateCode, timeSlot);
            try 
            { 
                var parameters = new Dictionary<string, Tuple<string, DbType, ParameterDirection>>
                {
                    { "dateCode", Tuple.Create(dateCode, DbType.String, ParameterDirection.Input) },
                    { "timeSlot", Tuple.Create(timeSlot, DbType.String, ParameterDirection.Input) },

                };

                List<TeacherModel> timetable = unitOfWork.Repository<List<TeacherModel>>().GetEntityBySP("GetFreeTeachers", parameters);

                if (timetable == null)
                {
                    string msg = "There are no teachers for Day " + dateCode + "-" + timeSlot + "  Period";
                    var parametersV1 = new Dictionary<string, Tuple<string, DbType, ParameterDirection>>
                    {
                        { "@notification", Tuple.Create(msg, DbType.String, ParameterDirection.Input) },
                        { "@result", Tuple.Create(0.ToString(), DbType.Int32, ParameterDirection.Output) },

                    };

                    var result = unitOfWork.Repository<string>().GetEntitiesBySP("[dbo].[SendNotifications]", parametersV1);

                        return APIresponse.GenerateResponseMessage(
                           ApiResponseEnum.Error.ToString(),
                           ApiResponseEnum.Error.GetHashCode().ToString(),
                           "There a no teachers to assign.notification send to the principle",
                           timetable
                           ); 
                }
                else
                {
                    logger.LogInformation("{0} : GetFreeTeachers -- timetable:  {1} ", LogConfigFile.TeachersInfo, timetable);
                    return APIresponse.GenerateResponseMessage(
                        ApiResponseEnum.Success.ToString(),
                        ApiResponseEnum.Success.GetHashCode().ToString(),
                        "Free Teachers",
                        timetable);
                }
                
            }
            catch (Exception ex)
            {
                    logger.LogError("{0} : GetFreeTeachers -- Exception:  {1} ", LogConfigFile.TeachersError, ex.ToString());
                    return APIresponse.GenerateResponseMessage(
                        ApiResponseEnum.Error.ToString(),
                        ApiResponseEnum.Error.GetHashCode().ToString(),
                        "Free Teachers",
                        null);
            }
        }

        public Response GetLeaveTeachers(string dateCode, string timeSlot)
        {
            logger.LogInformation("{0} : GetLeaveTeachers -- dateCode:  {1} -- timeSlot: {2} ", LogConfigFile.TeachersInfo, dateCode, timeSlot);
            try
            {
                var parameters = new Dictionary<string, Tuple<string, DbType, ParameterDirection>>
                {
                    { "dateCode", Tuple.Create(dateCode, DbType.String, ParameterDirection.Input) },
                    { "timeSlot", Tuple.Create(timeSlot, DbType.String, ParameterDirection.Input) },

                };

                var timetable = unitOfWork.Repository<TeacherModel>().GetEntitiesBySP("GetLeaveTeachers", parameters);

                if (timetable != null)
                {
                    return APIresponse.GenerateResponseMessage(
                         ApiResponseEnum.Success.ToString(),
                         ApiResponseEnum.Success.GetHashCode().ToString(),
                         "Leave Teachers",
                         timetable
                         );

                }
                else
                {
                        return APIresponse.GenerateResponseMessage(
                           ApiResponseEnum.Success.ToString(),
                           ApiResponseEnum.Success.GetHashCode().ToString(),
                           "Leave Teachers",
                           timetable
                           );
                    
                }

            }
            catch (Exception ex)
            {
                logger.LogError("{0} : GetLeaveTeachers -- Exception:  {1} ", LogConfigFile.TeachersError, ex.ToString());
                return APIresponse.GenerateResponseMessage(
                    ApiResponseEnum.Error.ToString(),
                    ApiResponseEnum.Error.GetHashCode().ToString(),
                    "Leave Teachers",
                    null);
            }
        }

        public Response ApplyLeave(DateTime date, string teachercode)
        {
            
            logger.LogInformation("{0} : ApplyLeave -- teacherModel:  {1}  ", LogConfigFile.TeachersInfo, date);
            try
            {
                int datecode = GetDateCode(date);
                var parameters = new Dictionary<string, Tuple<string, DbType, ParameterDirection>>
                {
                    { "@teacherCode", Tuple.Create(teachercode.ToString(), DbType.String, ParameterDirection.Input) },
                    { "@applicableDate", Tuple.Create(date.ToString(), DbType.DateTime, ParameterDirection.Input) },
                    { "@result", Tuple.Create(1.ToString(), DbType.Int32, ParameterDirection.Output) },
                    { "@dateCode", Tuple.Create(datecode.ToString(), DbType.String, ParameterDirection.Input) },


                };

                var result = unitOfWork.Repository<string>().GetEntitiesBySP("[dbo].[ApplyLeaves]", parameters);

                return APIresponse.GenerateResponseMessage(
                        ApiResponseEnum.Success.ToString(),
                        ApiResponseEnum.Success.GetHashCode().ToString(),
                        "Leave Succesfully apply",
                        result
                        );

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
                default:
                    datecode = 100;
                    break;

            }
            return datecode;
        }
    }
}
