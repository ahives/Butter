namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class SelectManyTests
    {
        [Test]
        public void Verify_can_access_struct_fields_by_id()
        {
            var fields = new FieldList();
            
            var field1 = Field.Builder<Struct>()
                .Id("field1")
                .IsNullable()
                .Field<Primitive>(x => x.Id("fieldA").DataType(SchemaDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(x => x.Id("fieldB").DataType(SchemaDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(x => x.Id("fieldC").DataType(SchemaDataType.Primitive).IsNullable().Build())
                .Field<Decimal>(x => x.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                .Build();
            
            fields.Add(field1);

            var field2 = Field.Builder<Primitive>()
                .Id("field2")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);

            var field3 = Field.Builder<Primitive>()
                .Id("field3")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);

            var field4 = Field.Builder<Primitive>()
                .Id("field4")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field4);

            var field5 = Field.Builder<Primitive>()
                .Id("field5")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field5);

            var field6 = Field.Builder<Primitive>()
                .Id("field6")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field6);

            Assert.IsNotNull(fields["field1"]);
            Assert.IsNotNull(fields["field1"].Cast<StructField>().Fields["fieldB"]);
            Assert.AreEqual(6, fields.Count);
            Assert.AreEqual(10, fields.SelectMany().Count);
        }

    }
}