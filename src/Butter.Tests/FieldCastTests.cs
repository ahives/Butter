namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class FieldCastTests
    {
        [Test]
        public void Test()
        {
            DecimalField field = Field.Builder<Decimal>()
                .Id("field1")
                .Precision(2)
                .Scale(4)
                .Build();

            Assert.AreEqual(2, field.Cast<DecimalField>().Precision);
            Assert.AreEqual(4, field.Cast<DecimalField>().Scale);
        }

        [Test]
        public void Verify_()
        {
            PrimitiveField specification = null;
            PrimitiveField field1 = specification.Cast<PrimitiveField>();

            Assert.IsNotNull(field1);
            Assert.AreEqual(SchemaDataType.Primitive, field1.DataType);
        }
    }
}