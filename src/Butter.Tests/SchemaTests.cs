namespace Butter.Tests
{
    using Builders;
    using Data;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Test()
        {
            var builder = SchemaFactory.Factory.Get<FieldCreator>();
            var field1 = builder.Create(x => x.Id("field1"));
            var field2 = builder.Create(x => x.Id("field2"));
            var field3 = builder.Create(x => x.Id("field3"));
            var field4 = builder.Create(x => x.Id("field4"));
            var field5 = builder.Create(x => x.Id("field5"));
            
            Schema schema = new Schema(field1, field2, field3, field4, field5);
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
    }
}