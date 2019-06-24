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
namespace Butter.Specification
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Bson;
    using Notification;

    public interface IFieldList :
        IObservable<NotificationContext>, IReadOnlyFieldList, IEquatable<IFieldList>
    {
        void Add(Field field);

        void Add<TBuilder>(Func<TBuilder, Field> criteria)
            where TBuilder : ISpecificationBuilder;

        void AddRange(params Field[] fields);

        void AddRange(IList<Field> field);

        Field Remove(int index);

        Field Remove(string id);

        bool TryRemove(int index, out Field field);

        bool TryRemove(string id, out Field field);

        Field Replace(int index, Field field);

        Field Replace(string id, Field field);

        bool TryReplace(int index, Field field, out Field replaced);

        bool TryReplace(string id, Field field, out Field replaced);
    }
}