using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamDotnet.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    department_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__C223242250B26882", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    employee_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: true),
                    rank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C52E0BA8E1B4BFD3", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK__Employee__depart__3C69FB99",
                        column: x => x.department_id,
                        principalTable: "Department",
                        principalColumn: "department_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_department_id",
                table: "Employee",
                column: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
