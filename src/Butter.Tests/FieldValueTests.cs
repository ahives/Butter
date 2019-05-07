namespace Butter.Tests
{
    using Data.Model;
    using Data.Model.Descriptors;
    using NUnit.Framework;

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
            var builder = Descriptor.Factory.Get<FieldDescriptor>();
            var field = builder.Define(x =>
            {
                x.Id("city");
            });

//            Schema.Field.Add(field);

//            Field field = DataField.Create<int>("city");

//            Assert.IsFalse(field.HasValue);
        }
    }
}