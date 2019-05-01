namespace Butter.Tests
{
    using Builders;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldCreationTests
    {
        [Test]
        public void Verify_type_field_being_created()
        {
            var builder = SchemaFactory.Instance.GetBuilder<FieldBuilder>();
            var field = builder.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

            Assert.AreEqual("city", field.Id);
            Assert.AreEqual(FieldType.Primitive, field.Type);
        }
    }
}