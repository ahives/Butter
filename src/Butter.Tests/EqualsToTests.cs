namespace Butter.Tests
{
    using Builders;
    using Entities.Model;
    using NUnit.Framework;

    [TestFixture]
    public class EqualsToTests
    {
        [Test]
        public void Verify_EqualsTo_returns_true()
        {
            var builder = SchemaFactory.Instance.GetBuilder<FieldBuilder>();
            Field field1 = builder.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

            Field field2 = builder.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

            Assert.IsTrue(field1.EqualTo(field2));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false()
        {
            var builder = SchemaFactory.Instance.GetBuilder<FieldBuilder>();
            Field field1 = builder.Create(x =>
                {
                    x.Id("city");
                    x.Type(FieldType.Primitive);
                });

            Field field2 = builder.Create(x =>
            {
                x.Id("state");
                x.Type(FieldType.Primitive);
            });

            Assert.IsFalse(field1.EqualTo(field2));
        }
    }
}