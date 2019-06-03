namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class FieldCastTests
    {
        [Test]
        public void Test()
        {
            DecimalFieldSpec spec = Field.Builder<DecimalFieldSpecBuilder>()
                .Id("field1")
                .Precision(2)
                .Scale(4)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec)
                .Build();

            Assert.AreEqual(2, schema.Fields[0].Cast<DecimalFieldSpec>().Precision);
            Assert.AreEqual(4, schema.Fields[0].Cast<DecimalFieldSpec>().Scale);
        }

        [Test]
        public void Verify_()
        {
            FieldSpec specification = null;
            FieldSpec field1 = specification.Cast<FieldSpec>();

            Assert.IsNotNull(field1);
            Assert.AreEqual(FieldDataType.Primitive, field1.DataType);
        }
    }
}