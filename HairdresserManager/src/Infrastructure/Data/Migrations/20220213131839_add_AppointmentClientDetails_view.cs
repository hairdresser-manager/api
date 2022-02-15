using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class add_AppointmentClientDetails_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW AppointmentClientDetailsView 
AS
SELECT Appointments.Id as AppointmentId, users.FirstName, users.Email, users.PhoneNumber, appointments.ClientEmail, appointments.ClientPhoneNumber, appointments.ClientFirstName , appointments.EmployeeId, appointments.[Date], services.MinimumTime as ServiceDuration, services.Name as ServiceName 
FROM dbo.Appointments as appointments
LEFT JOIN dbo.Clients as clients ON appointments.ClientId = clients.Id
LEFT JOIN dbo.AspNetUsers as users ON clients.UserId = users.Id
LEFT JOIN dbo.Services as services ON appointments.ServiceId = services.Id;
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view AppointmentClientDetailsView;");

        }
    }
}
