namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ReadOnlyListIndexerTests
    {
        [Test]
        public void Verify_can_return_field()
        {
            PrimitiveField spec1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec4 = Field.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec5 = Field.Builder<FieldBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            DecimalField spec6 = Field.Builder<DecimalFieldBuilder>()
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
            PrimitiveField spec1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec4 = Field.Builder<FieldBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            PrimitiveField spec5 = Field.Builder<FieldBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            DecimalField spec6 = Field.Builder<DecimalFieldBuilder>()
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