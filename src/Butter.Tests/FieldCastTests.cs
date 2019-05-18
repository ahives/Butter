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
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Decimal, x =>
                {
                    x.SetPrecision(2);
                    x.SetScale(4);
                })
                .Build();

            Assert.AreEqual(2, schema.Fields[0].Cast<DecimalField>().Precision);
            Assert.AreEqual(4, schema.Fields[0].Cast<DecimalField>().Scale);
        }

        [Test]
        public void Verify_()
        {
            Field field = null;
            Field field1 = field.Cast<Field>();

            Assert.IsNotNull(field1);
            Assert.AreEqual(FieldDataType.None, field1.DataType);
        }
    }
}