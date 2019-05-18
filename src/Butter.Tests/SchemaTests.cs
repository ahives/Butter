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
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive, false)
                .Field("field2", FieldDataType.Primitive, false)
                .Field("field3", FieldDataType.Primitive, false)
                .Field("field4", FieldDataType.Primitive, false)
                .Field("field5", FieldDataType.Primitive, false)
                .Build();

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
    }
}