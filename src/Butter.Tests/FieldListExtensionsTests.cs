namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class FieldListExtensionsTests
    {
        [Test]
        public void Test()
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

            int count = 0;
            foreach (var field in schema.Fields.ToEnumerable())
            {
                count++;
            }

            Assert.AreEqual(6, count);
        }
    }
}