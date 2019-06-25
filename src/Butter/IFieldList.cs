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
        void Add(PrimitiveField field);

        void Add<TBuilder>(Func<TBuilder, PrimitiveField> criteria)
            where TBuilder : ISpecificationBuilder;

        void AddRange(params PrimitiveField[] fields);

        void AddRange(IList<PrimitiveField> field);

        PrimitiveField Remove(int index);

        PrimitiveField Remove(string id);

        bool TryRemove(int index, out PrimitiveField field);

        bool TryRemove(string id, out PrimitiveField field);

        PrimitiveField Replace(int index, PrimitiveField field);

        PrimitiveField Replace(string id, PrimitiveField field);

        bool TryReplace(int index, PrimitiveField field, out PrimitiveField replaced);

        bool TryReplace(string id, PrimitiveField field, out PrimitiveField replaced);
    }
}