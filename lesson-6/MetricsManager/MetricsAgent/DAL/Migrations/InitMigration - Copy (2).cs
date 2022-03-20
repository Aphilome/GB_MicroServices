﻿using FluentMigrator;

namespace MetricsAgent.DAL.Migrations
{
    [Migration(2)]
    public class InitMigration : Migration
    {
        public override void Up()
        {
            Create.Table("cpumetrics")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Value").AsInt32()
               .WithColumn("DateTime").AsDateTime();
            
            Create.Table("dotnetmetrics")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Value").AsInt32()
               .WithColumn("DateTime").AsDateTime();
            
            Create.Table("hddmetrics")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Value").AsInt32()
               .WithColumn("DateTime").AsDateTime();
            
            Create.Table("networkmetrics")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Value").AsInt32()
               .WithColumn("DateTime").AsDateTime();
            
            Create.Table("rammetrics")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Value").AsInt32()
               .WithColumn("DateTime").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("cpumetrics");
            Delete.Table("dotnetmetrics");
            Delete.Table("hddmetrics");
            Delete.Table("networkmetrics");
            Delete.Table("rammetrics");
        }
    }
}