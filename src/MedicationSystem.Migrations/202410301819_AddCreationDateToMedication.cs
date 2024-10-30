using FluentMigrator;

namespace MedicationSystem.Migrations;

[Migration(202410301819)]
public class _202410301819_AddCreationDateToMedication : Migration
{
    public override void Up()
    {
        Alter.Table("Medications")
            .AddColumn("CreationDate").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        Delete.Column("CreationDate").FromTable("Medications");
    }
}