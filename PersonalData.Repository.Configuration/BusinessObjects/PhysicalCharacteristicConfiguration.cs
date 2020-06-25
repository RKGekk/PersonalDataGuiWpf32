using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class PhysicalCharacteristicConfiguration : EntityTypeConfiguration<PhysicalCharacteristic> {

        public PhysicalCharacteristicConfiguration() {

            ToTable("ftPhysicalCharacteristic");
            HasKey(c => c.Id);

            HasRequired(c => c.PhysicalCharacteristicType).WithMany(c => c.PhysicalCharacteristic_PhysicalCharacteristicTypes).HasForeignKey(c => c.PhysicalValueTypeId).WillCascadeOnDelete(false);
            HasRequired(c => c.Person).WithMany(c => c.PhysicalCharacteristics).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idPhysicalCharacteristic").HasColumnOrder(1);
            Property(c => c.PhysicalValueTypeId).IsRequired().HasColumnName("idPhysicalCharacteristicType").HasColumnOrder(2);
            Property(c => c.PersonId).IsRequired().HasColumnName("idPerson").HasColumnOrder(3);
            Property(c => c.PhysicalValue).IsRequired().HasColumnName("sValue").HasColumnOrder(4);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(5);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(6);
        }
    }
}
