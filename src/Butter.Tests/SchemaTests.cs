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
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define(x => x.Id("field1"));
            var field2 = descriptor.Define(x => x.Id("field2"));
            var field3 = descriptor.Define(x => x.Id("field3"));
            var field4 = descriptor.Define(x => x.Id("field4"));
            var field5 = descriptor.Define(x => x.Id("field5"));
            
            ISchema schema = new Schema(field1, field2, field3, field4, field5);

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
        
        [Test]
        public void Verify_can_add_fields_after_construction()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            
            ISchema schema = new Schema();
            schema.Fields.Add(descriptor.Define(x => x.Id("field1")));
            schema.Fields.Add(descriptor.Define(x => x.Id("field2")));
            schema.Fields.Add(descriptor.Define(x => x.Id("field3")));
            schema.Fields.Add(descriptor.Define(x => x.Id("field4")));
            schema.Fields.Add(descriptor.Define(x => x.Id("field5")));

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
    }
}