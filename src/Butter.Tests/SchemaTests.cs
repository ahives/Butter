namespace Butter.Tests
{
    using Creators;
    using Data;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Test()
        {
            var creator = SchemaFactory.Factory.Get<FieldCreator>();
            var field1 = creator.Create(x => x.Id("field1"));
            var field2 = creator.Create(x => x.Id("field2"));
            var field3 = creator.Create(x => x.Id("field3"));
            var field4 = creator.Create(x => x.Id("field4"));
            var field5 = creator.Create(x => x.Id("field5"));
            
            Schema schema = new Schema(field1, field2, field3, field4, field5);
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
    }
}