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
namespace Butter.Grammar
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
        public static bool EqualTo(this FieldSpec source, FieldSpec target)
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
        public static T Cast<T>(this FieldSpec specification)
        {
            T Missing()
            {
                if (typeof(T) == typeof(DecimalFieldSpec))
                    return (T) SchemaCache.MissingDecimalFieldSpec;

                if (typeof(T) == typeof(MapFieldSpec))
                    return (T) SchemaCache.MissingMapFieldSpec;

                if (typeof(T) == typeof(ListFieldSpec))
                    return (T) SchemaCache.MissingListFieldSpec;

                return (T) SchemaCache.MissingFieldSpec;
            }

            T Cast()
            {
                if (typeof(T) == typeof(DecimalFieldSpec) ||
                    typeof(T) == typeof(MapFieldSpec) ||
                    typeof(T) == typeof(ListFieldSpec))
                {
                    return (T) specification;
                }

                throw new NotSupportedCastException($"{typeof(T).FullName} is not a support object to cast to.");
            }

            return specification == null ? Missing() : Cast();
        }

        /// <summary>
        /// Convert a field of type <see cref="FieldSpec"/> to a field of type <see cref="T"/>
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ConvertTo<T>(this FieldSpec source)
            where T : MapFieldSpec
        {
            if (typeof(T) == typeof(MapFieldSpec))
            {
                MapFieldSpec specification = new MapFieldSpecImpl(source.Id, source.IsNullable);
                return (T) specification;
            }

            if (typeof(T) == typeof(DecimalFieldSpec))
            {
                DecimalFieldSpec specification = new DecimalFieldSpecImpl(source.Id, source.IsNullable);
                return (T) specification;
            }

            return typeof(T).GetMissingField<T>();
        }
    }
}