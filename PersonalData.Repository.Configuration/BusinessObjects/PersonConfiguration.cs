using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class PersonConfiguration : EntityTypeConfiguration<Person> {

        public PersonConfiguration() {

            ToTable("ftPerson");
            HasKey(c => c.Id);

            HasRequired(c => c.BaseSubject).WithOptional(c => c.Person).WillCascadeOnDelete(false);
            HasMany(c => c.MaritalStatuses).WithRequired(c => c.Person).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false);
            HasMany(c => c.Genders).WithRequired(c => c.Person).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false);
            HasMany(c => c.PhysicalCharacteristics).WithRequired(c => c.Person).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idPerson").HasColumnOrder(1);
            Property(c => c.BirthDate).IsOptional().HasColumnName("dBirthDate").HasColumnOrder(2);
            Property(c => c.Comment).IsOptional().HasColumnName("sComment").HasColumnOrder(3);
        }
    }
}
