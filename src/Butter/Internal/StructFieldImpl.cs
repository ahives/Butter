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
    using Grammar;

    class StructFieldImpl :
        StructField
    {
        public string Id { get; }
        public bool IsNullable { get; }
        public FieldDataType DataType { get; }
        public IReadOnlyFieldList Fields { get; }

        public StructFieldImpl(string id, IReadOnlyFieldList fields, FieldDataType dataType = FieldDataType.Structure, bool isNullable = false)
        {
            Id = id;
            IsNullable = isNullable;
            DataType = dataType;
            Fields = fields;
        }

        public bool Equals(Field other)
        {
            if (string.IsNullOrWhiteSpace(Id) || other == null || string.IsNullOrWhiteSpace(other.Id))
                return false;

            return string.Equals(Id, other.Id) && DataType == other.DataType;
        }

        public bool Equals(StructField other)
        {
            if (string.IsNullOrWhiteSpace(Id) || other == null || string.IsNullOrWhiteSpace(other.Id))
                return false;

            if (Fields.Count != other.Fields.Count)
                return false;
            
            return string.Equals(Id, other.Id) && DataType == other.DataType && Fields.Equals(other.Fields);
        }
    }
}