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
    using Exceptions;
    using Model;

    public class OutOfRangeField :
        Field
    {
        public string Id => throw new FieldOutOfRangeException("The index is out of range.");
        public FieldType Type => FieldType.None;

        public bool Equals(Field other) => false;

        public override bool Equals(object obj) => Equals((Field)obj);

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (int) Type;
            }
        }
    }
}