namespace Butter.Tests
{
    using Creators;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldCreationTests
    {
        [Test]
        public void Verify_type_field_being_created()
        {
            var creator = SchemaFactory.Factory.Get<FieldCreator>();
            var field = creator.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

            Assert.AreEqual("city", field.Id);
            Assert.AreEqual(FieldType.Primitive, field.Type);
        }
    }
}