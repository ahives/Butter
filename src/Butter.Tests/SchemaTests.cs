namespace Butter.Tests
{
    using System;
    using Builders;
    using NUnit.Framework;
    using Specification;
    using Decimal = Builders.Decimal;

    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Verify_can_add_fields_after_construction()
        {
            PrimitiveField field1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField field2 = Field.Builder<Primitive>()
                .Id("field2")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField field3 = Field.Builder<Primitive>()
                .Id("field3")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField field4 = Field.Builder<Primitive>()
                .Id("field4")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField field5 = Field.Builder<Primitive>()
                .Id("field5")
                .DataType(SchemaDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(field1)
                .Field(field2)
                .Field(field3)
                .Field(field4)
                .Field(field5)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
        
        [Test]
        public void Verify_can_remove_first_field_matching_criteria()
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

            PrimitiveField field = schema.Remove<PrimitiveField>(x => x.Id == "field3");
            
            Assert.AreEqual(5, schema.Fields.Count);
        }
        
        [Test]
        public void Verify_can_output_schema()
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
            
            Console.WriteLine(schema.Fields.ToString());
        }
        
        [Test]
        public void Verify_can_remove_first_field_matching_criteria2()
        {
            var schema = Schema.Builder()
                .Field<Primitive>(x => x.Id("field1").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field2").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field1").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field4").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field1").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field6").IsNullable().Build())
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            IReadOnlyFieldList fields = schema.RemoveAll<PrimitiveField>(x => x.Id == "field1");
            
            Assert.AreEqual(3, schema.Fields.Count);
            Assert.AreEqual(3, fields.Count);
        }
        
        [Test]
        public void Verify_can_define_struct_field_within_method_chain()
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
                .Field<Primitive>(x => x.Id("field6").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field7").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field8").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field9").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field10").IsNullable().Build())
                .Build();

            Assert.IsNotNull(schema.Fields["field1"]);
            Assert.IsNotNull(schema.Fields["field1"].Cast<StructField>().Fields["fieldB"]);
            Assert.AreEqual(6, schema.Fields.Count);
            Assert.AreEqual(10, schema.Fields.SelectMany().Count);
        }

        [Test]
        public void Verify_can_access_struct_fields_by_id()
        {
            var field = Field.Builder<Struct>()
                .Id("field1")
                .IsNullable()
                .Field<Primitive>(x => x.Id("fieldA").DataType(SchemaDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(x => x.Id("fieldB").DataType(SchemaDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(x => x.Id("fieldC").DataType(SchemaDataType.Primitive).IsNullable().Build())
                .Field<Decimal>(x => x.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                .Build();

            var schema = Schema.Builder()
                .Field(field)
                .Field<Primitive>(x => x.Id("field6").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field7").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field8").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field9").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field10").IsNullable().Build())
                .Build();

            Assert.IsNotNull(schema.Fields["field1"]);
            Assert.IsNotNull(schema.Fields["field1"].Cast<StructField>().Fields["fieldB"]);
            Assert.AreEqual(6, schema.Fields.Count);
        }

        [Test, Explicit]
        public void Test()
        {
            var schema = Schema.Builder()
                .Field<Struct>(x =>
                {
                    return x.Id("field3")
                        .Index(3)
                        .Field<Primitive>(f => f.Id("fieldA").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldB").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldC").DataType(SchemaDataType.Primitive).IsNullable().Build())
                        .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<Primitive>(x => x.Id("field2").Index(2).IsNullable().Build())
                .Field<Primitive>(x => x.Id("field1").Index(1).IsNullable().Build())
                .Field<Primitive>(x => x.Id("field5").Index(5).IsNullable().Build())
                .Field<Primitive>(x => x.Id("field4").Index(4).IsNullable().Build())
                .Field<Primitive>(x => x.Id("field6").Index(6).IsNullable().Build())
                .Build();

            Console.WriteLine(schema.Report());
        }
    }
}