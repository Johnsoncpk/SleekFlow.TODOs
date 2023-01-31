using System.Linq.Expressions;
using System.Reflection;
using SleekFlow.TODOs.Library.Result;

namespace SleekFlow.TODOs.Library.Linq
{
    public static class QueryableExtensions
    {
        public static PagedResult<TResult> GetPagedResult<TSource, TResult>(this IQueryable<TSource> query, Expression<Func<TSource, TResult>> selector, int page = 1, int pageSize = 10) where TSource : class
        {
            MaxPaging(ref page, ref pageSize);
            PagedResult<TResult> pagedResult = new PagedResult<TResult>(page, pageSize, query.Take(10000).Count());
            double a = (double)pagedResult.TotalCount / (double)pagedResult.PageSize;
            pagedResult.PageCount = (int)Math.Ceiling(a);
            int count = (page - 1) * pageSize;
            pagedResult.Items = query.Select(selector).Skip(count).Take(pagedResult.PageSize)
                .ToList();
            return pagedResult;
        }

        public static PagedResult<TResult> GetPagedResult<TSource, TKey, TResult>(this IQueryable<TSource> query, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TResult>> selector, int page = 1, int pageSize = 10) where TSource : class
        {
            MaxPaging(ref page, ref pageSize);
            PagedResult<TResult> pagedResult = new PagedResult<TResult>(page, pageSize, query.Take(10000).Count());
            double a = (double)pagedResult.TotalCount / (double)pagedResult.PageSize;
            pagedResult.PageCount = (int)Math.Ceiling(a);
            int count = (page - 1) * pageSize;
            if (keySelector != null)
            {
                query = query.OrderBy(keySelector);
            }

            pagedResult.Items = query.Select(selector).Skip(count).Take(pagedResult.PageSize)
                .ToList();
            return pagedResult;
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }

        public static PagedResult<TResult> GetSortedAndPagedResult<TSource, TResult>(this IQueryable<TSource> query, Expression<Func<TSource, TResult>> selector, int page, int pageSize, string? sorting, bool isDesc = false) where TSource : class
        {
            return query.Sortedby(sorting, isDesc).GetPagedResult(selector, page, pageSize);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, descending: false, anotherLevel: false);
        }

        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, descending: true, anotherLevel: false);
        }

        public static IQueryable<T> Sortedby<T>(this IQueryable<T> source, string? sorting, bool isDesc)
        {
            if (!string.IsNullOrWhiteSpace(sorting))
            {
                string str = (sorting![0].ToString() ?? "").ToUpperInvariant();
                string? text = sorting;
                sorting = str + text![new Range(end: text!.Length, start: 1)];
                if (!isDesc)
                {
                    return source.OrderBy(sorting);
                }

                return source.OrderByDescending(sorting);
            }

            return source;
        }

        private static void MaxPageSize(ref int pageSize)
        {
            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            if (pageSize > 200)
            {
                pageSize = 200;
            }
        }

        private static void MaxPaging(ref int page, ref int pageSize)
        {
            MaxPageSize(ref pageSize);
            if (page <= 0)
            {
                page = 1;
            }
            else if (page * pageSize > 10000)
            {
                double a = 10000.0 / (double)pageSize;
                page = (int)Math.Ceiling(a);
            }
        }

        private static IQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            string propertyName2 = propertyName;
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), string.Empty);
            if (parameterExpression.Type.BaseType == typeof(object))
            {
                PropertyInfo propertyInfo = Array.Find(parameterExpression.Type.GetProperties(), (PropertyInfo x) => x.PropertyType.GetProperty(propertyName2) != null);
                if ((object)propertyInfo != null)
                {
                    MemberExpression memberExpression = Expression.PropertyOrField(Expression.PropertyOrField(parameterExpression, propertyInfo.PropertyType.Name), propertyName2);
                    LambdaExpression expression = Expression.Lambda(memberExpression, parameterExpression);
                    MethodCallExpression expression2 = Expression.Call(typeof(Queryable), OrderMethodName(descending, anotherLevel), new Type[2]
                    {
                        typeof(T),
                        memberExpression.Type
                    }, source.Expression, Expression.Quote(expression));
                    return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(expression2);
                }
            }

            if (parameterExpression.Type.GetProperty(propertyName2) != null)
            {
                MemberExpression memberExpression2 = Expression.PropertyOrField(parameterExpression, propertyName2);
                LambdaExpression expression3 = Expression.Lambda(memberExpression2, parameterExpression);
                MethodCallExpression expression4 = Expression.Call(typeof(Queryable), OrderMethodName(descending, anotherLevel), new Type[2]
                {
                    typeof(T),
                    memberExpression2.Type
                }, source.Expression, Expression.Quote(expression3));
                return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(expression4);
            }

            return source;
        }

        private static string OrderMethodName(bool descending, bool anotherLevel)
        {
            return ((!anotherLevel) ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty);
        }
    }
}
