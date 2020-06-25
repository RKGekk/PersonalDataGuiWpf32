using PersonalData.Repository.Configuration.BusinessObjects;
using PersonalData.Repository.Configuration.Dictionary;
using PersonalData.Repository.Configuration.Rule;
using PersonalData.Repository.Model.BusinessObjects;
using PersonalData.Repository.Model.Dictionary;
using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository {

    public class PersonalDataContext : DbContext {

        private const string _connectionName = "MarginSurchargeConnection";

        public PersonalDataContext(string DBName) : base(DBName) {
            Database.SetInitializer(new PersonalDataContextInitializer());
        }

        public PersonalDataContext() : base(_connectionName) {
            Database.SetInitializer(new PersonalDataContextInitializer());
        }

        public DbSet<TypeDigest> TypeDigests { get; set; }
        public DbSet<TypeCategory> TypeCategories { get; set; }
        public DbSet<TypeTable> TypeTables { get; set; }
        public DbSet<TypeDigestRelation> TypeDigestRelations { get; set; }

        public DbSet<ExpressionNode> ExpressionNodes { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<TypeReference> TypeReferences { get; set; }
        public DbSet<ConstReference> ConstReferences { get; set; }
        public DbSet<OperationNode> OperationNodes { get; set; }
        public DbSet<OperationArgumentList> OperationArgumentLists { get; set; }

        public DbSet<DocumentSubject> DocumentSubjects { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<IdentityDocument> IdentityDocuments { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhysicalCharacteristic> PhysicalCharacteristics { get; set; }
        public DbSet<RoleRelation> RoleRelations { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectName> SubjectNames { get; set; }
        public DbSet<SubjectRole> SubjectRoles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<WebContent> WebContents { get; set; }
        public DbSet<WebContentRole> WebContentRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new TypeDigestConfiguraion());
            modelBuilder.Configurations.Add(new TypeCategoryConfiguration());
            modelBuilder.Configurations.Add(new TypeTableConfiguration());
            modelBuilder.Configurations.Add(new TypeDigestRelationConfiguration());

            modelBuilder.Configurations.Add(new ExpressionNodeConfiguration());
            modelBuilder.Configurations.Add(new ReferenceConfiguration());
            modelBuilder.Configurations.Add(new TypeReferenceConfiguration());
            modelBuilder.Configurations.Add(new ConstReferenceConfiguration());
            modelBuilder.Configurations.Add(new OperationNodeConfiguration());
            modelBuilder.Configurations.Add(new OperationArgumentListConfiguration());

            modelBuilder.Configurations.Add(new DocumentSubjectConfiguration());
            modelBuilder.Configurations.Add(new GenderConfiguration());
            modelBuilder.Configurations.Add(new IdentityDocumentConfiguration());
            modelBuilder.Configurations.Add(new MaritalStatusConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new PhysicalCharacteristicConfiguration());
            modelBuilder.Configurations.Add(new RoleRelationConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new SubjectNameConfiguration());
            modelBuilder.Configurations.Add(new SubjectRoleConfiguration());
            modelBuilder.Configurations.Add(new UserLoginConfiguration());
            modelBuilder.Configurations.Add(new WebContentConfiguration());
            modelBuilder.Configurations.Add(new WebContentRoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
