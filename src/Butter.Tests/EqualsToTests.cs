namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class EqualsToTests
    {
        [Test]
        public void Verify_EqualsTo_returns_true()
        {
            PrimitiveField spec = Field.Builder<Primitive>()
                .Id("city")
                .DataType(SchemaDataType.Primitive)
                .Build();

            var schema1 = Schema.Builder()
                .Field(spec)
                .Build();
            
            var schema2 = Schema.Builder()
                .Field(spec)
                .Build();

            Assert.IsTrue(schema1.Fields[0].EqualTo(schema2.Fields[0]));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false_when_types_different()
        {
            PrimitiveField spec1 = Field.Builder<Primitive>()
                .Id("city")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec2 = Field.Builder<Primitive>()
                .Id("city")
                .DataType(SchemaDataType.Decimal)
                .Build();

            var schema1 = Schema.Builder()
                .Field(spec1)
                .Build();
            
            var schema2 = Schema.Builder()
                .Field(spec2)
                .Build();

            Assert.IsFalse(schema1.Fields[0].EqualTo(schema2.Fields[0]));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false()
        {
            PrimitiveField spec1 = Field.Builder<Primitive>()
                .Id("city")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec2 = Field.Builder<Primitive>()
                .Id("state")
                .DataType(SchemaDataType.Primitive)
                .Build();

            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Build();

            Assert.IsFalse(schema.Fields[0].EqualTo(schema.Fields[1]));
        }

        [Test]
        public void Verify_does_not_throw_when_empty_field_accessed()
        {
            IFieldList fields = new FieldList();
            fields.Add(null);
            
            Assert.IsFalse(fields.TryGetValue(0, out var f1));
            Assert.AreEqual("[Butter].[missing_field_spec]", f1.Id);
        }

        [Test]
        public void Verify_null_objects_are_equal()
        {
            PrimitiveField field1 = null;
            PrimitiveField field2 = null;
            
            Assert.IsFalse(field1.EqualTo(field2));
        }
    }
}