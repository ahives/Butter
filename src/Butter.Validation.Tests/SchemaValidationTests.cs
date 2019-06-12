namespace Butter.Validation.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class SchemaValidationTests
    {
        [Test]
        public void Verify_cannot_add_fields_with_same_identifier()
        {
            ISchemaValidator validator = new SchemaValidator();
            var schema = Schema.Builder()
                .Field<StructFieldBuilder>(x =>
                {
                    return x.Id("field1")
                        .Field<FieldBuilder>(f => f.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<DecimalFieldBuilder>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<FieldBuilder>(x => x.Id("field2").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field3").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field4").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field5").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field6").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field3").IsNullable().Build())
                .Field(null)
                .RegisterObserver(validator)
                .Build();
//                .Validate();
            
            validator.Validate();

//            Assert.IsTrue(schema.Fields.HasValues);
//            Assert.AreEqual(7, schema.Fields.Count);
//
//            Assert.IsNotEmpty(validator.Validation);
//            Assert.AreEqual(1, validator.Validation.Count);
        }

    }
}