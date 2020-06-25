using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.BusinessObjects {

    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin> {

        public UserLoginConfiguration() {

            ToTable("ftUserLogin");
            HasKey(c => c.Id);

            HasRequired(c => c.Subject).WithMany(c => c.UserLogins).HasForeignKey(c => c.SubjectId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idUserLogin").HasColumnOrder(1);
            Property(c => c.SubjectId).IsRequired().HasColumnName("idSubject").HasColumnOrder(2);
            Property(c => c.From).IsRequired().HasColumnName("dFrom").HasColumnOrder(3);
            Property(c => c.Thru).IsRequired().HasColumnName("dThru").HasColumnOrder(4);
            Property(c => c.Login).IsOptional().HasColumnName("sLogin").HasColumnOrder(5);
            Property(c => c.LoginHash).IsOptional().HasColumnName("sLoginHash").HasColumnOrder(6);
            Property(c => c.Password).IsOptional().HasColumnName("sPassword").HasColumnOrder(7);
            Property(c => c.PasswordHash).IsOptional().HasColumnName("sPasswoerdHash").HasColumnOrder(8);
        }
    }
}
