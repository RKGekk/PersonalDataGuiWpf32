using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class WebContentConfiguration : EntityTypeConfiguration<WebContent> {

        public WebContentConfiguration() {

            ToTable("ftWebContent");
            HasKey(c => c.Id);

            HasMany(c => c.WebContentRoles).WithRequired(c => c.WebContent).HasForeignKey(c => c.WebContentId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idWebContent").HasColumnOrder(1);
            Property(c => c.WebContentTypeId).IsRequired().HasColumnName("idWebContentType").HasColumnOrder(2);
            Property(c => c.WebContentStatusId).IsRequired().HasColumnName("idWebContentStatus").HasColumnOrder(3);
            Property(c => c.WebFile).IsRequired().HasColumnName("sFile").HasColumnOrder(4);
            Property(c => c.WebRoute).IsOptional().HasColumnName("sRoute").HasColumnOrder(5);
            Property(c => c.WebController).IsOptional().HasColumnName("sController").HasColumnOrder(6);
            Property(c => c.WebAction).IsOptional().HasColumnName("sAction").HasColumnOrder(7);
        }
    }
}
