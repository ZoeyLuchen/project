using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InsteadBuyPlatform.Common
{
    public static class ExpressionExt
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.And(expr1.Body, expr2.Body), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, expr2.Body), expr1.Parameters);
        }
    }
}
