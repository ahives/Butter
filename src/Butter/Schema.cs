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
namespace Butter
{
    using System;
    using System.Collections.Generic;
    using Data;

    public class Schema :
        ISchema, IEquatable<Schema>
    {
        public IFieldList Fields { get; }

        internal Schema(params Data.Model.Field[] fields)
        {
            Fields = new FieldList();
            Fields.AddRange(fields);
        }

        internal Schema(IFieldList fields)
        {
            Fields = fields;
        }

        internal Schema()
        {
            Fields = new FieldList();
        }

        public static ISchemaBuilder Builder() => new SchemaBuilder();

        public bool Equals(Schema other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;

            return Fields.Equals(other.Fields);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            
            if (ReferenceEquals(this, obj))
                return true;
            
            if (obj.GetType() != this.GetType())
                return false;
            
            return Equals((Schema) obj);
        }

        public override int GetHashCode() => Fields != null ? Fields.GetHashCode() : 0;

        public class Field
        {
            static readonly IDictionary<string, object> _builderCache;
        
            static Field()
            {
                _builderCache = new Dictionary<string, object>
                {
                    {typeof(FieldBuilder).FullName, new FieldBuilderImpl()},
                    {typeof(DecimalFieldBuilder).FullName, new DecimalFieldBuilderImpl()},
                    {typeof(MapFieldBuilder).FullName, new MapFieldBuilderImpl()}
                };
            }

            public static T Builder<T>()
            {
                if (!_builderCache.ContainsKey(typeof(T).FullName))
                    throw new BuilderMissingException($"Failed to find implementation class for interface {typeof(T)}");

                return (T) _builderCache[typeof(T).FullName];
            }
        }
    }
}