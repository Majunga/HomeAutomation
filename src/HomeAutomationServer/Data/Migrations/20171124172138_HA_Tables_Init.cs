using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HomeAutomationServer.Data.Migrations
{
    public partial class HA_Tables_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "HA_DeviceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HA_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HA_Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Inside = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HA_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HA_Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HA_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HA_Device",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceTypeId = table.Column<int>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HA_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HA_Device_HA_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "HA_DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HA_Device_HA_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "HA_Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HA_DeviceSensor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    SensorTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HA_DeviceSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HA_DeviceSensor_HA_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "HA_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HA_DeviceSensor_HA_Sensor_SensorTypeId",
                        column: x => x.SensorTypeId,
                        principalTable: "HA_Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HA_Setting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceEntityId = table.Column<int>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HA_Setting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HA_Setting_HA_Device_DeviceEntityId",
                        column: x => x.DeviceEntityId,
                        principalTable: "HA_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HA_Device_DeviceTypeId",
                table: "HA_Device",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HA_Device_LocationId",
                table: "HA_Device",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HA_DeviceSensor_DeviceId",
                table: "HA_DeviceSensor",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_HA_DeviceSensor_SensorTypeId",
                table: "HA_DeviceSensor",
                column: "SensorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HA_Setting_DeviceEntityId",
                table: "HA_Setting",
                column: "DeviceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HA_DeviceSensor");

            migrationBuilder.DropTable(
                name: "HA_Setting");

            migrationBuilder.DropTable(
                name: "HA_Sensor");

            migrationBuilder.DropTable(
                name: "HA_Device");

            migrationBuilder.DropTable(
                name: "HA_DeviceType");

            migrationBuilder.DropTable(
                name: "HA_Location");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
