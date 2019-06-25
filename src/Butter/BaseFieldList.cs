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
    using System.Collections.Generic;
    using Notification;
    using Specification;

    public abstract class BaseFieldList :
        ObservableList
    {
        protected readonly List<SchemaField> _fields;
        protected int _count;

        protected BaseFieldList(bool notifyObservers)
            : base(notifyObservers)
        {
            _fields = new List<SchemaField>();
            _count = 0;
        }

        
        protected class FieldComparer :
            IEqualityComparer<SchemaField>
        {
            public bool Equals(SchemaField x, SchemaField y)
            {
                if (x == null || y == null)
                    return false;

                return x.Id == y.Id;
            }

            public int GetHashCode(SchemaField obj) => obj.Id.GetHashCode();
        }
    }
}