using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Dictionary {

    public class TypeTableConfiguration : EntityTypeConfiguration<TypeTable> {

        public TypeTableConfiguration() {

            ToTable("drTypeTable");
            HasKey(c => c.Id);

            HasMany(c => c.TypeCategories).WithOptional(c => c.TypeTable).HasForeignKey(c => c.TypeTableId).WillCascadeOnDelete(false);
            HasMany(c => c.TypeDigests).WithOptional(c => c.TypeTable).HasForeignKey(c => c.TypeTableId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idTypeTable").HasColumnOrder(1);
            Property(c => c.Table).IsOptional().HasMaxLength(50).HasColumnName("sTable").HasColumnOrder(2);
            Property(c => c.Name).IsOptional().HasMaxLength(100).HasColumnName("sName").HasColumnOrder(3);
            Property(c => c.Name).IsOptional().HasMaxLength(100).HasColumnName("sNote").HasColumnOrder(4);
            Property(c => c.PK).IsOptional().HasMaxLength(256).HasColumnName("sPK").HasColumnOrder(5);
            Property(c => c.TableObjectId).IsOptional().HasColumnName("idTableObject").HasColumnOrder(6);
        }
    }
}
