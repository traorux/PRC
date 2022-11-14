using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRC.DATA.Migrations
{
    public partial class initiale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Extensions",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    loginName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extensions", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "DataCustoms",
                columns: table => new
                {
                    IdDataCustom = table.Column<int>(type: "int", nullable: false),
                    NumeroCompte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeVoiture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateVisiteTec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCustoms", x => x.IdDataCustom);
                    table.ForeignKey(
                        name: "FK_DataCustoms_Customers_IdDataCustom",
                        column: x => x.IdDataCustom,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    CallRef = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExtensionNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    CustomerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dateHeure = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    typeCall = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    removeParticipant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.CallRef);
                    table.ForeignKey(
                        name: "FK_Calls_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calls_Extensions_ExtensionNumber",
                        column: x => x.ExtensionNumber,
                        principalTable: "Extensions",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IdUser = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Roles", x => new { x.IdRole, x.IdUser });
                    table.ForeignKey(
                        name: "FK_Users_Roles_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    IdRequest = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.IdRequest);
                    table.ForeignKey(
                        name: "FK_Requests_Calls_IdRequest",
                        column: x => x.IdRequest,
                        principalTable: "Calls",
                        principalColumn: "CallRef",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    IdState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallRef = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dateHeure = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.IdState);
                    table.ForeignKey(
                        name: "FK_States_Calls_CallRef",
                        column: x => x.CallRef,
                        principalTable: "Calls",
                        principalColumn: "CallRef",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "IdCustomer", "CustomerNumber", "FirstName", "LastName" },
                values: new object[] { 1, "890", "JeanLuc", "Kouame" });

            migrationBuilder.InsertData(
                table: "Extensions",
                columns: new[] { "Number", "Password", "loginName" },
                values: new object[] { "891", "0000", "oxe891" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "DeviceNumber", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserEmail", "Username" },
                values: new object[] { 1, "891", "Marc", "Kouadio", null, null, "jean@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "CallRef", "CustomerNumber", "ExtensionNumber", "IdCustomer", "dateHeure", "removeParticipant", "typeCall" },
                values: new object[] { "a2daba6270000400", "890", "891", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "890", "IncommingCall" });

            migrationBuilder.InsertData(
                table: "DataCustoms",
                columns: new[] { "IdDataCustom", "DateVisiteTec", "NumeroCompte", "TypeVoiture" },
                values: new object[] { 1, "12/06/2022", "oxe890", "Navara" });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "IdRequest", "Motif", "status" },
                values: new object[] { "a2daba6270000400", "Demande de cotation", "En cours de traitement" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "IdState", "CallRef", "Status", "dateHeure" },
                values: new object[] { 1, "a2daba6270000400", "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ExtensionNumber",
                table: "Calls",
                column: "ExtensionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_IdCustomer",
                table: "Calls",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_States_CallRef",
                table: "States",
                column: "CallRef");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roles_IdUser",
                table: "Users_Roles",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataCustoms");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users_Roles");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Extensions");
        }
    }
}
