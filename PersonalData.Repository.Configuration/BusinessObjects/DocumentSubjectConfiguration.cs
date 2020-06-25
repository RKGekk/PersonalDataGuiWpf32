using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class DocumentSubjectConfiguration : EntityTypeConfiguration<DocumentSubject> {

        public DocumentSubjectConfiguration() {

            ToTable("rlDocumentSubject");
            HasKey(c => c.Id);

            HasRequired(c => c.RelationType).WithMany(c => c.DocumentSubject_RelationTypes).HasForeignKey(c => c.RelationTypeId).WillCascadeOnDelete(false);
            HasRequired(c => c.Document).WithMany(c => c.DocumentSubjects).HasForeignKey(c => c.DocumentId).WillCascadeOnDelete(false);
            HasRequired(c => c.Subject).WithMany(c => c.DocumentSubjects).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idrlDocumentSubject").HasColumnOrder(1);
            Property(c => c.RelationTypeId).IsRequired().HasColumnName("idrlType").HasColumnOrder(2);
            Property(c => c.DocumentId).IsRequired().HasColumnName("idDocument").HasColumnOrder(3);
            Property(c => c.SubjectId).IsRequired().HasColumnName("idSubject").HasColumnOrder(4);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(5);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(6);
        }
    }
}
