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
            Field field = DataField.Create<int>("city");
            
            Assert.AreEqual("city", field.Name);
            Assert.AreEqual(DataType.INT32, field.Value.DataType);
        }
        
        [Test]
        public void Verify_byte_array_field_being_created()
        {
            Field field = DataField.Create<byte[]>("city");
            
            Assert.AreEqual("city", field.Name);
            Assert.AreEqual(DataType.BYTE_ARRAY, field.Value.DataType);
        }
        
        [Test]
        public void Verify_type_field_being_created()
        {
            Field field = DataField.Create("city", DataType.INT64);

            Assert.AreEqual("city", field.Name);
            Assert.AreEqual(DataType.INT64, field.Value.DataType);
            Assert.AreEqual(typeof(long), field.Value.ClrType);
        }
    }
}