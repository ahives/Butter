namespace Butter.Tests
{
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldValueTests
    {
        [Test]
        public void Verify_can_check_value_exists()
        {
            Field field = DataField.Create<int>("city", "10");
            
            Assert.IsTrue(field.HasValue);
        }
        
        [Test]
        public void Verify_can_check_value_does_not_exist()
        {
            Field field = DataField.Create<int>("city");
            
            Assert.IsFalse(field.HasValue);
        }
    }
}