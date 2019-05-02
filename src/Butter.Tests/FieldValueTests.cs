namespace Butter.Tests
{
    using Builders;
    using Data.Model;
    using NUnit.Framework;
    using Schema;

    [TestFixture]
    public class FieldValueTests
    {
        [Test]
        public void Verify_can_check_value_exists()
        {
//            Field field = DataField.Create<int>("city", "10");
            
//            Assert.IsTrue(field.HasValue);
        }
        
        [Test]
        public void Verify_can_check_value_does_not_exist()
        {
            var builder = SchemaFactory.Factory.Get<FieldCreator>();
            var field = builder.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

//            Schema.Field.Add(field);

//            Field field = DataField.Create<int>("city");

//            Assert.IsFalse(field.HasValue);
        }
    }
}