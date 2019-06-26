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
    using Builders;
    using Specification;

    class DecimalImpl :
        Decimal
    {
        string _id;
        bool _nullable;
        int _scale;
        int _precision;
        int _index;

        public DecimalImpl()
        {
            _nullable = false;
            _scale = 2;
            _precision = 3;
        }

        public Decimal Id(string id)
        {
            _id = id;
            
            return this;
        }

        public Decimal Index(int index)
        {
            _index = index;
            
            return this;
        }

        public Decimal IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public Decimal Scale(int scale)
        {
            _scale = scale;

            return this;
        }

        public Decimal Precision(int precision)
        {
            _precision = precision;

            return this;
        }

        public DecimalField Build() => new DecimalFieldImpl(_id, _index, _scale, _precision, _nullable);
    }
}