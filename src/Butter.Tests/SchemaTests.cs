namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Verify_can_add_fields_after_construction()
        {
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
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
    }
}