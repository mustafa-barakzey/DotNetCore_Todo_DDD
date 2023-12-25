using System.Reflection;

namespace brk.Framework.Tools.Utils
{
    public static class AttributeHelper
    {
        /// <summary>
        /// چک میکند که آیا در این کلاس پراپرتی مورد نظر دارای اتریبیوت ارسال شده میباشد ؟
        /// </summary>
        /// <typeparam name="TClass">کلاس مورد نظر</typeparam>
        /// <typeparam name="TAttibute">اتریبیوت</typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool HasThisAttribute<TClass, TAttibute>(string propertyName) where TClass : class where TAttibute : Attribute
            => typeof(TClass)
                .GetProperties()
                .Any(m => m.GetCustomAttributes().Select(a => a.GetType())
                                         .Contains(typeof(TAttibute)) &&
                                     string.Equals(m.Name, propertyName, StringComparison.CurrentCultureIgnoreCase));

        /// <summary>
        /// واکشی پراپرتی های موجود در کلاس که دارای اتریبیوت مورد نظر میباشد
        /// </summary>
        /// <typeparam name="TClass">کلاس مورد نظر</typeparam>
        /// <typeparam name="TAttibute">اتریبیوت</typeparam>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertiesByAttribute<TClass, TAttibute>() where TAttibute : Attribute
        {
            var properties = typeof(TClass).GetProperties()
                .Where(m => m.GetCustomAttributes().Select(a => a.GetType()).Contains(typeof(TAttibute)))
                .ToList();
            return properties.ToList();
        }
    }
}
