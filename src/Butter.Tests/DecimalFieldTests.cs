namespace Butter.Tests
{
    using Data;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class DecimalFieldTests
    {
        [Test]
        public void Test()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive, x =>
                {
                    x.SetPrecision(2);
                    x.SetScale(4);
                }, true)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(2, schema.Fields[0].Cast<DecimalField>().Precision);
            Assert.AreEqual(4, schema.Fields[0].Cast<DecimalField>().Scale);
        }
    }
}