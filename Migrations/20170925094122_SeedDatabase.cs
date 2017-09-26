using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace carvecho.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             
migrationBuilder.Sql("insert into Makes (Name) values ('Honda')") ;
migrationBuilder.Sql("insert into Makes (Name) values ('Toyota')");
migrationBuilder.Sql("insert into Makes (Name) values ('Saab')");
migrationBuilder.Sql("insert into Makes (Name) values ('Chevrolet')");
migrationBuilder.Sql("insert into Makes (Name) values ('Volvo')");


migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Honda-Model1',(SELECT ID FROM Makes WHERE Name = 'Honda'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Honda-Model2',(SELECT ID FROM Makes WHERE Name = 'Honda'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Honda-Model3',(SELECT ID FROM Makes WHERE Name = 'Honda'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Honda-Model4',(SELECT ID FROM Makes WHERE Name = 'Honda'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Honda-Model5',(SELECT ID FROM Makes WHERE Name = 'Honda'))");


migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Toyota-Model1' ,(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Toyota-Model2' ,(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Toyota-Model3' ,(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Toyota-Model4' ,(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Toyota-Model5' ,(SELECT ID FROM Makes WHERE Name = 'Toyota'))");

migrationBuilder.Sql("insert into Models (Name, MakeId) values ( 'Saab-Model1',(SELECT ID FROM Makes WHERE Name = 'Saab'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ( 'Saab-Model2',(SELECT ID FROM Makes WHERE Name = 'Saab'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ( 'Saab-Model3',(SELECT ID FROM Makes WHERE Name = 'Saab'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ( 'Saab-Model4',(SELECT ID FROM Makes WHERE Name = 'Saab'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ( 'Saab-Model5',(SELECT ID FROM Makes WHERE Name = 'Saab'))");

migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Chevrolet-Model1' ,(SELECT ID FROM Makes WHERE Name = 'Chevrolet'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Chevrolet-Model2' ,(SELECT ID FROM Makes WHERE Name = 'Chevrolet'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Chevrolet-Model3' ,(SELECT ID FROM Makes WHERE Name = 'Chevrolet'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Chevrolet-Model4' ,(SELECT ID FROM Makes WHERE Name = 'Chevrolet'))");
migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Chevrolet-Model5' ,(SELECT ID FROM Makes WHERE Name = 'Chevrolet'))");

migrationBuilder.Sql("insert into Models (Name, MakeID) values ('Volvo-Model1',(SELECT ID FROM Makes WHERE Name = 'Volvo'))");
migrationBuilder.Sql("insert into Models (Name, MakeID) values ('Volvo-Model2',(SELECT ID FROM Makes WHERE Name = 'Volvo'))");
migrationBuilder.Sql("insert into Models (Name, MakeID) values ('Volvo-Model3',(SELECT ID FROM Makes WHERE Name = 'Volvo'))");
migrationBuilder.Sql("insert into Models (Name, MakeID) values ('Volvo-Model4',(SELECT ID FROM Makes WHERE Name = 'Volvo'))");
migrationBuilder.Sql("insert into Models (Name, MakeID) values ('Volvo-Model5',(SELECT ID FROM Makes WHERE Name = 'Volvo'))");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Honda', 'Toyota', 'Saab', 'Chevrolet', 'Volvo')");

        }
    }
}
