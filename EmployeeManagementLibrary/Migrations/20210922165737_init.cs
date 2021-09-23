using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementLibrary.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailActive = table.Column<bool>(type: "bit", nullable: true),
                    IsSMSActive = table.Column<bool>(type: "bit", nullable: true),
                    IsPushActive = table.Column<bool>(type: "bit", nullable: true),
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Users_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMaps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMaps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoleMaps_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMaps_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerID",
                table: "Employees",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMaps_RoleID",
                table: "UserRoleMaps",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMaps_UserID",
                table: "UserRoleMaps",
                column: "UserID");


            migrationBuilder.InsertData("Roles", new string[] { "Name" }, new string[] { "App-User" });
            migrationBuilder.InsertData("Roles", new string[] { "Name" }, new string[] { "Prospective-User" });
            migrationBuilder.InsertData("Roles", new string[] { "Name" }, new string[] { "Manager" });
            migrationBuilder.InsertData("Roles", new string[] { "Name" }, new string[] { "HR-Manager" });

            migrationBuilder.InsertData("Users", new string[] { "Password", "UserName" }, new string[] { "123456", "nhs047@gmail.com" });
            migrationBuilder.InsertData("Users", new string[] { "Password", "UserName" }, new string[] { "123456", "habib48@gmail.com" });
            migrationBuilder.InsertData("Users", new string[] { "Password", "UserName" }, new string[] { "123456", "mahadi09@gmail.com" });
            migrationBuilder.InsertData("Users", new string[] { "Password", "UserName" }, new string[] { "123456", "masuk45@gmail.com" });
            migrationBuilder.InsertData("Users", new string[] { "Password", "UserName" }, new string[] { "123456", "hasan09@gmail.com" });
            migrationBuilder.InsertData("Users", new string[] { "Password", "UserName" }, new string[] { "123456", "israt.jahan.cse@gmail.com" });


            migrationBuilder.InsertData("Employees", new string[] { "UserID", "FirstName", "LastName", "PhoneNumber", "ManagerID" }, new string[] { "1", "Nobi", "Hossain", "+8801685562954", "5" });
            migrationBuilder.InsertData("Employees", new string[] { "UserID", "FirstName", "LastName", "PhoneNumber", "ManagerID" }, new string[] { "2", "Habib", "Mozumder", "+8801685562964", "5" });
            migrationBuilder.InsertData("Employees", new string[] { "UserID", "FirstName", "LastName", "PhoneNumber", "ManagerID" }, new string[] { "3", "Mahadi", "Hassan", "+8801685562974", "5" });
            migrationBuilder.InsertData("Employees", new string[] { "UserID", "FirstName", "LastName", "PhoneNumber", "ManagerID" }, new string[] { "4", "Masuk", "Chisty", "+8801685562984", "5" });
            migrationBuilder.InsertData("Employees", new string[] { "UserID", "FirstName", "LastName", "PhoneNumber", "ManagerID" }, new string[] { "5", "Hasan", "Umor", "+8801685562994", "5" });
            migrationBuilder.InsertData("Employees", new string[] { "UserID", "FirstName", "LastName", "PhoneNumber", "ManagerID" }, new string[] { "6", "Israt", "Jahan", "+8801685562104", "6" });


            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "1", "1" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "1", "2" });

            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "2", "1" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "2", "2" });

            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "3", "1" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "3", "2" });

            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "4", "1" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "4", "2" });

            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "5", "1" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "5", "2" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "5", "3" });

            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "6", "1" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "6", "2" });
            migrationBuilder.InsertData("UserRoleMaps", new string[] { "UserID", "RoleID" }, new string[] { "6", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "UserRoleMaps");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
