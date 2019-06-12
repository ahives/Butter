namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ContainsListTests
    {
        [Test]
        public void Verify_can_find_field_in_readonly_list()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            Field field = FieldSpec.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsTrue(temp.Contains(field));
        }

        [Test]
        public void Verify_cannot_find_field_in_readonly_list()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            Field field = FieldSpec.Builder<FieldBuilder>()
                .Id("field7")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.Contains(field));
        }
        
        [Test]
        public void Verify_can_find_field()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            Field field = FieldSpec.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsTrue(temp.Contains(field));
        }

        [Test]
        public void Verify_cannot_find_field_by_field()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            Field field = FieldSpec.Builder<FieldBuilder>()
                .Id("field7")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.Contains(field));
        }

        [Test]
        public void Verify_cannot_find_field_by_field_id()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.Contains("field7"));
        }
    }
}