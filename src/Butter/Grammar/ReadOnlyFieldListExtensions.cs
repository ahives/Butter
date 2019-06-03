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
    using System;
    using System.Collections.Generic;

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
                    case StructFieldSpec field:
                        fields.AddRange(field);
                        for (int j = 0; j < field.Fields.Count; j++)
                        {
                            fields.Add(field.Fields[j]);
                        }
                        break;
                    
                    case ListFieldSpec field:
                        fields.AddRange(field);
                        break;
                    
                    case MapFieldSpec field:
                        fields.AddRange(field);
                        break;
                    
                    case DecimalFieldSpec field:
                        fields.AddRange(field);
                        break;
                    
                    case FieldSpec field:
                        fields.AddRange(field);
                        break;
                        
                    default:
                        throw new ArgumentException();
                }
            }

            return fields;
        }

        /// <summary>
        /// Converts a IReadOnlyFieldList into a <see cref="IList{T}"/>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IList<FieldSpec> ToList(this IReadOnlyFieldList source)
        {
            var list = new List<FieldSpec>();
            
            for (int i = 0; i < source.Count; i++)
            {
                list.Add(source[i]);
            }

            return list;
        }
    }
}