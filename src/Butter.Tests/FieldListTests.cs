namespace Butter.Tests
{
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListTests
    {
        [Test]
        public void Test()
        {
            var fields = FieldList.Create(
                Field.Create<int>("field1"),
                Field.Create<int>("field2"),
                Field.Create<int>("field3"),
                Field.Create<int>("field4"),
                Field.Create<int>("field5"));
            
            Assert.IsTrue(fields.TryGetValue(0, out var field1));
            Assert.AreEqual("field1", field1.Name);
            
            Assert.IsTrue(fields.TryGetValue(1, out var field2));
            Assert.AreEqual("field2", field2.Name);
            
            Assert.IsTrue(fields.TryGetValue(2, out var field3));
            Assert.AreEqual("field3", field3.Name);
            
            Assert.IsTrue(fields.TryGetValue(3, out var field4));
            Assert.AreEqual("field4", field4.Name);
            
            Assert.IsTrue(fields.TryGetValue(4, out var field5));
            Assert.AreEqual("field5", field5.Name);
        }

        [Test]
        public void Test2()
        {
            var fields = FieldList.Create<int>();
            
            Assert.IsFalse(fields.TryGetValue(0, out var _));
        }
    }
}