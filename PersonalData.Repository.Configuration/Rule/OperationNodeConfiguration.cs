using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Configuration.Rule {

    public class OperationNodeConfiguration : EntityTypeConfiguration<OperationNode> {

        public OperationNodeConfiguration() {

            ToTable("ftOperationNodes");
            HasKey(c => c.Id);

            HasRequired(c => c.ExpressionNode).WithOptional(c => c.OperationNode);
            HasMany(c => c.OperationArgumentList).WithRequired(c => c.ExpressionOperation).WillCascadeOnDelete(false);
            HasRequired(c => c.OperationNodeType).WithMany(c => c.OperationNode_OperationNodeTypes).HasForeignKey(c => c.OperationNodeTypeId).WillCascadeOnDelete(false);

            Property(c => c.Id).IsRequired().HasColumnName("idOperationNode").HasColumnOrder(1);
            Property(c => c.OperationNodeTypeId).IsRequired().HasColumnName("idOperationNodeType").HasColumnOrder(2);
        }
    }
}
