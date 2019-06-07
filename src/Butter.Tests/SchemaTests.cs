namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Verify_can_add_fields_after_construction()
        {
            Field spec1 = FieldSpec.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec2 = FieldSpec.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec3 = FieldSpec.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec4 = FieldSpec.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            Field spec5 = FieldSpec.Builder<FieldBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
        
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
        }
    }
}