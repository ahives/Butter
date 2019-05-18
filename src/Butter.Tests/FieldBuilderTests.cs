namespace Butter.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class FieldBuilderTests
    {
        [Test]
        public void Test()
        {
            var field = Schema.Field.Builder<DecimalFieldBuilder>()
                .Identifier("field1")
                .Precision(2)
                .Build();

            Assert.AreEqual("field1", field.Id);
        }
    }
}