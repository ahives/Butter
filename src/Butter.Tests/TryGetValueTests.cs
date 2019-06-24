namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class TryGetValueTests
    {
        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_negative_index()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.TryGetValue(-1, out _));
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_greater_than_count_index()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.TryGetValue(temp.Count + 1, out _));
        }

        [Test]
        public void Verify_can_create_list_of_fields_with_list3()
        {
            IReadOnlyFieldList fields = new FieldList();
            
            Assert.IsFalse(fields.TryGetValue(0, out var f1));
            Assert.AreEqual("[Butter].[missing_field_spec]", f1.Id);
        }

        [Test]
        public void Verify_TryGetValue_does_not_throw_when_empty()
        {
            IReadOnlyFieldList fields = new FieldList();
            
            Assert.IsFalse(fields.TryGetValue(0, out _));
        }
        
        [Test]
        public void Verify_TryGetValue_will_not_throw_when_index_less_than_zero()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.TryGetValue(-1, out Field field));
            Assert.IsNotNull(field);
        }

        [Test]
        public void Verify_TryGetValue_will_not_throw_when_index_greater_than_count()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            int count = temp.Count;
            Assert.IsFalse(temp.TryGetValue(count + 1, out Field field));
            Assert.IsNotNull(field);
        }

        [Test]
        public void Verify_TryGetValue_will_return_field()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsTrue(temp.TryGetValue(3, out Field field));
            Assert.IsNotNull(field);
            Assert.AreEqual("field4", field.Id);
            Assert.AreEqual(FieldDataType.Primitive, field.DataType);
        }

        [Test]
        public void Verify_TryGetValue_will_return_field_given_identifier()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsTrue(temp.TryGetValue("field4", out Field field));
            Assert.IsNotNull(field);
            Assert.AreEqual("field4", field.Id);
            Assert.AreEqual(FieldDataType.Primitive, field.DataType);
        }

        [Test]
        public void Verify_will_return_field_given_identifier()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsTrue(temp.TryGetValue("field4", out Field field));
            Assert.IsNotNull(field);
            Assert.AreEqual("field4", field.Id);
            Assert.AreEqual(FieldDataType.Primitive, field.DataType);
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_empty_list()
        {
            IReadOnlyFieldList fields = new FieldList();
            
            Assert.IsFalse(fields.TryGetValue(0, out _));
        }
    }
}