﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace HEF.Entity
{
    internal static class ExpressionExtensions
    {
        /// <summary>
        /// 从Lambda表达式中获取PropertyInfo
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        internal static PropertyInfo ParseProperty(this LambdaExpression lambdaExpression)
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
    }
}
