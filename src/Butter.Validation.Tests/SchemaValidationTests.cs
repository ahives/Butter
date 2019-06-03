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
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec6 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            DecimalFieldSpec spec7 = Field.Builder<DecimalFieldSpecBuilder>()
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