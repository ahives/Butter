namespace Butter.Tests
{
    using System;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class TryReplaceFieldListTests
    {
        [Test]
        public void Test()
        {
            var fields = new FieldList();
            
            fields.Add<FieldBuilder>(x => x.Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            SchemaField field = Field.Builder<DecimalFieldBuilder>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            Assert.IsTrue(fields.TryReplace(2, field, out SchemaField replaced));
            Assert.AreEqual(5, fields.Count);
            Assert.IsTrue(replaced.HasValue);

            DecimalField f1 = fields[2].Cast<DecimalField>();
            
            Assert.AreEqual("field3A", f1.Id);
            Assert.AreEqual(2, f1.Precision);
            Assert.AreEqual(5, f1.Scale);
        }

        [Test]
        public void Verify_does_not_throw_when_index_less_than_zero()
        {
            var fields = new FieldList();
            
            fields.Add<FieldBuilder>(x => x.Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            SchemaField field = Field.Builder<DecimalFieldBuilder>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(fields.TryReplace(-1, field, out SchemaField replaced));
            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
        }

        [Test]
        public void Verify_does_not_throw_when_index_greater_than_count()
        {
            var fields = new FieldList();
            
            fields.Add<FieldBuilder>(x => x.Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            SchemaField field = Field.Builder<DecimalFieldBuilder>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(fields.TryReplace(10, field, out SchemaField replaced));
            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
        }

        [Test]
        public void Verify_can_replace_by_id()
        {
            var fields = new FieldList();
            
            fields.Add<FieldBuilder>(x => x.Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            SchemaField field = Field.Builder<DecimalFieldBuilder>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            Assert.IsTrue(fields.TryReplace("field3", field, out SchemaField replaced));
            Assert.AreEqual(5, fields.Count);
            Assert.IsTrue(replaced.HasValue);
            Assert.AreEqual("field3", replaced.Id);
            Assert.AreEqual(FieldDataType.Primitive, replaced.DataType);

            DecimalField f1 = fields[2].Cast<DecimalField>();
            
            Assert.AreEqual("field3A", f1.Id);
            Assert.AreEqual(2, f1.Precision);
            Assert.AreEqual(5, f1.Scale);
        }

        [Test]
        public void Verify_does_not_throw_when_id_does_not_exist()
        {
            var fields = new FieldList();
            
            fields.Add<FieldBuilder>(x => x.Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            SchemaField field = Field.Builder<DecimalFieldBuilder>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(fields.TryReplace("fieldX", field, out SchemaField replaced));
            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
        }

        [Test]
        public void Verify_does_not_throw_when_id_missing()
        {
            var fields = new FieldList();
            
            fields.Add<FieldBuilder>(x => x.Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            SchemaField field = Field.Builder<DecimalFieldBuilder>()
                .Id("field3A")
                .Precision(2)
                .Scale(5)
                .IsNullable()
                .Build();

            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(fields.TryReplace(string.Empty, field, out SchemaField replaced));
            Assert.AreEqual(5, fields.Count);
            Assert.IsFalse(replaced.HasValue);
        }
    }
}