namespace Butter.Tests
{
    using System;
    using Metadata;
    using Model;
    using NUnit.Framework;
    using Serialization.Json;

    [TestFixture]
    public class FieldCreationTests
    {
        [Test]
        public void Verify_field_being_created()
        {
//            Field field = DataField.Create<int>("city");
//            
//            Assert.AreEqual("city", field.Name);
//            Assert.AreEqual(DataType.INT32, field.Value.DataType);
        }
        
        [Test]
        public void Verify_byte_array_field_being_created()
        {
//            Field field = DataField.Create<byte[]>("city");
//            
//            Assert.AreEqual("city", field.Name);
//            Assert.AreEqual(DataType.BYTE_ARRAY, field.Value.DataType);
        }
        
        [Test]
        public void Verify_type_field_being_created()
        {
            var builder = SchemaFactory.Instance.GetBuilder<FieldBuilder>();
            var field = builder.Create(x =>
            {
                x.Name("city");
                x.FieldType(FieldType.Primitive);
            });
//            Field field = DataField.Create(x =>
//            {
//                x.Name("city"); 
//                x.Type(FieldType.Primitive);
//            });

            Assert.AreEqual("city", field.Name);
            Assert.AreEqual(FieldType.Primitive, field.FieldType);
//            Assert.AreEqual(typeof(long), field.ClrType);
        }
    }
}