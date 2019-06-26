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

    class StructFieldImpl :
        StructField
    {
        public StructFieldImpl(string id, int index, IReadOnlyFieldList fields, bool isNullable = false)
        {
            Id = id;
            Index = index;
            IsNullable = isNullable;
            DataType = SchemaDataType.Struct;
            Fields = fields;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public StructFieldImpl(string id, int index, bool isNullable)
        {
            Id = id;
            Index = index;
            IsNullable = isNullable;
            DataType = SchemaDataType.Struct;
            Fields = SchemaCache.EmptyFieldList;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public bool IsNullable { get; }
        public SchemaDataType DataType { get; }
        public bool HasValue { get; }
        public int Index { get; }
        public IReadOnlyFieldList Fields { get; }

        public override string ToString() => $"FIELD [ID = '{Id}', Data Type = {DataType.ToString()}, Nullable = {(IsNullable ? bool.TrueString : bool.FalseString)}]";
    }
}