namespace Butter.Tests
{
    using Data.Model;
    using Data.Model.Descriptors;
    using NUnit.Framework;

    [TestFixture]
    public class FieldCreationTests
    {
        [Test]
        public void Verify_type_field_being_created()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field = descriptor.Define(x =>
            {
                x.Id("city");
            });

            Assert.AreEqual("city", field.Id);
            Assert.AreEqual(FieldType.Primitive, field.Type);
        }
    }
}