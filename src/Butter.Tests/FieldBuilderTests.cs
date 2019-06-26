namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;

    [TestFixture]
    public class FieldBuilderTests
    {
        [Test]
        public void Test()
        {
            var field = Field.Builder<Decimal>()
                .Id("field1")
                .Precision(2)
                .Build();

            Assert.AreEqual("field1", field.Id);
        }
    }
}