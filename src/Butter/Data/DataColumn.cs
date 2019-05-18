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
    using Grammar;

    public class DataColumn
    {
        public static Column Create(Field field, IValueList values)
        {
            if (field == null || values == null)
                return DataCache.Empty;
            
            return new ColumnImpl(field, values);
        }

        class ColumnImpl :
            Column
        {
            public ColumnImpl(Field field, IValueList values)
            {
                Field = field;
                Values = values;
                HasValues = values != null && values.HasValues;
            }

            public Field Field { get; }
            public IValueList Values { get; }
            public bool HasValues { get; }
        }
    }
}