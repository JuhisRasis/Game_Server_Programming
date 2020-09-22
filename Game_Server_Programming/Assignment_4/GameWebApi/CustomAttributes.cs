using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameWebApi.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class LevelAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int i = (int)value;
            return i > 0 && i < 100 ? true : false;
        }

    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class TypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                return (ItemType)value == ItemType.Weapon ? true : (ItemType)value == ItemType.HealthKit ? true : (ItemType)value == ItemType.Relic ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class PastDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                return (DateTime)value != DateTime.UtcNow;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}