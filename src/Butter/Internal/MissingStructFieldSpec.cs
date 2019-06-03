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

    public class MissingStructFieldSpec :
        StructFieldSpec
    {
        public string Id => "[Butter].[missing_field_spec]";
        public bool IsNullable => false;
        public FieldDataType DataType => FieldDataType.Struct;
        public IReadOnlyFieldList Fields => new EmptyFieldList();
        
        public bool Equals(FieldSpec other) => false;

        public bool Equals(StructFieldSpec other) => false;
    }
}