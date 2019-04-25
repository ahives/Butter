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
namespace Butter.Model
{
    using System;
    using Metadata;

    public class EmptyField<T> :
        Field
    {
        public EmptyField()
        {
            Value = new ValueImpl();
        }

        class ValueImpl :
            Value
        {
            public string Data { get; }
            public DataType DataType => DataType.None;
            public Type ClrType { get; }
        }

//        public Value Value => throw new ValueEmptyException("The field value is empty.");
//        public Value Value => throw new ValueEmptyException("The field value is empty.");
        public string Name { get; }
        public Value Value { get; }
        public DataType DataType => typeof(T).Convert();
        public Type Type => typeof(T);
    }

    public class EmptyField :
        Field
    {
        public string Name { get; }
        public Value Value { get; }

        public DataType DataType => DataType.None;
//        public Type Type => typeof().Convert(DataType.None);
    }
}