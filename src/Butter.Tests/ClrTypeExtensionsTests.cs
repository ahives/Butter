namespace Butter.Tests
{
    using Metadata;
    using NUnit.Framework;

    [TestFixture]
    public class ClrTypeExtensionsTests
    {
        [Test]
        public void Verify_can_convert_to_int()
        {
            Assert.AreEqual(typeof(int), DataType.INT32.Convert());
        }
        
        [Test]
        public void Verify_can_convert_to_long()
        {
            Assert.AreEqual(typeof(long), DataType.INT64.Convert());
        }
        
        [Test]
        public void Verify_can_convert_to_boolean()
        {
            Assert.AreEqual(typeof(bool), DataType.BOOLEAN.Convert());
        }
        
        [Test]
        public void Verify_can_convert_to_byte_array()
        {
            Assert.AreEqual(typeof(byte[]), DataType.BYTE_ARRAY.Convert());
        }
        
        [Test]
        public void Verify_can_convert_to_float()
        {
            Assert.AreEqual(typeof(float), DataType.FLOAT.Convert());
        }
        
        [Test]
        public void Verify_can_convert_to_double()
        {
            Assert.AreEqual(typeof(double), DataType.DOUBLE.Convert());
        }
    }
}