using System;
using System.Collections.Generic;
using System.Linq;

namespace HairdresserManager.Shared.Contract.V1.Appointment.Responses
{
    public static class ScheduleResponseFakeData
    {
        public static IEnumerable<AvailableEmployeeDatesResponse> GetData()
        {
            var response = new List<AvailableEmployeeDatesResponse>
            {
                new()
                {
                    EmployeeId = 1, EmployeeName = "Bartosh",
                    EmployeeLowQualityAvatar =
                        "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                    AvailableDates = new List<DayDatesResponse>
                    {
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        },
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.AddDays(1).ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        },
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.AddDays(2).ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        }
                    }
                },
                new()
                {
                    EmployeeId = 2, EmployeeName = "Bart",
                    EmployeeLowQualityAvatar =
                        "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                    AvailableDates = new List<DayDatesResponse>
                    {
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        },
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.AddDays(1).ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        },
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.AddDays(2).ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        }
                    }
                },
                new()
                {
                    EmployeeId = 3, EmployeeName = "Osh",
                    EmployeeLowQualityAvatar =
                        "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                    AvailableDates = new List<DayDatesResponse>
                    {
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        },
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.AddDays(1).ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        },
                        new DayDatesResponse()
                        {
                            Date = DateTime.Now.AddDays(2).ToString("dd-MM-yyyy"),
                            Dates = new List<string>
                                {"9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00"}
                        }
                    }
                }
            };

            return response;
        }
    }
}