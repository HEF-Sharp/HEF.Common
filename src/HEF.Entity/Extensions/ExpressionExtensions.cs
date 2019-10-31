using System;
using System.Linq.Expressions;
using System.Reflection;

namespace HEF.Entity
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// 从Lambda表达式中获取PropertyInfo
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public static PropertyInfo ParseProperty(this LambdaExpression lambdaExpression)
        {
            if (lambdaExpression == null)
                throw new ArgumentNullException(nameof(lambdaExpression)); 

            Expression expr = lambdaExpression;
            for (; ; )
            {
                switch (expr.NodeType)
                {
                    case ExpressionType.Lambda:
                        expr = ((LambdaExpression)expr).Body;
                        break;
                    case ExpressionType.Convert:
                        expr = ((UnaryExpression)expr).Operand;
                        break;
                    case ExpressionType.MemberAccess:
                        MemberExpression memberExpression = (MemberExpression)expr;
                        return memberExpression.Member as PropertyInfo;
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// 解析属性名
        /// </summary>
        /// <param name="propertyExpr"></param>
        /// <returns></returns>
        public static string ParsePropertyName(this LambdaExpression lambdaExpression)
        {
            var propertyInfo = ParseProperty(lambdaExpression);

            return propertyInfo?.Name;
        }
    }
}
