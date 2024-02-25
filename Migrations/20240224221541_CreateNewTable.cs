using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckDrivingDetails.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterTable(
            //  name: "TestTable",
            //  columns: table => new
            //  {
            //      Id = table.Column<int>(type: "int", nullable: false)
            //          .Annotation("SqlServer:Identity", "1, 1"),
            //      DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 
            //  },
            //  constraints: table =>
            //  {
            //      table.PrimaryKey("PK_Test", x => x.Id);
            //  });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
