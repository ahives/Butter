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
                x.Type(FieldType.Primitive);
            });

            Field field2 = creator.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

            Assert.IsTrue(field1.EqualTo(field2));
        }
        
        [Test]
        public void Verify_EqualsTo_returns_false_when_types_different()
        {
            var creator = Schema.Factory.Get<FieldDescriptor>();
            Field field1 = creator.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.Primitive);
            });

            Field field2 = creator.Create(x =>
            {
                x.Id("city");
                x.Type(FieldType.List);
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
                    x.Type(FieldType.Primitive);
                });

            Field field2 = creator.Create(x =>
            {
                x.Id("state");
                x.Type(FieldType.Primitive);
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
            
            Assert.IsTrue(field1.EqualTo(field2));
        }
    }
}