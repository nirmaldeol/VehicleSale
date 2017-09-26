﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace carvecho.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Features (Name) values ('Feature1')");
            migrationBuilder.Sql("insert into Features (Name) values ('Feature2')");
            migrationBuilder.Sql("insert into Features (Name) values ('Feature3')");
            migrationBuilder.Sql("insert into Features (Name) values ('Feature4')");
            migrationBuilder.Sql("insert into Features (Name) values ('Feature5')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Feature1', 'Feature2', 'Feature3', 'Feature4', 'Feature5')");
        }
    }
}
