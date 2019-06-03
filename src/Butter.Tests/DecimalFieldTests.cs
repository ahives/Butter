namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class DecimalFieldTests
    {
        [Test]
        public void Test()
        {
            DecimalFieldSpec spec = Field.Builder<DecimalFieldSpecBuilder>()
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
            Assert.AreEqual(2, schema.Fields[0].Cast<DecimalFieldSpec>().Precision);
            Assert.AreEqual(4, schema.Fields[0].Cast<DecimalFieldSpec>().Scale);
        }
    }
}