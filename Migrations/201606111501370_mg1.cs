namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileType = c.String(),
                        FileUrl = c.String(),
                        Contract_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.Contract_Id)
                .Index(t => t.Contract_Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntContractNum = c.String(),
                        ExtContractNum = c.Int(),
                        ContractValue = c.Double(),
                        Tax = c.Double(),
                        AnnualValue = c.Double(),
                        PaymentBegin = c.DateTime(),
                        PaymentInterval = c.Int(),
                        ContractBegin = c.DateTime(),
                        MinContractDuration = c.Int(),
                        ContractEnd = c.DateTime(),
                        Description = c.String(nullable: false, maxLength: 100),
                        AutoExtension = c.Int(),
                        Remarks = c.String(),
                        CancellationAppointment = c.DateTime(),
                        CancellationPeriod = c.Int(),
                        PrePayable = c.Boolean(),
                        VarPayable = c.Boolean(),
                        Adaptable = c.Boolean(),
                        IsFrameContract = c.Boolean(),
                        DepartmentId = c.Int(),
                        SupervisorDepartmentId = c.Int(),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                        DispatcherId = c.String(maxLength: 128),
                        CoordinatorId = c.String(maxLength: 128),
                        SignerId = c.String(maxLength: 128),
                        ContractKind_Id = c.Int(),
                        ContractPartner_Id = c.Int(),
                        ContractStatus_Id = c.Int(),
                        ContractSubType_Id = c.Int(),
                        ContractType_Id = c.Int(),
                        CostCenter_Id = c.Int(),
                        PhysicalDocAddress_Id = c.Int(),
                        CostKind_Id = c.Int(),
                        FrameContract_Id = c.Int(),
                        FrameContract_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractKinds", t => t.ContractKind_Id)
                .ForeignKey("dbo.ContractPartners", t => t.ContractPartner_Id)
                .ForeignKey("dbo.ContractStatus", t => t.ContractStatus_Id)
                .ForeignKey("dbo.ContractSubTypes", t => t.ContractSubType_Id)
                .ForeignKey("dbo.ContractTypes", t => t.ContractType_Id)
                .ForeignKey("dbo.CostCenters", t => t.CostCenter_Id)
                .ForeignKey("dbo.PhysicalDocAddresses", t => t.PhysicalDocAddress_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CoordinatorId)
                .ForeignKey("dbo.CostKinds", t => t.CostKind_Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.DispatcherId)
                .ForeignKey("dbo.FrameContracts", t => t.FrameContract_Id)
                .ForeignKey("dbo.FrameContracts", t => t.FrameContract_Id1)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .ForeignKey("dbo.AspNetUsers", t => t.SignerId)
                .ForeignKey("dbo.Departments", t => t.SupervisorDepartmentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SupervisorDepartmentId)
                .Index(t => t.OwnerId)
                .Index(t => t.DispatcherId)
                .Index(t => t.CoordinatorId)
                .Index(t => t.SignerId)
                .Index(t => t.ContractKind_Id)
                .Index(t => t.ContractPartner_Id)
                .Index(t => t.ContractStatus_Id)
                .Index(t => t.ContractSubType_Id)
                .Index(t => t.ContractType_Id)
                .Index(t => t.CostCenter_Id)
                .Index(t => t.PhysicalDocAddress_Id)
                .Index(t => t.CostKind_Id)
                .Index(t => t.FrameContract_Id)
                .Index(t => t.FrameContract_Id1);
            
            CreateTable(
                "dbo.ContractKinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractPartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IBAN = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractSubTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DispatcherId = c.String(maxLength: 128),
                        StvDispatcherId = c.String(maxLength: 128),
                        Mandant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DispatcherId)
                .ForeignKey("dbo.Mandants", t => t.Mandant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.StvDispatcherId)
                .Index(t => t.DispatcherId)
                .Index(t => t.StvDispatcherId)
                .Index(t => t.Mandant_Id);
            
            CreateTable(
                "dbo.Mandants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MandantName = c.String(),
                        BuchungsKreis = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CostCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Mandant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mandants", t => t.Mandant_Id)
                .Index(t => t.Mandant_Id);
            
            CreateTable(
                "dbo.MU_Relation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MandantID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mandants", t => t.MandantID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.MandantID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.PhysicalDocAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Raum = c.String(),
                        Address = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.DU_Relation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CostKinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FrameContracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainContract_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.MainContract_Id)
                .Index(t => t.MainContract_Id);
            
            CreateTable(
                "dbo.VarPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VarPaymentBegin = c.DateTime(nullable: false),
                        VarPaymentEnd = c.DateTime(nullable: false),
                        VarPaymentValue = c.Double(nullable: false),
                        VarPaymentDescription = c.String(),
                        Contract_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.Contract_Id)
                .Index(t => t.Contract_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.VarPayments", "Contract_Id", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "SupervisorDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Contracts", "SignerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contracts", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contracts", "FrameContract_Id1", "dbo.FrameContracts");
            DropForeignKey("dbo.FrameContracts", "MainContract_Id", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "FrameContract_Id", "dbo.FrameContracts");
            DropForeignKey("dbo.Contracts", "DispatcherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contracts", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Contracts", "CostKind_Id", "dbo.CostKinds");
            DropForeignKey("dbo.Contracts", "CoordinatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DU_Relation", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.DU_Relation", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Departments", "StvDispatcherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PhysicalDocAddresses", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Contracts", "PhysicalDocAddress_Id", "dbo.PhysicalDocAddresses");
            DropForeignKey("dbo.MU_Relation", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.MU_Relation", "MandantID", "dbo.Mandants");
            DropForeignKey("dbo.Departments", "Mandant_Id", "dbo.Mandants");
            DropForeignKey("dbo.CostCenters", "Mandant_Id", "dbo.Mandants");
            DropForeignKey("dbo.Contracts", "CostCenter_Id", "dbo.CostCenters");
            DropForeignKey("dbo.Departments", "DispatcherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contracts", "ContractType_Id", "dbo.ContractTypes");
            DropForeignKey("dbo.Contracts", "ContractSubType_Id", "dbo.ContractSubTypes");
            DropForeignKey("dbo.Contracts", "ContractStatus_Id", "dbo.ContractStatus");
            DropForeignKey("dbo.Contracts", "ContractPartner_Id", "dbo.ContractPartners");
            DropForeignKey("dbo.Contracts", "ContractKind_Id", "dbo.ContractKinds");
            DropForeignKey("dbo.ContractFiles", "Contract_Id", "dbo.Contracts");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VarPayments", new[] { "Contract_Id" });
            DropIndex("dbo.FrameContracts", new[] { "MainContract_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.DU_Relation", new[] { "DepartmentID" });
            DropIndex("dbo.DU_Relation", new[] { "UserID" });
            DropIndex("dbo.PhysicalDocAddresses", new[] { "Department_Id" });
            DropIndex("dbo.MU_Relation", new[] { "UserID" });
            DropIndex("dbo.MU_Relation", new[] { "MandantID" });
            DropIndex("dbo.CostCenters", new[] { "Mandant_Id" });
            DropIndex("dbo.Departments", new[] { "Mandant_Id" });
            DropIndex("dbo.Departments", new[] { "StvDispatcherId" });
            DropIndex("dbo.Departments", new[] { "DispatcherId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Contracts", new[] { "FrameContract_Id1" });
            DropIndex("dbo.Contracts", new[] { "FrameContract_Id" });
            DropIndex("dbo.Contracts", new[] { "CostKind_Id" });
            DropIndex("dbo.Contracts", new[] { "PhysicalDocAddress_Id" });
            DropIndex("dbo.Contracts", new[] { "CostCenter_Id" });
            DropIndex("dbo.Contracts", new[] { "ContractType_Id" });
            DropIndex("dbo.Contracts", new[] { "ContractSubType_Id" });
            DropIndex("dbo.Contracts", new[] { "ContractStatus_Id" });
            DropIndex("dbo.Contracts", new[] { "ContractPartner_Id" });
            DropIndex("dbo.Contracts", new[] { "ContractKind_Id" });
            DropIndex("dbo.Contracts", new[] { "SignerId" });
            DropIndex("dbo.Contracts", new[] { "CoordinatorId" });
            DropIndex("dbo.Contracts", new[] { "DispatcherId" });
            DropIndex("dbo.Contracts", new[] { "OwnerId" });
            DropIndex("dbo.Contracts", new[] { "SupervisorDepartmentId" });
            DropIndex("dbo.Contracts", new[] { "DepartmentId" });
            DropIndex("dbo.ContractFiles", new[] { "Contract_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.VarPayments");
            DropTable("dbo.FrameContracts");
            DropTable("dbo.CostKinds");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.DU_Relation");
            DropTable("dbo.PhysicalDocAddresses");
            DropTable("dbo.MU_Relation");
            DropTable("dbo.CostCenters");
            DropTable("dbo.Mandants");
            DropTable("dbo.Departments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ContractTypes");
            DropTable("dbo.ContractSubTypes");
            DropTable("dbo.ContractStatus");
            DropTable("dbo.ContractPartners");
            DropTable("dbo.ContractKinds");
            DropTable("dbo.Contracts");
            DropTable("dbo.ContractFiles");
        }
    }
}
