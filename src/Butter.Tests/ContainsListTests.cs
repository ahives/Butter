namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ContainsListTests
    {
        [Test]
        public void Verify_can_find_field_in_readonly_list()
        {
            var fields = new FieldList();
            
            fields.Add(Field.Builder<Primitive>().Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Primitive>()
                .Id("field4")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsTrue(temp.Contains(field));
        }

        [Test]
        public void Verify_cannot_find_field_in_readonly_list()
        {
            var fields = new FieldList();
            
            fields.Add(Field.Builder<Primitive>().Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Primitive>()
                .Id("field7")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.Contains(field));
        }
        
        [Test]
        public void Verify_can_find_field()
        {
            var fields = new FieldList();
            
            fields.Add(Field.Builder<Primitive>().Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Primitive>()
                .Id("field4")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsTrue(temp.Contains(field));
        }

        [Test]
        public void Verify_cannot_find_field_by_field()
        {
            var fields = new FieldList();
            
            fields.Add(Field.Builder<Primitive>().Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            PrimitiveField field = Field.Builder<Primitive>()
                .Id("field7")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.Contains(field));
        }

        [Test]
        public void Verify_cannot_find_field_by_field_id()
        {
            var fields = new FieldList();
            
            fields.Add(Field.Builder<Primitive>().Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsFalse(temp.Contains("field7"));
        }
    }
}