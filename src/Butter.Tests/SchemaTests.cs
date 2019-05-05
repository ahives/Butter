namespace Butter.Tests
{
    using Data.Model;
    using Data.Model.Descriptors;
    using NUnit.Framework;

    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Verify_can_add_fields_at_construction()
        {
            var descriptor = Schema.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Create(x => x.Id("field1"));
            var field2 = descriptor.Create(x => x.Id("field2"));
            var field3 = descriptor.Create(x => x.Id("field3"));
            var field4 = descriptor.Create(x => x.Id("field4"));
            var field5 = descriptor.Create(x => x.Id("field5"));
            
            IDataSetSchema dataSetSchema = new DataSetSchema(field1, field2, field3, field4, field5);

            Assert.IsTrue(dataSetSchema.Fields.HasValues);
            Assert.AreEqual(5, dataSetSchema.Fields.Count);
        }
        
        [Test]
        public void Verify_can_add_fields_after_construction()
        {
            var descriptor = Schema.Factory.Get<FieldDescriptor>();
            
            IDataSetSchema dataSetSchema = new DataSetSchema();
            dataSetSchema.Fields.Add(descriptor.Create(x => x.Id("field1")));
            dataSetSchema.Fields.Add(descriptor.Create(x => x.Id("field2")));
            dataSetSchema.Fields.Add(descriptor.Create(x => x.Id("field3")));
            dataSetSchema.Fields.Add(descriptor.Create(x => x.Id("field4")));
            dataSetSchema.Fields.Add(descriptor.Create(x => x.Id("field5")));

            Assert.IsTrue(dataSetSchema.Fields.HasValues);
            Assert.AreEqual(5, dataSetSchema.Fields.Count);
        }
    }
}