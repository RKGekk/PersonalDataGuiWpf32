using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class IdentityDocumentConfiguration : EntityTypeConfiguration<IdentityDocument> {

        public IdentityDocumentConfiguration() {

            ToTable("ftDocument");
            HasKey(c => c.Id);

            HasMany(c => c.DocumentSubjects).WithRequired(c => c.Document).HasForeignKey(c => c.DocumentId).WillCascadeOnDelete(false);
            HasRequired(c => c.DocumentType).WithMany(c => c.IdentityDocument_DocumentTypes).HasForeignKey(c => c.DocumentTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idDocument").HasColumnOrder(1);
            Property(c => c.Name).IsOptional().HasColumnName("sName").HasColumnOrder(2);
            Property(c => c.DocumentTypeId).IsRequired().HasColumnName("idDocumentType").HasColumnOrder(3);
            Property(c => c.DocumentNumber).IsRequired().HasColumnName("sNumber").HasColumnOrder(4);
            Property(c => c.IssueDate).IsRequired().HasColumnName("dIssueDate").HasColumnOrder(5);
            Property(c => c.ExpirationDate).IsRequired().HasColumnName("dExpirationDate").HasColumnOrder(6);
        }
    }
}
