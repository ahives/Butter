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
namespace Butter.Internal
{
    using Specification;

    class MapFieldImpl :
        MapField
    {
        public MapFieldImpl(string id, FieldMap<SchemaField, SchemaField> field, bool isNullable = false)
        {
            Id = id;
            Key = field != null ? field.Key : SchemaCache.MissingField;
            Value = field != null ? field.Value : SchemaCache.MissingField;
            DataType = FieldDataType.Map;
            IsNullable = isNullable;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public MapFieldImpl(string id, bool isNullable)
        {
            Id = id;
            Key = SchemaCache.MissingField;
            Value = SchemaCache.MissingField;
            DataType = FieldDataType.Map;
            IsNullable = isNullable;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public bool IsNullable { get; }
        public FieldDataType DataType { get; }
        public bool HasValue { get; }
        public SchemaField Key { get; }
        public SchemaField Value { get; }

        public override string ToString() => $"FIELD [ID = '{Id}', Data Type = {DataType.ToString()}, Nullable = {(IsNullable ? bool.TrueString : bool.FalseString)}]";
    }
}