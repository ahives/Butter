namespace Butter.Tests
{
    using Metadata;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class EqualsToTests
    {
        [Test]
        public void Verify_EqualsTo_returns_true()
        {
            bool isEqual = DataField.Create(x =>
                {
                    x.Name("city");
                    x.Type(FieldType.Primitive);
                })
                .EqualTo(DataField.Create(x =>
                {
                    x.Name("city");
                    x.Type(FieldType.Primitive);
                }));

            Assert.IsTrue(isEqual);
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false()
        {
            bool isEqual = DataField.Create(x =>
                {
                    x.Name("city");
                    x.Type(FieldType.Primitive);
                })
                .EqualTo(DataField.Create(x =>
                {
                    x.Name("state");
                    x.Type(FieldType.Primitive);
                }));

            Assert.IsFalse(isEqual);
        }
    }
}