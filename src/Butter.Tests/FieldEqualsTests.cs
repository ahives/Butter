namespace Butter.Tests
{
    using Data.Model.Descriptors;
    using NUnit.Framework;

    [TestFixture]
    public class FieldEqualsTests
    {
        [Test]
        public void Verify_return_false_when_field_identifiers_different()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field2");

            Assert.IsFalse(field1.Equals(field2));
        }
        
        [Test]
        public void Verify_return_false_when_field_identifiers_same_but_field_type_different()
        {
            var fieldDescriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = fieldDescriptor.Define("field1");
            
            var listFieldDescriptor = Descriptor.Factory.Get<ListFieldDescriptor>();
            var field2 = listFieldDescriptor.Define("field1");

            Assert.IsFalse(field1.Equals(field2));
        }
        
        [Test]
        public void Verify_return_true_when_field_identifiers_different()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field1");

            Assert.IsTrue(field1.Equals(field2));
        }
    }
}