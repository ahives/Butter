namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class DecimalFieldTests
    {
        [Test]
        public void Test()
        {
            DecimalField spec = FieldSpec.Builder<DecimalFieldBuilder>()
                .Id("field")
                .IsNullable()
                .Precision(2)
                .Scale(4)
                .Build();

            var schema = Schema.Builder()
                .Field(spec)
//                .Field("field1", x =>
//                {
//                    x.SetPrecision(2);
//                    x.SetScale(4);
//                }, true)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(2, schema.Fields[0].Cast<DecimalField>().Precision);
            Assert.AreEqual(4, schema.Fields[0].Cast<DecimalField>().Scale);
        }
    }
}