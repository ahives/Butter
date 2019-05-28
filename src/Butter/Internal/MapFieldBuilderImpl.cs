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

    class MapFieldBuilderImpl :
        MapFieldBuilder
    {
        string _fieldId;
        bool _nullable;

        public MapFieldBuilder Id(string fieldId)
        {
            _fieldId = fieldId;
            
            return this;
        }

        public MapFieldBuilder IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public MapField Build() => new MapFieldImpl(_fieldId, _nullable);
    }
}