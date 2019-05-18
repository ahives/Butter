namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListExtensionsTests
    {
        [Test]
        public void Test()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Map)
                .Field("field3", FieldDataType.List)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field6", FieldDataType.Decimal, x =>
                {
                    x.SetPrecision(2);
                    x.SetScale(4);
                })
                .Build();

            var fields = schema.Fields.ToEnumerable();
            Assert.AreEqual(6, fields);
        }
    }
}