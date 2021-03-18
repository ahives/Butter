namespace Butter
{
    using System;
    using System.Collections.Generic;
    using Specification;

    public static class ReadOnlyFieldListExtensions
    {
        /// <summary>
        /// Iterates through a list of fields and returns a flattened list of fields.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IReadOnlyFieldList SelectMany(this IReadOnlyFieldList source)
        {
            var fields = new FieldList(false);
            
            for (int i = 0; i < source.Count; i++)
            {
                switch (source[i])
                {
                    case StructField field:
                        fields.Add(field);
                        for (int j = 0; j < field.Fields.Count; j++)
                        {
                            fields.Add(field.Fields[j]);
                        }
                        break;
                    
                    case ListField field:
                        fields.AddRange(field);
                        break;
                    
                    case MapField field:
                        fields.AddRange(field);
                        break;
                    
                    case DecimalField field:
                        fields.AddRange(field);
                        break;
                    
                    case DateTimeField field:
                        fields.AddRange(field);
                        break;
                    
                    case PrimitiveField field:
                        fields.AddRange(field);
                        break;
                        
                    default:
                        throw new ArgumentException();
                }
            }

            return fields;
        }
        
        /// <summary>
        /// Returns a IEnumerable on <see cref="IReadOnlyFieldList"/>
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static IEnumerable<PrimitiveField> ToEnumerable(this IReadOnlyFieldList fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                yield return fields[i];
            }
        }

        /// <summary>
        /// Converts a IReadOnlyFieldList into a <see cref="IList{T}"/>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IList<PrimitiveField> ToList(this IReadOnlyFieldList source)
        {
            var list = new List<PrimitiveField>();
            
            for (int i = 0; i < source.Count; i++)
            {
                list.Add(source[i]);
            }

            return list;
        }
    }
}