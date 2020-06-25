using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class RoleRelationConfiguration : EntityTypeConfiguration<RoleRelation> {

        public RoleRelationConfiguration() {

            ToTable("rlRole");
            HasKey(c => c.Id);

            HasRequired(c => c.RelationType).WithMany(c => c.RoleRelation_RelationTypes).HasForeignKey(c => c.RelationTypeId).WillCascadeOnDelete(false);
            HasRequired(c => c.FromSubjectRole).WithMany(c => c.SubjectRolesFrom).HasForeignKey(c => c.FromRoleId).WillCascadeOnDelete(false);
            HasRequired(c => c.ToSubjectRole).WithMany(c => c.SubjectRolesTo).HasForeignKey(c => c.ToRoleId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idrlRole").HasColumnOrder(1);
            Property(c => c.RelationTypeId).IsRequired().HasColumnName("idrlType").HasColumnOrder(2);
            Property(c => c.FromRoleId).IsRequired().HasColumnName("idFromRole").HasColumnOrder(3);
            Property(c => c.ToRoleId).IsRequired().HasColumnName("idToRole").HasColumnOrder(4);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(5);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(6);
        }
    }
}
