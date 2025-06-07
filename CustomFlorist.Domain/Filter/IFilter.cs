using System.Linq.Expressions;

namespace CustomFlorist.Domain.Filter;

public interface IFilter<T>
{
    Expression<Func<T, bool>> ToExpression();
}