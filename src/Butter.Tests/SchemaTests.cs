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