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
namespace Butter.Validation.Internal
{
    using System.Collections.Generic;
    using System.Linq;
    using Validation;

    public class ValidationList :
        IValidationList
    {
        readonly List<ValidationResult> _validations;
        int _count;

        public ValidationList()
        {
            _validations = new List<ValidationResult>();
            _count = 0;
        }

        public void Add(ValidationResult validation)
        {
            if (validation == null)
                return;

            if (validation.Type == ValidationType.Error)
                HasErrors = true;
            
            _validations.Add(validation);
            _count = _validations.Count;
        }

        public bool HasErrors { get; private set; }
        public int Count => _count;

        public ValidationResult this[int index]
        {
            get
            {
                TryGetValue(index, out ValidationResult validation);

                return validation;
            }
        }

        public bool TryGetValue(int index, out ValidationResult validation)
        {
            if (index < 0 || _count <= 0)
            {
                validation = ValidationCache.MissingValidationResult;
                return false;
            }

            if (index < _count)
            {
                validation = _validations[index];
                return true;
            }
            
            validation = ValidationCache.MissingValidationResult;
            return false;
        }

        public bool Contains(ValidationResult validation) => validation != null && _validations.Contains(validation, new ValidationComparer());

        public void Clear()
        {
            _validations.Clear();
        }


        class ValidationComparer :
            IEqualityComparer<ValidationResult>
        {
            public bool Equals(ValidationResult x, ValidationResult y)
            {
                if (x == null || y == null)
                    return false;

                return x.Reason == y.Reason;
            }

            public int GetHashCode(ValidationResult obj) => obj.Reason.GetHashCode();
        }
    }
}