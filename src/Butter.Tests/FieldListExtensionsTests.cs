namespace Butter.Tests
{
    using Data;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListExtensionsTests
    {
        [Test]
        public void Test()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive)
                .Field("field2", FieldType.Map)
                .Field("field3", FieldType.List)
                .Field("field4", FieldType.Primitive)
                .Field("field5", FieldType.Primitive)
                .Field("field6", FieldType.Decimal, x =>
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