namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class AddListTests
    {
        [Test]
        public void Verify_does_not_allow_adding_duplicate_fields_using_Add()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(1, fields.Count);
        }
    }
}