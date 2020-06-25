using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class WebContentRoleConfiguration : EntityTypeConfiguration<WebContentRole> {

        public WebContentRoleConfiguration() {

            ToTable("ftWebContentRole");
            HasKey(c => c.Id);

            HasRequired(c => c.BaseSubjectRole).WithOptional(c => c.WebContentRole).WillCascadeOnDelete(false);
            HasRequired(c => c.WebContent).WithMany(c => c.WebContentRoles).HasForeignKey(c => c.WebContentId).WillCascadeOnDelete(false);
            
            Property(c => c.Id).IsRequired().HasColumnName("idWebContentRole").HasColumnOrder(1);
            Property(c => c.WebContentId).IsRequired().HasColumnName("idWebContent").HasColumnOrder(2);
        }
    }
}
