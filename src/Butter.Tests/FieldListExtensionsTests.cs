namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListExtensionsTests
    {
        [Test]
        public void Test()
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

            DecimalField spec6 = FieldSpec.Builder<DecimalFieldBuilder>()
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