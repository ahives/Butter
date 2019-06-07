namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class StructFieldTests
    {
        [Test]
        public void Verify_can_access_struct_fields_by_id()
        {
            var fields = new FieldList();
            
            var field1 = FieldSpec.Builder<StructFieldBuilder>()
                .Id("field1")
                .IsNullable()
                .Field<FieldBuilder>(x => x.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<DecimalFieldBuilder>(x => x.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                .Build();
            
            fields.Add(field1);

            var field2 = FieldSpec.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);

            var field3 = FieldSpec.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);

            var field4 = FieldSpec.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field4);

            var field5 = FieldSpec.Builder<FieldBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field5);

            var field6 = FieldSpec.Builder<FieldBuilder>()
                .Id("field6")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field6);

            Assert.IsNotNull(fields["field1"]);
            Assert.IsNotNull(fields["field1"].Cast<StructField>().Fields["fieldB"]);
        }

        [Test]
        public void Verify_can_set_by_schema_builder()
        {
            var fields = new FieldList();

            Field field1 = FieldSpec.Builder<FieldBuilder>()
                .Id("fieldA")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            Field field2 = FieldSpec.Builder<FieldBuilder>()
                .Id("fieldB")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            Field field3 = FieldSpec.Builder<FieldBuilder>()
                .Id("fieldC")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);

            DecimalField field4 = FieldSpec.Builder<DecimalFieldBuilder>()
                .Id("field")
                .Precision(5)
                .Scale(2)
                .Build();
            
            fields.Add(field4);

            var schema = Schema.Builder()
                .Field<StructFieldBuilder>(x => x.Id("fieldX").IsNullable().Fields(fields).Build())
                .Build();

            Assert.AreEqual(1, schema.Fields.Count);
            Assert.AreEqual(5, schema.Fields.SelectMany().Count);
        }
    }
}