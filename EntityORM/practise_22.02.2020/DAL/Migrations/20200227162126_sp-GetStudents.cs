using Microsoft.EntityFrameworkCore.Migrations;

namespace University.DAL.Migrations
{
    public partial class spGetStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetSudents]
               @FirstName varchar(50)
            AS
            BEGIN
                SET NOCOUNT ON;
                select * from Students where FirstName like @FirstName + '%'
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
