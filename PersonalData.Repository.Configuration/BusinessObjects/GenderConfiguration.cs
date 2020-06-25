using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class GenderConfiguration : EntityTypeConfiguration<Gender> {

        public GenderConfiguration() {

            ToTable("ftGender");
            HasKey(c => c.Id);

            HasRequired(c => c.GenderType).WithMany(c => c.Gender_GenderTypes).HasForeignKey(c => c.GenderTypeId).WillCascadeOnDelete(false);
            HasRequired(c => c.Person).WithMany(c => c.Genders).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false);
            
            Property(c => c.Id).IsRequired().HasColumnName("idGender").HasColumnOrder(1);
            Property(c => c.GenderTypeId).IsRequired().HasColumnName("idGenderType").HasColumnOrder(2);
            Property(c => c.PersonId).IsRequired().HasColumnName("idPerson").HasColumnOrder(3);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(4);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(5);
        }
    }
}
