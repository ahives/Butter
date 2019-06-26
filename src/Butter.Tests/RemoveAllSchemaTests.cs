namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class RemoveAllSchemaTests
    {
        [Test]
        public void Verify_can_remove_multiple_fields_with_same_id()
        {
            var schema = Schema.Builder()
                .Field<Struct>(x =>
                {
                    return x.Id("field1")
                        .Field<Primitive>(f => f.Id("fieldA").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldB").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldC").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<Primitive>(x => x.Id("field3").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field4").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field5").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field3").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field3").IsNullable().Build())
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            IReadOnlyFieldList fields = schema.RemoveAll<PrimitiveField>(x => x.Id == "field3");

            Assert.AreEqual(3, fields.Count);
        }
        
        [Test]
        public void Verify_can_remove_first_field_given_id()
        {
            var schema = Schema.Builder()
                .Field<Struct>(x =>
                {
                    return x.Id("field1")
                        .Field<Primitive>(f => f.Id("fieldA").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldB").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldC").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<Primitive>(x => x.Id("field2").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field3").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field4").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field5").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field6").IsNullable().Build())
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            IReadOnlyFieldList fields = schema.RemoveAll<PrimitiveField>(x => x.Id == "field1");

            Assert.AreEqual(1, fields.Count);
        }
        
        [Test]
        public void Verify_can_remove_lasst_field_given_id()
        {
            var schema = Schema.Builder()
                .Field<Struct>(x =>
                {
                    return x.Id("field1")
                        .Field<Primitive>(f => f.Id("fieldA").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldB").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldC").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<Primitive>(x => x.Id("field2").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field3").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field4").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field5").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field6").IsNullable().Build())
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            IReadOnlyFieldList fields = schema.RemoveAll<PrimitiveField>(x => x.Id == "field6");

            Assert.AreEqual(1, fields.Count);
        }
        
        [Test]
        public void Verify_does_not_throw_when_id_missing()
        {
            var schema = Schema.Builder()
                .Field<Struct>(x =>
                {
                    return x.Id("field1")
                        .Field<Primitive>(f => f.Id("fieldA").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldB").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldC").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<Primitive>(x => x.Id("field2").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field3").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field4").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field5").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field6").IsNullable().Build())
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            IReadOnlyFieldList fields = schema.RemoveAll<PrimitiveField>(x => x.Id == "field7");

            Assert.AreEqual(0, fields.Count);
        }
    }
}