using HEF.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace HEF.Entity
{
    /// <summary>
    /// 实体数据验证扩展
    /// </summary>
    public static class EntityValidateExtensions
    {
        public static ICollection<ValidationResult> Validate<TEntity>(this TEntity entity,
            params Expression<Func<TEntity, object>>[] ignorePropertyExpressions)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var propertyNames = GetPropertyNamesByExpression(ignorePropertyExpressions);

            return ValidateInternal(entity, (name) => !propertyNames.Contains(name));
        }

        public static ICollection<ValidationResult> ValidateInclude<TEntity>(this TEntity entity,
            params Expression<Func<TEntity, object>>[] includePropertyExpressions)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (includePropertyExpressions.IsEmpty())
                throw new ArgumentNullException(nameof(includePropertyExpressions));

            var propertyNames = GetPropertyNamesByExpression(includePropertyExpressions);

            return ValidateInternal(entity, (name) => propertyNames.Contains(name));
        }

        private static ICollection<ValidationResult> ValidateInternal<TEntity>(TEntity entity, Func<string, bool> propertyPredicate)
        {
            var (isValid, validationResults) = ValidateInternal(entity);
            if (isValid)
                return validationResults;

            return validationResults.Where(m => propertyPredicate(m.MemberNames.FirstOrDefault())).ToList();
        }

        private static (bool, ICollection<ValidationResult>) ValidateInternal<TEntity>(TEntity entity)
        {
            var validationResults = new Collection<ValidationResult>();

            var validationContext = new ValidationContext(entity, null, null);
            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return (isValid, validationResults);
        }

        private static IEnumerable<string> GetPropertyNamesByExpression<T>(params Expression<Func<T, object>>[] propertyExpressions)
        {
            if (propertyExpressions.IsNotEmpty())
            {
                foreach (var propertyExpression in propertyExpressions)
                {
                    if (propertyExpression == null)
                        continue;

                    var property = propertyExpression.ParseProperty();
                    if (property == null)
                        continue;

                    yield return property.Name;
                }
            }
        }
    }
}
