using System.Linq.Expressions;

namespace EightFigures.Contacts.Domain.Extension
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Merge<T>(this Expression<Func<T, bool>> filtroPpal, Expression<Func<T, bool>> filtroCombinar)
        {
            if (filtroPpal == null)
            {
                return filtroCombinar;
            }
            else
            {
                var rewrittenBody1 = new ReplaceVisitor(filtroPpal.Parameters[0], filtroCombinar.Parameters[0]).Visit(filtroPpal.Body);
                return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(rewrittenBody1, filtroCombinar.Body), filtroCombinar.Parameters);
            }
        }

        public class ReplaceVisitor : ExpressionVisitor
        {
            private readonly Expression _from;
            private readonly Expression _to;

            public ReplaceVisitor(Expression from, Expression to) => (_from, _to) = (from, to);

            public override Expression Visit(Expression node) => node == _from ? _to : base.Visit(node);
        }
    }
}
