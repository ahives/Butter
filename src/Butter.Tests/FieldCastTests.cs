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
            DecimalField spec = FieldSpec.Builder<DecimalFieldBuilder>()
                .Id("field1")
                .Precision(2)
                .Scale(4)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec)
                .Build();

            Assert.AreEqual(2, schema.Fields[0].Cast<DecimalField>().Precision);
            Assert.AreEqual(4, schema.Fields[0].Cast<DecimalField>().Scale);
        }

        [Test]
        public void Verify_()
        {
            Field specification = null;
            Field field1 = specification.Cast<Field>();

            Assert.IsNotNull(field1);
            Assert.AreEqual(FieldDataType.Primitive, field1.DataType);
        }
    }
}