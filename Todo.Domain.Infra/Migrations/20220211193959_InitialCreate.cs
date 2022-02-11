﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Domain.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Title = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    Done = table.Column<ulong>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_User",
                table: "Todos",
                column: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
