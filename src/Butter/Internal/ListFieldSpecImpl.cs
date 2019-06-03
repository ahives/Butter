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

    class ListFieldSpecImpl :
        ListFieldSpec
    {
        public ListFieldSpecImpl(string id)
        {
            Id = id;
            DataType = FieldDataType.List;
        }

        public string Id { get; }
        public bool IsNullable { get; }
        public FieldDataType DataType { get; }

        public bool Equals(ListFieldSpec other)
        {
            if (string.IsNullOrWhiteSpace(Id) || other == null || string.IsNullOrWhiteSpace(other.Id))
                return false;

            return string.Equals(Id, other.Id) && DataType == other.DataType;
        }

        public bool Equals(FieldSpec other)
        {
            if (string.IsNullOrWhiteSpace(Id) || other == null || string.IsNullOrWhiteSpace(other.Id))
                return false;

            return string.Equals(Id, other.Id) && DataType == other.DataType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            
            if (ReferenceEquals(this, obj))
                return true;
            
            if (obj.GetType() != this.GetType())
                return false;
            
            return Equals((FieldSpec)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (int) DataType;
            }
        }
    }
}