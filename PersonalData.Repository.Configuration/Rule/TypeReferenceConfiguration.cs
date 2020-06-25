using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Rule {

    public class TypeReferenceConfiguration : EntityTypeConfiguration<TypeReference> {

        public TypeReferenceConfiguration() {

            ToTable("ftTypeReferences");
            HasKey(c => c.Id);

            HasRequired(c => c.Reference).WithOptional(c => c.TypeReference).WillCascadeOnDelete(false);
            HasRequired(c => c.TypeReferenceType).WithMany(c => c.TypeReference_TypeReferences).HasForeignKey(c => c.TypeReferenceTypeId);

            Property(c => c.Id).HasColumnName("idTypeReference").IsRequired().HasColumnOrder(1);
            Property(c => c.TypeReferenceTypeId).HasColumnName("idTypeReferenceType").IsRequired().HasColumnOrder(2);
        }
    }
}
