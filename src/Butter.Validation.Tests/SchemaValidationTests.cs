namespace Butter.Validation.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class SchemaValidationTests
    {
        [Test]
        public void Verify_cannot_add_fields_with_same_identifier()
        {
            ISchemaValidator validator = new SchemaValidator();
            Field spec1 = FieldSpec.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec2 = FieldSpec.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec3 = FieldSpec.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec4 = FieldSpec.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec5 = FieldSpec.Builder<FieldBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec6 = FieldSpec.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            DecimalField spec7 = FieldSpec.Builder<DecimalFieldBuilder>()
                .Id("field6")
                .Precision(2)
                .Scale(4)
                .Build();

            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Field(spec7)
                .Build();
//                .Validate();
            
//            validator.Validate();

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(7, schema.Fields.Count);

            Assert.IsNotEmpty(validator.Validation);
            Assert.AreEqual(1, validator.Validation.Count);
        }

    }
}