using Doss.Core.Domain.Contacts;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.Residentials;
using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Domain.Vehicles;
using Doss.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Doss.Infra.Data
{
    public class DossDbContext : DbContext
    {
        public DossDbContext(DbContextOptions<DossDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Doss");
            SetDefaultDateTimeColumnType(modelBuilder);

            modelBuilder.ApplyConfiguration(new OnBoardAddressConfiguration());
            modelBuilder.ApplyConfiguration(new OnBoardResidentialConfiguration());
            modelBuilder.ApplyConfiguration(new OnBoardUserConfiguration());
            modelBuilder.ApplyConfiguration(new OnBoardServiceProviderConfiguration());
            modelBuilder.ApplyConfiguration(new OnBoardVehicleConfiguration());
            modelBuilder.ApplyConfiguration(new OnBoardServiceProviderPlanConfiguration());
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentialConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentialWithServiceProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceProviderPlanConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceProviderVehicleConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentialVehicleConfiguration());
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceProviderAlertConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentialVerificationRequestConfiguration());
            modelBuilder.ApplyConfiguration(new VerificationMessageConfiguration());
            modelBuilder.ApplyConfiguration(new UsefulContactConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        private static void SetDefaultDateTimeColumnType(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder
                                        .Model
                                        .GetEntityTypes()
                                        .SelectMany(t => t.GetProperties())
                                        .Where(p => p.GetColumnType() != "date" && (p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))))
            {
                property.SetColumnType("datetime2");
            }
        }

        public DbSet<OnBoardResidential> OnBoardResidential
            => Set<OnBoardResidential>();

        public DbSet<OnBoardServiceProvider> OnBoardServiceProvider
            => Set<OnBoardServiceProvider>();

        public DbSet<OnBoardVehicle> OnBoardVehicle
            => Set<OnBoardVehicle>();

        public DbSet<Residential> Residential
             => Set<Residential>();

        public DbSet<ServiceProvider> ServiceProvider
             => Set<ServiceProvider>();

        public DbSet<ServiceProviderPlan> ServiceProviderPlan
            => Set<ServiceProviderPlan>();

        public DbSet<ServiceProviderAlert> ServiceProviderAlert
            => Set<ServiceProviderAlert>();

        public DbSet<ResidentialWithServiceProvider> ResidentialWithServiceProvider
            => Set<ResidentialWithServiceProvider>();

        public DbSet<ResidentialVerificationRequest> ResidentialVerificationRequest
            => Set<ResidentialVerificationRequest>();

        public DbSet<VerificationMessage> VerificationMessage
            => Set<VerificationMessage>();            

        public DbSet<Plan> Plan
            => Set<Plan>();

        public DbSet<Vehicle> Vehicle
            => Set<Vehicle>();

        public DbSet<ServiceProviderVehicle> ServiceProviderVehicle
            => Set<ServiceProviderVehicle>();

        public DbSet<ResidentialVehicle> ResidentialVehicle
            => Set<ResidentialVehicle>();

        public DbSet<UsefulContact> UsefulContact
            => Set<UsefulContact>();
    }
}
