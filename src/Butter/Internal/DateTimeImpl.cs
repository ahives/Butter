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

    class DateTimeImpl :
        DateTime
    {
        string _id;
        bool _nullable;
        DateTimeEncoding _encoding;

        public DateTime Id(string id)
        {
            _id = id;
            
            return this;
        }

        public DateTime IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public DateTime Encoding(DateTimeEncoding encoding)
        {
            _encoding = encoding;
            
            return this;
        }

        public DateTimeField Build() => new DateTimeFieldImpl(_id, _encoding, _nullable);
    }
}