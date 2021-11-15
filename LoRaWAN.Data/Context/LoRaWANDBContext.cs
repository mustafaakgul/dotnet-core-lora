using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LoRaWAN.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LoRaWAN.Data.Context
{
    public class LoRaWANDBContext : IdentityDbContext<User, Role, long>
    {
        public LoRaWANDBContext(DbContextOptions<LoRaWANDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoRaWANDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
            
            

        }
        //public LoRaWANDBContext(DbContextOptions<LoRaWANDBContext> options) : base(options) { }
        //public DbSet<Demo> Demos { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<EndNode> EndNodes { get; set; }
        public DbSet<ManagementUser> ManagementUsers { get; set; }

    }
}



/*
//using DataLayer.Mappings;
using DataLayer.Mappings;
using DataLayer.Migrations;
using DataLayer.Migrations.Assembly;
using Entities.Concrete;
//using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace DataLayer.Context
{
    // Add-Migration Ponnpa -o Migrations/Ponnpa -Verbose
    // Update-Database -Verbose

    // Update-Database 0 -Verbose
    // Remove-Migration -Verbose

    public interface IAPCContext
    {
        string Schema { get; }
    }
    public partial class PonnpaContext : DbContext, IAPCContext
    {
        public string Schema
        {
            get
            {
                return "ponnpa";
            }
        }

        public PonnpaContext() { }
        public PonnpaContext(DbContextOptions<PonnpaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies(false)
                .UseSqlServer(
                    Configuration.ConnectionString("Ponnpa"),
                    x =>
                    {
                        x.MigrationsHistoryTable(HistoryRepository.DefaultTableName.ToLowerInvariant(), Schema);
                        x.UseNetTopologySuite();
                    })
                .ReplaceService<IModelCacheKeyFactory, DbSchemaAwareModelCacheKeyFactory>()
                .ReplaceService<IMigrationsAssembly, DbSchemaAwareMigrationAssembly>();
        }

        public DbSet<APPEAL> APPEALS { get; set; }
        public DbSet<APPEALCREDIT> APPEALCREDITS { get; set; }
        public DbSet<APPEALCREDITFILE> APPEALCREDITFILES { get; set; }
        public DbSet<APPEALFILE> APPEALFILES { get; set; }
        public DbSet<CAMPAIGN> CAMPAIGNS { get; set; }
        public DbSet<FLEET> FLEETS { get; set; }
        public DbSet<FLEETUSER> FLEETUSERS { get; set; }
        public DbSet<GASSTATION> GASSTATIONS { get; set; }
        public DbSet<GASSTATIONUSER> GASSTATIONUSERS { get; set; }
        public DbSet<MANAGEMENTUSER> MANAGEMENTUSERS { get; set; }
        public DbSet<OILSTATION> OILSTATIONS { get; set; }
        public DbSet<NUMBERPLATE> NUMBERPLATES { get; set; }
        public DbSet<TRANSACTION> TRANSACTIONS { get; set; }
        public DbSet<USER> USERS { get; set; }
        public DbSet<REL_FLEETUSERNUMBERPLATE> REL_FLEETUSERNUMBERPLATES { get; set; }
        public DbSet<REL_GASSTATIONUSERGASSTATION> REL_GASSTATIONUSERGASSTATIONS { get; set; }
        public DbSet<QRTRANSACTION> QRTRANSACTIONS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           modelBuilder.HasDefaultSchema(Schema);

           modelBuilder.LowerCaseConvention();
           modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.ApplyConfiguration(new AppealFileMapping());
            modelBuilder.ApplyConfiguration(new AppealMapping());
            modelBuilder.ApplyConfiguration(new CampaignMapping());
            modelBuilder.ApplyConfiguration(new FleetMapping());
            modelBuilder.ApplyConfiguration(new FleetUserMapping());
            modelBuilder.ApplyConfiguration(new GasStationMapping());
            modelBuilder.ApplyConfiguration(new GasStationUserMapping());
            modelBuilder.ApplyConfiguration(new ManagementUserMapping());
            modelBuilder.ApplyConfiguration(new NumberPlateMapping());
            modelBuilder.ApplyConfiguration(new OilStationMapping());               
            modelBuilder.ApplyConfiguration(new Rel_FleetUserNumberPlateMapping());    
            modelBuilder.ApplyConfiguration(new Rel_GasStationUserGasStationMapping());       
            modelBuilder.ApplyConfiguration(new TransactionMapping());            
            modelBuilder.ApplyConfiguration(new UserMapping());            

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public static void LowerCaseConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetSchema(entity.GetSchema().ToLowerInvariant());
                entity.SetTableName(entity.GetTableName().ToLowerInvariant());

                foreach (IMutableProperty item in entity.GetProperties())
                {
                    item.SetPropertyAccessMode(PropertyAccessMode.Field);
                    item.SetColumnName(item.GetColumnName().ToLowerInvariant());
                    //item.SetColumnType(item.GetColumnType().ToLowerInvariant());
                }


                foreach (IMutableKey item in entity.GetKeys())
                    item.SetName(item.GetName().ToLowerInvariant());

                foreach (IMutableForeignKey item in entity.GetForeignKeys())
                {
                    item.PrincipalKey.SetName(item.PrincipalKey.GetName().ToLowerInvariant());
                    item.SetConstraintName(item.GetConstraintName().ToLowerInvariant());
                }

                foreach (IMutableIndex item in entity.GetIndexes())
                    item.SetName(item.GetName().ToLowerInvariant());

            }
        }
    }
}
*/