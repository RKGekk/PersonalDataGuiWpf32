using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Rule {

    public class ConstReferenceConfiguration : EntityTypeConfiguration<ConstReference> {

        public ConstReferenceConfiguration() {

            ToTable("ftConstReferences");
            HasKey(c => c.Id);

            HasRequired(c => c.Reference).WithOptional(c => c.ConstReference).WillCascadeOnDelete(false);
            HasOptional(c => c.ConstantReferenceType).WithMany(c => c.ConstReference_ConstantReferenceTypes).HasForeignKey(c => c.ConstantReferenceTypeId);

            Property(c => c.Id).IsRequired().HasColumnName("idConstReference").HasColumnOrder(1);
            Property(c => c.ConstantReferenceTypeId).IsOptional().HasColumnName("idConstantReferenceType").HasColumnOrder(2);
            Property(c => c.ValueString).IsOptional().HasColumnName("sValue").HasColumnOrder(3);
            Property(c => c.ValueInt).IsOptional().HasColumnName("iValue").HasColumnOrder(4);
            Property(c => c.ValueDouble).IsOptional().HasColumnName("fValue").HasColumnOrder(5);
            Property(c => c.ValueBoolean).IsOptional().HasColumnName("bValue").HasColumnOrder(6);
        }
    }
}
