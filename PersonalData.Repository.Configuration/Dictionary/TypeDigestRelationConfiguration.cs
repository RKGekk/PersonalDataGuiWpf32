using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Dictionary {

    public class TypeDigestRelationConfiguration : EntityTypeConfiguration<TypeDigestRelation> {

        public TypeDigestRelationConfiguration() {

            ToTable("rlType");
            HasKey(c => c.Id);

            HasRequired(c => c.BaseTypeDigest).WithOptional(c => c.TypeRelationBase);

            HasRequired(c => c.TypeDigest1).WithMany(c => c.TypeDigestRelation_TypeDigest1).HasForeignKey(c => c.Type1Id).WillCascadeOnDelete(false);
            HasRequired(c => c.TypeDigest2).WithMany(c => c.TypeDigestRelation_TypeDigest2).HasForeignKey(c => c.Type2Id).WillCascadeOnDelete(false);

            HasMany(c => c.DocumentSubject_RelationTypes).WithRequired(c => c.RelationType).HasForeignKey(c => c.RelationTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idrlType");
            Property(c => c.Type1Id).HasColumnName("idType1");
            Property(c => c.Type2Id).HasColumnName("idType2");
        }
    }
}
