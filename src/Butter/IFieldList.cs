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
    using Notification;
    using Specification;

    public interface IFieldList :
        IObservable<NotificationContext>, IReadOnlyFieldList, IEquatable<IFieldList>
    {
        void Add(SchemaField field);

        void Add<TBuilder>(Func<TBuilder, SchemaField> criteria)
            where TBuilder : ISpecificationBuilder;

        void AddRange(params SchemaField[] fields);

        void AddRange(IList<SchemaField> field);

        SchemaField Remove(int index);

        SchemaField Remove(string id);

        bool TryRemove(int index, out SchemaField field);

        bool TryRemove(string id, out SchemaField field);

        SchemaField Replace(int index, SchemaField field);

        SchemaField Replace(string id, SchemaField field);

        bool TryReplace(int index, SchemaField field, out SchemaField replaced);

        bool TryReplace(string id, SchemaField field, out SchemaField replaced);
    }
}