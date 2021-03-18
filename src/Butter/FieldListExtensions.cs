namespace Butter
{
    using System.Collections.Generic;
    using Specification;

    public static class FieldListExtensions
    {
        /// <summary>
        /// Returns a IEnumerable on <see cref="IFieldList"/>
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static IEnumerable<PrimitiveField> ToEnumerable(this IFieldList fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                yield return fields[i];
            }
        }
    }
}