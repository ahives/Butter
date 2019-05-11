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
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field2");
            var field3 = descriptor.Define("field3");
            var field4 = descriptor.Define("field4");
            var field5 = descriptor.Define("field5");
            
            ISchema schema = new Schema(field1, field2, field3, field4, field5);

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }
        
        [Test]
        public void Verify_can_add_fields_after_construction()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            
            ISchema schema = new Schema();
//            schema.Fields.Add<SomeCriteria>("field1", new SomeCriteriaImpl());
            schema.Fields.Add(descriptor.Define("field1"));
            schema.Fields.Add(descriptor.Define("field2"));
            schema.Fields.Add(descriptor.Define("field3"));
            schema.Fields.Add(descriptor.Define("field4"));
            schema.Fields.Add(descriptor.Define("field5"));

            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }

        public class SomeCriteriaImpl : SomeCriteria
        {
            public string Criteria1 { get; }
        }

        interface SomeCriteria
        {
            string Criteria1 { get; }
        }

        interface SomeOtherCriteria
        {
            string Criteria2 { get; }
        }
    }
}