using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class add_ReviewDetailsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW ReviewDetailsView 
AS
SELECT reviews.Id as ReviewId, reviews.[Date] as ReviewedDate, reviews.Description, appointments.[Date] as AppointmentDate, reviews.Rate, employees.Nick as EmployeeNick, employees.Id as EmployeeId, services.Name as ServiceName, users.FirstName, appointments.ClientFirstName 
FROM HairdresserManagerDB.dbo.Reviews as reviews
LEFT JOIN HairdresserManagerDB.dbo.Appointments as appointments ON reviews.AppointmentId = appointments.Id
LEFT JOIN HairdresserManagerDB.dbo.Employees as employees ON appointments.EmployeeId = employees.Id
LEFT JOIN HairdresserManagerDB.dbo.Services as services ON appointments.ServiceId = services.Id 
LEFT JOIN HairdresserManagerDB.dbo.Clients as clients ON appointments.ClientId = clients.Id 
LEFT JOIN HairdresserManagerDB.dbo.AspNetUsers as users ON clients.UserId = users.Id  
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view ReviewDetailsView");
        }
    }
}
