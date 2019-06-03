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
    using System.Collections.Generic;
    using Notification;

    public abstract class BaseFieldList :
        ObservableList
    {
        protected readonly List<FieldSpec> _fields;
        protected int _count;

        protected BaseFieldList(bool notifyObservers)
            : base(notifyObservers)
        {
            _fields = new List<FieldSpec>();
            _count = 0;
        }

        
        protected class FieldComparer :
            IEqualityComparer<FieldSpec>
        {
            public bool Equals(FieldSpec x, FieldSpec y)
            {
                if (x == null || y == null)
                    return false;

                return x.Id == y.Id;
            }

            public int GetHashCode(FieldSpec obj) => obj.Id.GetHashCode();
        }
    }
}