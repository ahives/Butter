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
            var field1 = Descriptor.Factory.Get<FieldDescriptor>().Define(x => x.Id("field1"));
            var field2 = Descriptor.Factory.Get<FieldDescriptor>().Define(x => x.Id("field2"));
            var field3 = Descriptor.Factory.Get<FieldDescriptor>().Define(x => x.Id("field3"));
            var field4 = Descriptor.Factory.Get<FieldDescriptor>().Define(x => x.Id("field4"));
            var field5 = Descriptor.Factory.Get<FieldDescriptor>().Define(x => x.Id("field5"));
            
            ISchema schema = new Schema(field1, field2, field3, field4, field5);

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
        
        [Test]
        public void Test2()
        {
            var field1 = Descriptor.Factory.Get<FieldDescriptor>().Define(x => x.Id("field1"));
            var field2 = Descriptor.Factory.Get<ListFieldDescriptor>().Define(x => x.Id("field2"));
            var field3 = Descriptor.Factory.Get<MapFieldDescriptor>().Define(x => x.Id("field3"));
            var field4 = Descriptor.Factory.Get<FieldDescriptor>().Define(x => x.Id("field4"));
            var field5 = Descriptor.Factory.Get<ListFieldDescriptor>().Define(x => x.Id("field5"));
            
            ISchema schema = new Schema(field1, field2, field3, field4, field5);

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
    }
}