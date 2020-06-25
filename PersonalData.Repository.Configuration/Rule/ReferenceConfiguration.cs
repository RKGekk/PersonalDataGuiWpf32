using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Rule {

    public class ReferenceConfiguration : EntityTypeConfiguration<Reference> {

        public ReferenceConfiguration() {

            ToTable("ftReferences");
            HasKey(c => c.Id);

            HasRequired(c => c.ExpressionNode).WithOptional(c => c.Reference).WillCascadeOnDelete(false);
            HasRequired(c => c.ReferenceType).WithMany(c => c.Reference_ReferenceTypes).HasForeignKey(c => c.ReferenceTypeId).WillCascadeOnDelete(false);
            HasOptional(c => c.TypeReference).WithRequired(c => c.Reference).WillCascadeOnDelete(false);
            HasOptional(c => c.ConstReference).WithRequired(c => c.Reference).WillCascadeOnDelete(false);

            Property(c => c.Id).HasColumnName("idReference").IsRequired().HasColumnOrder(1);
            Property(c => c.ReferenceTypeId).HasColumnName("idReferenceType").IsRequired().HasColumnOrder(2);
        }
    }
}
