using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class MaritalStatusConfiguration : EntityTypeConfiguration<MaritalStatus> {

        public MaritalStatusConfiguration() {

            ToTable("ftMaritalStatus");
            HasKey(c => c.Id);

            HasRequired(c => c.MaritalStatusType).WithMany(c => c.MaritalStatus_MaritalStatusTypes).HasForeignKey(c => c.MaritalTypeId).WillCascadeOnDelete(false);
            HasRequired(c => c.Person).WithMany(c => c.MaritalStatuses).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idMaritalStatus").HasColumnOrder(1);
            Property(c => c.MaritalTypeId).IsRequired().HasColumnName("idMaritalStatusType").HasColumnOrder(2);
            Property(c => c.PersonId).IsRequired().HasColumnName("idPerson").HasColumnOrder(3);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(4);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(5);
        }
    }
}
