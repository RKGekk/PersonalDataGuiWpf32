using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class SubjectConfiguration : EntityTypeConfiguration<Subject> {

        public SubjectConfiguration() {

            ToTable("ftSubject");
            HasKey(c => c.Id);

            HasOptional(c => c.Organization).WithRequired(c => c.BaseSubject).WillCascadeOnDelete(false);
            HasOptional(c => c.Person).WithRequired(c => c.BaseSubject).WillCascadeOnDelete(false);

            HasMany(c => c.DocumentSubjects).WithRequired(c => c.Subject).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);
            HasMany(c => c.UserLogins).WithRequired(c => c.Subject).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);
            HasMany(c => c.SubjectRoles).WithRequired(c => c.Subject).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);
            HasMany(c => c.SubjectNames).WithRequired(c => c.Subject).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);

            HasRequired(c => c.SubjectType).WithMany(c => c.Subject_SubjectTypes).HasForeignKey(c => c.SubjectTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idSubject").HasColumnOrder(1);
            Property(c => c.SubjectTypeId).IsRequired().HasColumnName("idSubjectType").HasColumnOrder(2);
        }
    }
}
