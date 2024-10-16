using OnlineEducationPlatform.DAL.Data.DbHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Validation
{
    public class ForeignKeyValidAttribute : ValidationAttribute
    {
        private readonly string _relatedEntityProperty;
        private readonly Type _relatedEntityType;

        public ForeignKeyValidAttribute(string relatedEntityProperty , Type relatedEntityType)
        {
            _relatedEntityProperty = relatedEntityProperty;
            _relatedEntityType = relatedEntityType;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (EducationPlatformContext)validationContext.GetService(typeof(EducationPlatformContext));
            if (value == null)
            {
                return null;
            }

            var method = typeof(EducationPlatformContext).GetMethod("Set").MakeGenericMethod(_relatedEntityType);

            var dbSet = method.Invoke(context, null);

            var exist = dbSet.GetType().GetMethod("Find").Invoke(dbSet, new object[] { value });

            if (exist == null)
            {
                return new ValidationResult($"{_relatedEntityProperty} is not valid.");
            }

            return ValidationResult.Success;
        }
    }
}
