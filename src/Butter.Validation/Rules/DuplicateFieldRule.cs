namespace Butter.Validation.Rules
{
    using System.Collections.Generic;
    using System.Linq;
    using NRules.Fluent.Dsl;
    using Specification;

    [Tag("FieldValidation")]
    [Description("DUPLICATE FIELD")]
    public class DuplicateFieldRule :
        Rule
    {
        public override void Define()
        {
            IEnumerable<PrimitiveField> fields = null;
            
            Name(nameof(DuplicateFieldRule));

            When()
                .Query(() => fields, x =>
                    x.Match<PrimitiveField>(f => fields.Contains(f))
                        .Collect());

            Then()
                .Do(x => x.NoOp());
        }
    }
}