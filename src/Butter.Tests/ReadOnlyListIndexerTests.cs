namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class ReadOnlyListIndexerTests
    {
        [Test]
        public void Verify_can_return_field()
        {
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            DecimalFieldSpec spec6 = Field.Builder<DecimalFieldSpecBuilder>()
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
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            DecimalFieldSpec spec6 = Field.Builder<DecimalFieldSpecBuilder>()
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