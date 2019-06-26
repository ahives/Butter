namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ReadOnlyListIndexerTests
    {
        [Test]
        public void Verify_can_return_field()
        {
            PrimitiveField spec1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec2 = Field.Builder<Primitive>()
                .Id("field2")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec3 = Field.Builder<Primitive>()
                .Id("field3")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec4 = Field.Builder<Primitive>()
                .Id("field4")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec5 = Field.Builder<Primitive>()
                .Id("field5")
                .DataType(SchemaDataType.Primitive)
                .Build();
            
            DecimalField spec6 = Field.Builder<Decimal>()
                .Id("field6")
                .Precision(2)
                .Scale(4)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Build();
            
            Assert.IsNotNull(schema.Fields["field6"]);
        }
        
        [Test]
        public void Verify_does_not_throw_when_cannot_return_field()
        {
            PrimitiveField spec1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec2 = Field.Builder<Primitive>()
                .Id("field2")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec3 = Field.Builder<Primitive>()
                .Id("field3")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec4 = Field.Builder<Primitive>()
                .Id("field4")
                .DataType(SchemaDataType.Primitive)
                .Build();

            PrimitiveField spec5 = Field.Builder<Primitive>()
                .Id("field5")
                .DataType(SchemaDataType.Primitive)
                .Build();
            
            DecimalField spec6 = Field.Builder<Decimal>()
                .Id("field6")
                .Precision(2)
                .Scale(4)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Build();
            
            Assert.IsNotNull(schema.Fields["field7"]);
        }
    }
}