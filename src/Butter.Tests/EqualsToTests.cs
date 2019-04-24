namespace Butter.Tests
{
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class EqualsToTests
    {
        [Test]
        public void Verify_EqualsTo_returns_true()
        {
            Field<int> field1 = DataField.Create<int>("city");
            Field<int> field2 = DataField.Create<int>("city");
            
            Assert.IsTrue(field1.EqualTo(field2));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false()
        {
            Field<int> field1 = DataField.Create<int>("city");
            Field<int> field2 = DataField.Create<int>("state");
            
            Assert.IsFalse(field1.EqualTo(field2));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false2()
        {
            bool isEqual = DataField.Create<int>("city")
                .EqualTo(DataField.Create<int>("state"));
            
            Assert.IsFalse(isEqual);
        }
    }
}