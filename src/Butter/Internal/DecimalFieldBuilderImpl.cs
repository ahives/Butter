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
    using Specification;

    class DecimalFieldBuilderImpl :
        DecimalFieldBuilder
    {
        string _id;
        bool _nullable;
        int _scale;
        int _precision;

        public DecimalFieldBuilderImpl()
        {
            _nullable = false;
            _scale = 2;
            _precision = 3;
        }

        public DecimalFieldBuilder Id(string id)
        {
            _id = id;
            
            return this;
        }

        public DecimalFieldBuilder IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public DecimalFieldBuilder Scale(int scale)
        {
            _scale = scale;

            return this;
        }

        public DecimalFieldBuilder Precision(int precision)
        {
            _precision = precision;

            return this;
        }

        public DecimalField Build() => new DecimalFieldImpl(_id, _scale, _precision, _nullable);
    }
}