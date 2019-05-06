namespace Butter.Tests
{
    using Data;
    using Data.Model;
    using Data.Model.Descriptors;
    using Exceptions;
    using NUnit.Framework;

    [TestFixture]
    public class EqualsToTests
    {
        [Test]
        public void Verify_EqualsTo_returns_true()
        {
            var creator = Schema.Factory.Get<FieldDescriptor>();
            Field field1 = creator.Create(x =>
            {
                x.Id("city");
            });

            Field field2 = creator.Create(x =>
            {
                x.Id("city");
            });

            Assert.IsTrue(field1.EqualTo(field2));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false_when_types_different()
        {
            var fieldDescriptor = Schema.Factory.Get<FieldDescriptor>();
            Field field1 = fieldDescriptor.Create(x =>
            {
                x.Id("city");
            });

            var listFieldDescriptor = Schema.Factory.Get<ListFieldDescriptor>();
            ListField field2 = listFieldDescriptor.Create(x =>
            {
                x.Id("city");
            });

            Assert.IsFalse(field1.EqualTo(field2));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false()
        {
            var creator = Schema.Factory.Get<FieldDescriptor>();
            Field field1 = creator.Create(x =>
                {
                    x.Id("city");
                });

            Field field2 = creator.Create(x =>
            {
                x.Id("state");
            });

            Assert.IsFalse(field1.EqualTo(field2));
        }

        [Test]
        public void Verify_throws_when_empty_field_accessed()
        {
            IFieldList fields = new FieldList();
            fields.Add(null);
            
            Assert.IsFalse(fields.TryGetValue(0, out var f1));
            Assert.Throws<FieldOutOfRangeException>(() =>
            {
                string fieldId = f1.Id;
            });
        }

        [Test]
        public void Verify_null_objects_are_equal()
        {
            Field field1 = null;
            Field field2 = null;
            
            Assert.IsFalse(field1.EqualTo(field2));
        }
    }
}