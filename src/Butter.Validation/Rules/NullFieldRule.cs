namespace Butter.Validation.Rules
{
    using System.Collections.Generic;
    using System.Linq;
    using NRules.Fluent.Dsl;
    using Specification;

    [Tag("FieldValidation")]
    [Description("NULL FIELD")]
    public class NullFieldRule :
        Rule
    {
        public override void Define()
        {
            IEnumerable<PrimitiveField> fields = null;
            
            Name(nameof(NullFieldRule));

            When()
                .Query(() => fields, x =>
                    x.Match<PrimitiveField>(f => f == null)
                        .Collect()
                        .Where(f => f.Any()));

            Then()
                .Do(x => x.NoOp());
        }
    }
}