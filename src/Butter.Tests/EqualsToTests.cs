namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class EqualsToTests
    {
        [Test]
        public void Verify_EqualsTo_returns_true()
        {
            FieldSpec spec = Field.Builder<FieldSpecBuilder>()
                .Id("city")
                .DataType(FieldDataType.Primitive)
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
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("city")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("city")
                .DataType(FieldDataType.Decimal)
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
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("city")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("state")
                .DataType(FieldDataType.Primitive)
                .Build();

            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Build();

            Assert.IsFalse(schema.Fields[0].EqualTo(schema.Fields[1]));
        }

        [Test]
        public void Verify_throws_when_empty_field_accessed()
        {
            IFieldList fields = new FieldList();
            fields.Add(null);
            
            Assert.IsFalse(fields.TryGetValue(0, out var f1));
            Assert.Throws<FieldOutOfRangeException>(() =>
            {
                string fieldId = f1.Id;
            });
        }

        [Test]
        public void Verify_null_objects_are_equal()
        {
            FieldSpec field1 = null;
            FieldSpec field2 = null;
            
            Assert.IsFalse(field1.EqualTo(field2));
        }
    }
}