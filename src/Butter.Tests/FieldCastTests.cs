namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class FieldCastTests
    {
        [Test]
        public void Test()
        {
            DecimalField field = FieldSpec.Builder<DecimalFieldBuilder>()
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
            Field specification = null;
            Field field1 = specification.Cast<Field>();

            Assert.IsNotNull(field1);
            Assert.AreEqual(FieldDataType.Primitive, field1.DataType);
        }
    }
}