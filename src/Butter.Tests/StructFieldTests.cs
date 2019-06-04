namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class StructFieldTests
    {
        [Test]
        public void Verify_can_define_struct_field_within_method_chain()
        {
            var schema = Schema.Builder()
                .Field<StructFieldBuilder>(x =>
                {
                    return x.Id("field1")
                        .Field<FieldBuilder>(f => f.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<DecimalFieldBuilder>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<FieldBuilder>(x => x.Id("field6").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field7").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field8").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field9").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field10").IsNullable().Build())
                .Build();

            Assert.IsNotNull(schema.Fields["field1"]);
            Assert.IsNotNull(schema.Fields["field1"].Cast<StructField>().Fields["fieldB"]);
            Assert.AreEqual(6, schema.Fields.Count);
            Assert.AreEqual(10, schema.Fields.SelectMany().Count);
        }

        [Test]
        public void Verify_can_access_struct_fields_by_id()
        {
            var field = FieldSpec.Builder<StructFieldBuilder>()
                .Id("field1")
                .IsNullable()
                .Field<FieldBuilder>(x => x.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<DecimalFieldBuilder>(x => x.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                .Build();

            var schema = Schema.Builder()
                .Field(field)
                .Field<FieldBuilder>(x => x.Id("field6").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field7").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field8").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field9").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field10").IsNullable().Build())
                .Build();

            Assert.IsNotNull(schema.Fields["field1"]);
            Assert.IsNotNull(schema.Fields["field1"].Cast<StructField>().Fields["fieldB"]);
            Assert.AreEqual(6, schema.Fields.Count);
            Assert.AreEqual(10, schema.Fields.SelectMany().Count);
        }

        [Test]
        public void Verify_can_set_by_schema_builder()
        {
            var fields = new FieldList(false);

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