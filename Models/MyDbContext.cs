using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MyDbContext : IdentityDbContext<ContractUser> 
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contract>()
                        .HasRequired(c => c.Owner)
                        .WithMany(o => o.OwnerContracts)
                        .HasForeignKey(c => c.OwnerId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                        .HasOptional(c => c.Dispatcher)
                        .WithMany(d => d.DispatcherContracts)
                        .HasForeignKey(c => c.DispatcherId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                        .HasOptional(c => c.Coordinator)
                        .WithMany(d => d.CoordinatorContracts)
                        .HasForeignKey(c => c.CoordinatorId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                        .HasOptional(c => c.Signer)
                        .WithMany(d => d.SignerContracts)
                        .HasForeignKey(c => c.SignerId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                        .HasOptional(c => c.Department)
                        .WithMany(o => o.Contracts)
                        .HasForeignKey(c => c.DepartmentId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                        .HasOptional(c => c.SupervisorDepartment)
                        .WithMany(o => o.SupervisorContracts)
                        .HasForeignKey(c => c.SupervisorDepartmentId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                        .HasOptional(c => c.Dispatcher)
                        .WithMany(o => o.DispatcherDepartments)
                        .HasForeignKey(c => c.DispatcherId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                            .HasOptional(c => c.StvDispatcher)
                            .WithMany(o => o.StvDispatcherDepartments)
                            .HasForeignKey(c => c.StvDispatcherId)
                            .WillCascadeOnDelete(false);

        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractFile> ContractFiles { get; set; }
        public DbSet<ContractKind> ContractKinds { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<ContractSubType> ContractSubTypes { get; set; }
        public DbSet<ContractPartner> ContractPartners { get; set; }
        public DbSet<PhysicalDocAddress> PhysicalDocAddresses { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<CostKind> CostKinds { get; set; }
        public DbSet<FrameContract> FrameContracts { get; set; }
        public DbSet<VarPayment> VarPayments { get; set; }
        public DbSet<Mandant> Mandants { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MU_Relation> MU_Relations { get; set; }
        public DbSet<DU_Relation> DU_Relations { get; set; }

    }
}