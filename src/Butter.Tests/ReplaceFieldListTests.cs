namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ReplaceFieldListTests
    {
        [Test]
        public void Test()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Decimal>()
                .Id("field3")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            
            PrimitiveField replaced = fields.Replace(2, field);

            Assert.AreEqual(5, fields.Count);

            DecimalField decimalField = fields[2].Cast<DecimalField>();
            
            Assert.AreEqual(SchemaDataType.Decimal, decimalField.DataType);
            Assert.AreEqual("field3", decimalField.Id);
            Assert.AreEqual(2, decimalField.Precision);
            Assert.AreEqual(5, decimalField.Scale);
        }

        [Test]
        public void Verify_does_not_throw_when_index_is_greater_than_count()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Decimal>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            
            PrimitiveField replaced = fields.Replace(10, field);

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
            Assert.AreEqual("field3", fields[2].Id);
        }

        [Test]
        public void Verify_does_not_throw_when_index_is_less_than_zero()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Decimal>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            
            PrimitiveField replaced = fields.Replace(-1, field);

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
            Assert.AreEqual("field3", fields[2].Id);
        }

        [Test]
        public void Verify_can_replace_by_id()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Decimal>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            
            PrimitiveField replaced = fields.Replace("field4", field);

            Assert.AreEqual(5, fields.Count);
            Assert.IsTrue(replaced.HasValue);
            Assert.AreEqual("field3A", fields[3].Id);
        }

        [Test]
        public void Verify_can_replace_by_none_existing_id()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Decimal>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            
            PrimitiveField replaced = fields.Replace("fieldX", field);

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
        }

        [Test]
        public void Verify_can_replace_by_missing_id()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Decimal>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            
            PrimitiveField replaced = fields.Replace(string.Empty, field);

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
        }
    }
}