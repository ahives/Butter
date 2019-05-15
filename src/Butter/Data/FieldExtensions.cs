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
namespace Butter.Data
{
    using Model;

    public static class FieldExtensions
    {
        public static bool EqualTo(this Field source, Field target)
        {
            if (source == null && target == null)
                return false;
            
            if (source != null && target != null)
                return source.Id == target.Id && source.Type == target.Type;

            return false;
        }

        public static T As<T>(this Field field)
        {
            T Missing()
            {
                if (typeof(T) == typeof(DecimalField))
                    return (T) SchemaCache.MissingDecimalField;

                if (typeof(T) == typeof(MapField))
                    return (T) SchemaCache.MissingMapField;

                if (typeof(T) == typeof(ListField))
                    return (T) SchemaCache.MissingListField;

                return (T) SchemaCache.MissingField;
            }

            T Cast()
            {
                if (typeof(T) == typeof(DecimalField) ||
                    typeof(T) == typeof(MapField) ||
                    typeof(T) == typeof(ListField))
                {
                    return (T) field;
                }

                throw new NotSupportedCastException($"{typeof(T).FullName} is not a support object to cast to.");
            }

            return field == null ? Missing() : Cast();
        }
    }
}