using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COVID_vaccination_patient_system.Migrations
{
    /// <inheritdoc />
    public partial class SeedPatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Age", "Gender", "Name", "VaccinationStatus" },
                values: new object[,]
                {
                    { 1, 32, "Male", "Umair Khan", "Unvaccinated" },
                    { 2, 42, "Male", "Harry Brown", "Unvaccinated" },
                    { 3, 28, "Female", "Margaret Taylor", "Unvaccinated" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 3);
        }
    }
}
