using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Dictionary {

    public class TypeDigestConfiguraion : EntityTypeConfiguration<TypeDigest> {

        public TypeDigestConfiguraion() {

            ToTable("drType");
            HasKey(c => c.Id);

            HasOptional(c => c.TypeCategoryBase).WithRequired(c => c.TypeDigest);
            HasOptional(c => c.Category).WithMany(c => c.TypeDigests).HasForeignKey(c => c.TypeCategoryId).WillCascadeOnDelete(false);
            HasOptional(c => c.ParentType).WithMany(c => c.ChildTypes).HasForeignKey(c => c.ParentId).WillCascadeOnDelete(false);
            HasMany(c => c.ChildTypes).WithOptional(c => c.ParentType).HasForeignKey(c => c.ParentId).WillCascadeOnDelete(false);
            HasOptional(c => c.TypeInCategory).WithMany(c => c.TypesInCategory).HasForeignKey(c => c.TypeCategoryId).WillCascadeOnDelete(false);
            HasMany(c => c.TypesInCategory).WithOptional(c => c.TypeInCategory).HasForeignKey(c => c.TypeCategoryId).WillCascadeOnDelete(false);
            HasOptional(c => c.TypeTable).WithMany(c => c.TypeDigests).HasForeignKey(c => c.TypeTableId).WillCascadeOnDelete(false);

            HasMany(c => c.IdentityDocument_DocumentTypes).WithRequired(c => c.DocumentType).HasForeignKey(c => c.DocumentTypeId).WillCascadeOnDelete(false);
            HasMany(c => c.Gender_GenderTypes).WithRequired(c => c.GenderType).HasForeignKey(c => c.GenderTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).HasColumnName("idType").IsRequired().HasColumnOrder(1);
            Property(c => c.ParentId).HasColumnName("idParent").IsOptional().HasColumnOrder(2);
            Property(c => c.TypeCategoryId).HasColumnName("idTypeCategory").IsOptional().HasColumnOrder(3);
            Property(c => c.Code).HasColumnName("sCode").HasMaxLength(100).IsRequired().HasColumnOrder(4);
            Property(c => c.BCode).HasColumnName("sBCode").HasMaxLength(100).IsOptional().HasColumnOrder(5);
            Property(c => c.Name).HasColumnName("sName").HasMaxLength(150).IsOptional().HasColumnOrder(6);
            Property(c => c.TypeTableId).HasColumnName("idTypeTable").IsOptional().HasColumnOrder(7);
            Property(c => c.Note).HasColumnName("sNote").IsOptional().HasColumnOrder(8); //должно быть HasMaxLength(1255), но некоторые строки не укладываются в это ограничение при инициализации
            Property(c => c.Edit).HasColumnName("dEdit").IsRequired().HasColumnOrder(9);
            Property(c => c.Open).HasColumnName("dOpen").IsRequired().HasColumnOrder(10);
            Property(c => c.Close).HasColumnName("dClose").IsRequired().HasColumnOrder(11);
            Property(c => c.Order).HasColumnName("iOrder").IsRequired().HasColumnOrder(12);

            HasIndex(p => p.Code).IsUnique();
        }
    }
}
