// ***********************************************************************************
// Copyright 2019 Albert L. Hives
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
// ***********************************************************************************
namespace Butter.Specification
{
    using Internal;

    public static class FieldExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool EqualTo(this Field source, Field target)
        {
            if (source == null && target == null)
                return false;
            
            if (source != null && target != null)
                return source.Id == target.Id && source.DataType == target.DataType;

            return false;
        }

        /// <summary>
        /// Cast the given field to a field of type <see cref="T"/>.
        /// </summary>
        /// <param name="specification"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotSupportedCastException"></exception>
        public static T Cast<T>(this Field specification)
        {
            T Missing()
            {
                if (typeof(T) == typeof(DecimalField))
                    return (T) SchemaCache.MissingDecimalField;

                if (typeof(T) == typeof(MapField))
                    return (T) SchemaCache.MissingMapField;

                if (typeof(T) == typeof(StructField))
                    return (T) SchemaCache.MissingStructField;

                if (typeof(T) == typeof(ListField))
                    return (T) SchemaCache.MissingListField;

                return (T) SchemaCache.MissingField;
            }

            T Cast()
            {
                if (typeof(T) == typeof(DecimalField) ||
                    typeof(T) == typeof(MapField) ||
                    typeof(T) == typeof(StructField) ||
                    typeof(T) == typeof(ListField))
                {
                    return (T) specification;
                }

                throw new NotSupportedCastException($"{typeof(T).FullName} is not a support object to cast to.");
            }

            return specification == null ? Missing() : Cast();
        }

        /// <summary>
        /// Convert a field of type <see cref="Field"/> to a field of type <see cref="T"/>
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ConvertTo<T>(this Field source)
            where T : MapField
        {
            if (typeof(T) == typeof(MapField))
            {
                MapField specification = new MapFieldImpl(source.Id, source.IsNullable);
                return (T) specification;
            }

            if (typeof(T) == typeof(DecimalField))
            {
                DecimalField specification = new DecimalFieldImpl(source.Id, source.IsNullable);
                return (T) specification;
            }

            if (typeof(T) == typeof(StructField))
            {
                StructField specification = new StructFieldImpl(source.Id, source.IsNullable);
                return (T) specification;
            }

            return typeof(T).GetMissingField<T>();
        }
    }
}