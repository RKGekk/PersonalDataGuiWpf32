using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class SubjectNameConfiguration : EntityTypeConfiguration<SubjectName> {

        public SubjectNameConfiguration() {

            ToTable("ftSubjectName");
            HasKey(c => c.Id);

            HasRequired(c => c.Subject).WithMany(c => c.SubjectNames).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);
            HasRequired(c => c.NameType).WithMany(c => c.SubjectName_SubjectNameTypes).HasForeignKey(c => c.NameTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idSubjectName").HasColumnOrder(1);
            Property(c => c.NameTypeId).IsRequired().HasColumnName("idNameType").HasColumnOrder(2);
            Property(c => c.OrderInSequence).IsRequired().HasColumnName("iSequence").HasColumnOrder(3);
            Property(c => c.SubjectId).IsRequired().HasColumnName("idSubject").HasColumnOrder(4);
            Property(c => c.Name).IsRequired().HasColumnName("sName").HasColumnOrder(5);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(6);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(7);
        }
    }
}
