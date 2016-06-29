using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.LinkTables;

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
                        .HasRequired(c => c.Signer)
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
                            .HasOptional(c => c.ViceDispatcher)
                            .WithMany(o => o.ViceDispatcherDepartments)
                            .HasForeignKey(c => c.ViceDispatcherId)
                            .WillCascadeOnDelete(false);

            //David: Framecontract
            modelBuilder.Entity<Contract>()
                            .HasOptional(f => f.FrameContract)
                            .WithMany(s => s.SubContracts)
                            .HasForeignKey(f => f.FrameContractId);

            //Do not delete!!
            ////Ober: CostCenter_Contract_Relation
            //modelBuilder.Entity<Contract>()
            //                .HasMany(c => c.CostCenters).WithMany(i => i.Contracts)
            //                .Map(t => t.MapLeftKey("ContractId")
            //                .MapRightKey("CostCenterId")
            //                .ToTable("ContractCostCenter_Relation"));

        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractFile> ContractFiles { get; set; }
        public DbSet<ContractTask> ContractTasks{ get; set; }
        public DbSet<ContractKind> ContractKinds { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<ContractSubType> ContractSubTypes { get; set; }
        public DbSet<ContractPartner> ContractPartners { get; set; }
        public DbSet<PhysicalDocAddress> PhysicalDocAddresses { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<CostKind> CostKinds { get; set; }
        public DbSet<VarPayment> VarPayments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CoordinatorClient_Relation> CoordinatorClient_Relations { get; set; }
        public DbSet<DepartmentUser_Relation> DepartmentUser_Relations { get; set; }
        public DbSet<ReadAccessUser> ReadAccessUsers { get; set; }
        public DbSet<ReadAccessDepartments> ReadAccessDepartments { get; set; }
        public DbSet<CoordinatorDepartment_Relation> CoordinatorDepartment_Relations { get; set; }
        public DbSet<ContractCostCenter_Relation> ContractCostCenter_Relations { get; set; }

    }
}