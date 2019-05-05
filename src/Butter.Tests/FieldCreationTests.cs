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
            var descriptor = Schema.Factory.Get<FieldDescriptor>();
            var field = descriptor.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

            Assert.AreEqual("city", field.Id);
            Assert.AreEqual(FieldType.Primitive, field.Type);
        }
    }
}