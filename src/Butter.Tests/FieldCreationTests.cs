namespace Butter.Tests
{
    using Metadata;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldCreationTests
    {
        [Test]
        public void Verify_field_being_created()
        {
            Field<int> field = Field.Create<int>("city");
            
            Assert.AreEqual("city", field.Name);
            Assert.AreEqual(DataType.INT32, field.DataType);
        }
        
        [Test]
        public void Verify_byte_array_field_being_created()
        {
            Field<byte[]> field = Field.Create<byte[]>("city");
            
            Assert.AreEqual("city", field.Name);
            Assert.AreEqual(DataType.BYTE_ARRAY, field.DataType);
        }
    }
}