namespace Butter.Tests
{
    using System;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Verify_can_add_fields_after_construction()
        {
            SchemaField field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            SchemaField field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            SchemaField field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            SchemaField field4 = Field.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            SchemaField field5 = Field.Builder<FieldBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
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
                .Field<StructFieldBuilder>(x =>
                {
                    return x.Id("field1")
                        .Field<FieldBuilder>(f => f.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<DecimalFieldBuilder>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<FieldBuilder>(x => x.Id("field2").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field3").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field4").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field5").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field6").IsNullable().Build())
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            SchemaField field = schema.Remove<SchemaField>(x => x.Id == "field3");
            
            Assert.AreEqual(5, schema.Fields.Count);
        }
        
        [Test]
        public void Verify_can_output_schema()
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
                .Field<FieldBuilder>(x => x.Id("field2").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field3").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field4").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field5").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field6").IsNullable().Build())
                .Build();
            
            Console.WriteLine(schema.Fields.ToString());
        }
        
        [Test]
        public void Verify_can_remove_first_field_matching_criteria2()
        {
            var schema = Schema.Builder()
                .Field<FieldBuilder>(x => x.Id("field1").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field2").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field1").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field4").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field1").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field6").IsNullable().Build())
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            IReadOnlyFieldList fields = schema.RemoveAll<SchemaField>(x => x.Id == "field1");
            
            Assert.AreEqual(3, schema.Fields.Count);
            Assert.AreEqual(3, fields.Count);
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
            var field = Field.Builder<StructFieldBuilder>()
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

        [Test]
        public void Test()
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

            Console.WriteLine(schema.Report());
        }
    }
}