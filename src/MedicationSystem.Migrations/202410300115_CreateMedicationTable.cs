using FluentMigrator;

namespace MedicationSystem.Migrations;
[Migration(202410300115)]
public class _202410300115_CreateMedicationTable : Migration
{
    public override void Up()
    {
        Create.Table("Medications")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(30).NotNullable()
            .WithColumn("Code").AsString(30).Unique().NotNullable()
            .WithColumn("Type").AsInt16().NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Medications");
    }
}