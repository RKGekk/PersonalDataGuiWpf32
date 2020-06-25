using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Rule {

    public class OperationArgumentListConfiguration : EntityTypeConfiguration<OperationArgumentList> {

        public OperationArgumentListConfiguration() {

            ToTable("rlOperationArgumentList");
            HasKey(c => c.Id);

            HasRequired(c => c.ExpressionArgument).WithMany(c => c.OperationArgumentList).HasForeignKey(c => c.ExpressionArgumentId).WillCascadeOnDelete(false);
            HasRequired(c => c.ExpressionOperation).WithMany(c => c.OperationArgumentList).HasForeignKey(c => c.ExpressionOperationId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idrlOperationArgumentList").HasColumnOrder(1);
            Property(c => c.ArgumentSequence).IsRequired().HasColumnName("iArgumentSequence").HasColumnOrder(2);
            Property(c => c.ArgumentName).IsRequired().HasColumnName("sArgumentName").HasColumnOrder(3);
            Property(c => c.ExpressionArgumentId).IsRequired().HasColumnName("idExpressionArgument").HasColumnOrder(4);
            Property(c => c.ExpressionOperationId).IsRequired().HasColumnName("idExpressionOperation").HasColumnOrder(5);
        }
    }
}
