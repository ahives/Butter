namespace Butter.Tests
{
    using Data;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class EqualsToTests
    {
        [Test]
        public void Verify_EqualsTo_returns_true()
        {
            var schema1 = Schema.Builder()
                .Field("city", FieldType.Primitive, false)
                .Build();
            
            var schema2 = Schema.Builder()
                .Field("city", FieldType.Primitive, false)
                .Build();

            Assert.IsTrue(schema1.Fields[0].EqualTo(schema2.Fields[0]));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false_when_types_different()
        {
            var schema1 = Schema.Builder()
                .Field("city", FieldType.Primitive, false)
                .Build();

            var schema2 = Schema.Builder()
                .Field("city", FieldType.List, false)
                .Build();

            Assert.IsFalse(schema1.Fields[0].EqualTo(schema2.Fields[0]));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false()
        {
            var schema = Schema.Builder()
                .Field("city", FieldType.Primitive, false)
                .Field("state", FieldType.Primitive, false)
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
            Field field1 = null;
            Field field2 = null;
            
            Assert.IsFalse(field1.EqualTo(field2));
        }
    }
}