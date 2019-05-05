namespace Butter.Tests
{
    using Data.Model;
    using Data.Model.Descriptors;
    using NUnit.Framework;

    [TestFixture]
    public class FactoryTests
    {
        [Test]
        public void Test()
        {
            var field1 = Schema.Factory.Get<FieldDescriptor>().Create(x => x.Id("field1"));
            var field2 = Schema.Factory.Get<FieldDescriptor>().Create(x => x.Id("field2"));
            var field3 = Schema.Factory.Get<FieldDescriptor>().Create(x => x.Id("field3"));
            var field4 = Schema.Factory.Get<FieldDescriptor>().Create(x => x.Id("field4"));
            var field5 = Schema.Factory.Get<FieldDescriptor>().Create(x => x.Id("field5"));
            
            IDataSetSchema dataSetSchema = new DataSetSchema(field1, field2, field3, field4, field5);

            Assert.IsTrue(dataSetSchema.Fields.HasValues);
            Assert.AreEqual(5, dataSetSchema.Fields.Count);
        }
    }
}