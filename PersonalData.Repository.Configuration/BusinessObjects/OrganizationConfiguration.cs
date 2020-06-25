using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class OrganizationConfiguration : EntityTypeConfiguration<Organization> {

        public OrganizationConfiguration() {

            ToTable("ftOrganization");
            HasKey(c => c.Id);

            HasRequired(c => c.BaseSubject).WithOptional(c => c.Organization).WillCascadeOnDelete(false);
            HasRequired(c => c.OrganizationType).WithMany(c => c.Organization_OrganizationTypes).HasForeignKey(c => c.OrganizationTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idOrganization").HasColumnOrder(1);
            Property(c => c.OrganizationTypeId).IsRequired().HasColumnName("idOrganizationType").HasColumnOrder(2);
        }
    }
}
