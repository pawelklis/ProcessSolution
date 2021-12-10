
using ProcessSolution;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

[DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
public class dbContext : DbContext
{        
        // add under dbcontext public class dbcontext this: [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
         // PM> enable-migrations -EnableAutomaticMigrations
         // PM> add-migration InitDB
         // PM> update-database
         // change in class:
         // PM> Add-migration classname for save changes for one class or add-migration for example: dbChanges1 for all changes
         // For rollback changes :
         // PM> update-database -TargetMigration:for example:202111250744418_InitDB

    public List<System.Data.Entity.DbSet> Entities = new List<System.Data.Entity.DbSet>();

    public dbContext()
            : base("name=mysql_dev")
    {
        Entities.Add(ResearchModels);
        Entities.Add(ResearchModelItems);
        Entities.Add(ResearchEntries);
        Entities.Add(Researches);
        Entities.Add(ResearchItems);
        Entities.Add(Addresses);
        Entities.Add(Contacts);
        Entities.Add(Employees);
        Entities.Add(Locations);
        Entities.Add(Persons);
        Entities.Add(Users);
        Entities.Add(ResearchItemNesteds);
    }

    public DbSet<ResearchModel> ResearchModels { get; set; }
    public DbSet<ResearchModelItem> ResearchModelItems { get; set; }
    public DbSet<ResearchEntry> ResearchEntries { get; set; }
    public DbSet<Research> Researches { get; set; }
    public DbSet<ResearchItem> ResearchItems { get; set; }
    public DbSet<AddressType> Addresses { get; set; }
    public DbSet<ContactType> Contacts { get; set; }
    public DbSet<EmployeeType> Employees { get; set; }
    public DbSet<LocationType> Locations { get; set; }
    public DbSet<PersonType> Persons { get; set; }
    public DbSet<UserType> Users { get; set; }
    public DbSet<ResearchItemNested> ResearchItemNesteds { get; set; }
}


