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

    public interface IFieldList :
        IObservable<Field>
    {
        void Add(Field field);

        void AddRange(params Field[] fields);

        void AddRange(IList<Field> fields);
        
        bool HasValues { get; }
        
        int Count { get; }
        
        Field this[int index] { get; }

        bool TryGetValue(int index, out Field field);

        bool TryGetValue(string id, out Field field);

        bool Contains(Field field);
    }
}