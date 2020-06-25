using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Dictionary {

    public class TypeCategoryConfiguration : EntityTypeConfiguration<TypeCategory> {

        public TypeCategoryConfiguration() {

            ToTable("drTypeCategory");
            HasKey(c => c.Id);

            HasRequired(c => c.TypeDigest).WithOptional(c => c.TypeCategoryBase);
            HasMany(c => c.TypeDigests).WithOptional(c => c.Category);
            HasOptional(c => c.TypeTable).WithMany(c => c.TypeCategories).HasForeignKey(c => c.TypeTableId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idTypeCategory").HasColumnOrder(1);
            Property(c => c.TypeTableId).IsOptional().HasColumnName("idTypeTable").HasColumnOrder(2);
        }
    }
}
