using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AeroLion.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    user_name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    SingaporeIC = table.Column<string>(nullable: true),
                    passport_no = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    phone_no = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    is_admin = table.Column<bool>(nullable: false),
                    date_of_birth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_Id = table.Column<string>(nullable: true),
                    from_city = table.Column<string>(nullable: true),
                    to_city = table.Column<string>(nullable: true),
                    arrival_time = table.Column<DateTime>(nullable: false),
                    depart_time = table.Column<DateTime>(nullable: false),
                    fare = table.Column<float>(nullable: false),
                    max_seats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "flights");
        }
    }
}
