using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get; private set; }

        public Expression<Func<T, object>> OrderByDescending {get; private set; }

        public int Take {get; private set; }

        public int Skip {get; private set; }

        public bool isPaging {get; private set; }

        public List<string> IncludeString { get; } = new List<string>();

        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddInclude(Expression<Func<T,object>> include)
        {
            Includes.Add(include);
        }

        public void AddIncludeString(string includeString)
        {
            IncludeString.Add(includeString);
        }

        public void AddOrderby(Expression<Func<T,object>> orderBy)
        {
            OrderBy = orderBy;
        }

        public void AddORderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }

        public void ApplyPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            isPaging = true;
        }
    }
}
