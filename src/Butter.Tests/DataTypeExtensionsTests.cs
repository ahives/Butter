namespace Butter.Tests
{
    using Metadata;
    using NUnit.Framework;

    [TestFixture]
    public class DataTypeExtensionsTests
    {
        [Test]
        public void Verify_can_convert_to_int_data_type()
        {
            Assert.AreEqual(DataType.INT32, typeof(int).Convert());
        }

        [Test]
        public void Verify_can_convert_to_long_data_type()
        {
            Assert.AreEqual(DataType.INT64, typeof(long).Convert());
        }

        [Test]
        public void Verify_can_convert_to_float_data_type()
        {
            Assert.AreEqual(DataType.FLOAT, typeof(float).Convert());
        }

        [Test]
        public void Verify_can_convert_to_double_data_type()
        {
            Assert.AreEqual(DataType.DOUBLE, typeof(double).Convert());
        }

        [Test]
        public void Verify_can_convert_to_byte_array_data_type()
        {
            Assert.AreEqual(DataType.BYTE_ARRAY, typeof(byte[]).Convert());
        }

        [Test]
        public void Verify_can_convert_to_boolean_data_type()
        {
            Assert.AreEqual(DataType.BOOLEAN, typeof(bool).Convert());
        }
    }
}