using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Rule {

    public class ExpressionNodeConfiguration : EntityTypeConfiguration<ExpressionNode> {

        public ExpressionNodeConfiguration() {

            ToTable("ftExpressionNodes");
            HasKey(c => c.Id);

            HasOptional(c => c.Reference).WithRequired(c => c.ExpressionNode).WillCascadeOnDelete(false);
            HasOptional(c => c.OperationNode).WithRequired(c => c.ExpressionNode).WillCascadeOnDelete(false);
            HasMany(c => c.OperationArgumentList).WithRequired(c => c.ExpressionArgument).HasForeignKey(c => c.ExpressionArgumentId).WillCascadeOnDelete(false);
            HasRequired(c => c.ExpressionNodeType).WithMany(c => c.ExpressionNode_ExpressionNodeTypes).HasForeignKey(c => c.ExpressionNodeTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).HasColumnName("idExpressionNode").IsRequired().HasColumnOrder(1);
            Property(c => c.ExpressionNodeTypeId).HasColumnName("idExpressionNodeType").IsRequired().HasColumnOrder(2);
        }
    }
}
