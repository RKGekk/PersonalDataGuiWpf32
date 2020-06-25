using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class SubjectRoleConfiguration : EntityTypeConfiguration<SubjectRole> {

        public SubjectRoleConfiguration() {

            ToTable("ftSubjectRole");
            HasKey(c => c.Id);

            HasOptional(c => c.WebContentRole).WithRequired(c => c.BaseSubjectRole).WillCascadeOnDelete(false);
            HasRequired(c => c.Subject).WithMany(c => c.SubjectRoles).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);
            HasMany(c => c.SubjectRolesFrom).WithRequired(c => c.FromSubjectRole).HasForeignKey(c => c.FromRoleId).WillCascadeOnDelete(false);
            HasMany(c => c.SubjectRolesTo).WithRequired(c => c.ToSubjectRole).HasForeignKey(c => c.ToRoleId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idSubjectRole").HasColumnOrder(1);
            Property(c => c.RoleTypeId).IsRequired().HasColumnName("idRoleType").HasColumnOrder(2);
            Property(c => c.SubjectId).IsRequired().HasColumnName("idSubject").HasColumnOrder(3);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(4);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(5);
        }
    }
}
