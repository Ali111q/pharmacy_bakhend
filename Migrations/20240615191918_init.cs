using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaragesStructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NotifyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    NotifyFor = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    NotificationDestination = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Barcode = table.Column<long>(type: "bigint", nullable: false),
                    Dose = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoginLoggers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Ip = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginLoggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginLoggers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PharmacyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Pharmacys_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PharmacyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DeptId = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sells_Depts_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Depts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sells_Pharmacys_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPharmacys",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PharmacyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPharmacys", x => new { x.UserId, x.PharmacyId });
                    table.ForeignKey(
                        name: "FK_UserPharmacys_Pharmacys_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPharmacys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugPharmacys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CurrentQuantity = table.Column<int>(type: "integer", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DrugId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugPharmacys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugPharmacys_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugPharmacys_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellDrugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DrugPharmacyId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellDrugs_DrugPharmacys_DrugPharmacyId",
                        column: x => x.DrugPharmacyId,
                        principalTable: "DrugPharmacys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellDrugs_Sells_SellId",
                        column: x => x.SellId,
                        principalTable: "Sells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "Country", "CreationDate", "Deleted", "Name" },
                values: new object[] { new Guid("38b384fb-f194-4a60-b9ac-4f9cd350145c"), 0, new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(2796), false, "any" });

            migrationBuilder.InsertData(
                table: "Depts",
                columns: new[] { "Id", "CreationDate", "Deleted", "Name", "Value" },
                values: new object[] { new Guid("1a3757c5-07d9-4d03-9ac2-9f8732409343"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(3072), false, "ali", 1000m });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "CreationDate", "Deleted", "FullName", "Subject" },
                values: new object[] { new Guid("6a345eeb-5a7f-4f5e-ac19-da9690657005"), "Super Admin", new DateTime(2024, 6, 15, 19, 19, 17, 666, DateTimeKind.Utc).AddTicks(9438), false, "super admin", "super admin" });

            migrationBuilder.InsertData(
                table: "Pharmacys",
                columns: new[] { "Id", "CreationDate", "Deleted", "Name" },
                values: new object[] { new Guid("ba6169f2-2e5c-4612-8252-ebf65f134e4d"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(2701), false, "any" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationDate", "Deleted", "Name" },
                values: new object[] { new Guid("9a7614f0-89c6-43fd-9ea0-0ce931943c5c"), new DateTime(2024, 6, 15, 19, 19, 17, 666, DateTimeKind.Utc).AddTicks(9253), false, "Super Admin" });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "Barcode", "CompanyId", "CreationDate", "Deleted", "Description", "Dose", "Name" },
                values: new object[] { new Guid("a9ea65ad-2990-4276-ac5f-51dcfab0bc61"), 0L, new Guid("38b384fb-f194-4a60-b9ac-4f9cd350145c"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(2897), false, "desc", 1000, "any" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreationDate", "Deleted", "Id" },
                values: new object[] { new Guid("6a345eeb-5a7f-4f5e-ac19-da9690657005"), new Guid("9a7614f0-89c6-43fd-9ea0-0ce931943c5c"), new DateTime(2024, 6, 15, 19, 19, 17, 666, DateTimeKind.Utc).AddTicks(9462), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Deleted", "Email", "FullName", "IsActive", "Password", "RoleId" },
                values: new object[] { new Guid("22172dd7-6853-4427-8a9b-ee7fb466cf4e"), new DateTime(2024, 6, 15, 19, 19, 17, 666, DateTimeKind.Utc).AddTicks(9484), false, "bbbeat114@gmail.com", "super admin", true, "$2a$10$4NMX32vJQ4786ra5WlSvJ.uOQk2mZqiSdWgIKFoyrAMjekOPQ4z7a", new Guid("9a7614f0-89c6-43fd-9ea0-0ce931943c5c") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreationDate", "Deleted", "PharmacyId", "UserId" },
                values: new object[] { new Guid("310c3b36-18b3-4fd5-b63b-9c1f7cef210d"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(2953), false, new Guid("ba6169f2-2e5c-4612-8252-ebf65f134e4d"), new Guid("22172dd7-6853-4427-8a9b-ee7fb466cf4e") });

            migrationBuilder.InsertData(
                table: "Sells",
                columns: new[] { "Id", "CreationDate", "Deleted", "DeptId", "Discount", "PharmacyId", "UserId" },
                values: new object[] { new Guid("63954786-edde-4d70-8f75-a4bb1b6bd833"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(3186), false, new Guid("1a3757c5-07d9-4d03-9ac2-9f8732409343"), 1000m, new Guid("ba6169f2-2e5c-4612-8252-ebf65f134e4d"), new Guid("22172dd7-6853-4427-8a9b-ee7fb466cf4e") });

            migrationBuilder.InsertData(
                table: "UserPharmacys",
                columns: new[] { "PharmacyId", "UserId", "CreationDate", "Deleted", "Id", "Role" },
                values: new object[] { new Guid("ba6169f2-2e5c-4612-8252-ebf65f134e4d"), new Guid("22172dd7-6853-4427-8a9b-ee7fb466cf4e"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(2760), false, new Guid("2c75106a-a0e5-47bb-b5a1-41490648cbd0"), 0 });

            migrationBuilder.InsertData(
                table: "DrugPharmacys",
                columns: new[] { "Id", "CreationDate", "CurrentQuantity", "Deleted", "DrugId", "ExpiryDate", "OrderId", "Quantity", "UnitPrice" },
                values: new object[] { new Guid("bb4d3aa2-4613-40c3-a8c9-41a44d7a12c6"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(2983), 0, false, new Guid("a9ea65ad-2990-4276-ac5f-51dcfab0bc61"), new DateOnly(2024, 12, 12), new Guid("310c3b36-18b3-4fd5-b63b-9c1f7cef210d"), 100, 1000m });

            migrationBuilder.InsertData(
                table: "SellDrugs",
                columns: new[] { "Id", "CreationDate", "Deleted", "DrugPharmacyId", "Quantity", "SellId" },
                values: new object[] { new Guid("99a921ae-8299-4750-92da-eed0dc3c4ff7"), new DateTime(2024, 6, 15, 19, 19, 17, 821, DateTimeKind.Utc).AddTicks(3220), false, new Guid("bb4d3aa2-4613-40c3-a8c9-41a44d7a12c6"), 100, new Guid("63954786-edde-4d70-8f75-a4bb1b6bd833") });

            migrationBuilder.CreateIndex(
                name: "IX_DrugPharmacys_DrugId",
                table: "DrugPharmacys",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugPharmacys_OrderId",
                table: "DrugPharmacys",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_CompanyId",
                table: "Drugs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginLoggers_UserId",
                table: "LoginLoggers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PharmacyId",
                table: "Orders",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDrugs_DrugPharmacyId",
                table: "SellDrugs",
                column: "DrugPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDrugs_SellId",
                table: "SellDrugs",
                column: "SellId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_DeptId",
                table: "Sells",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_PharmacyId",
                table: "Sells",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_UserId",
                table: "Sells",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPharmacys_PharmacyId",
                table: "UserPharmacys",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginLoggers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SellDrugs");

            migrationBuilder.DropTable(
                name: "UserPharmacys");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "DrugPharmacys");

            migrationBuilder.DropTable(
                name: "Sells");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Depts");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Pharmacys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
