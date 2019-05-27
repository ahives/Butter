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
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field6", x =>
                {
                    x.SetPrecision(2);
                    x.SetScale(4);
                })
                .RegisterObserver(validator)
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