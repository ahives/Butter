namespace Butter.Tests
{
    using System;
    using Data;
    using Data.Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListTests
    {
        [Test]
        public void Verify_can_access_list_using_indexer()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive)
                .Field("field2", FieldType.Primitive)
                .Field("field3", FieldType.Primitive)
                .Field("field4", FieldType.Primitive)
                .Field("field5", FieldType.Primitive)
                .Field("field3", FieldType.Primitive)
                .Build();
            
            Assert.IsNotNull(schema.Fields[0]);
            Assert.AreEqual("field1", schema.Fields[0].Id);
            
            Assert.IsNotNull(schema.Fields[1]);
            Assert.AreEqual("field2", schema.Fields[1].Id);
            
            Assert.IsNotNull(schema.Fields[2]);
            Assert.AreEqual("field3", schema.Fields[2].Id);
            
            Assert.IsNotNull(schema.Fields[3]);
            Assert.AreEqual("field4", schema.Fields[3].Id);
            
            Assert.IsNotNull(schema.Fields[4]);
            Assert.AreEqual("field5", schema.Fields[4].Id);
        }

        [Test]
        public void Verify_cannot_add_fields_with_same_identifier()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive)
                .Field("field2", FieldType.Primitive)
                .Field("field3", FieldType.Primitive)
                .Field("field4", FieldType.Primitive)
                .Field("field5", FieldType.Primitive)
                .Field("field3", FieldType.Primitive)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }

        [Test]
        public void Verify_cannot_add_list_range_of_fields_with_same_identifier()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive)
                .Field("field2", FieldType.Primitive)
                .Field("field3", FieldType.Primitive)
                .Field("field4", FieldType.Primitive)
                .Field("field5", FieldType.Primitive)
                .Field("field3", FieldType.Primitive)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(5, schema.Fields.Count);
        }

        [Test]
        public void Verify_can_access_list_with_multiple_field_types()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive)
                .Field("field2", FieldType.Map)
                .Field("field3", FieldType.List)
                .Field("field4", FieldType.Primitive)
                .Field("field5", FieldType.Primitive)
                .Field("field6", FieldType.Decimal, x =>
                {
                    x.SetPrecision(2);
                    x.SetScale(4);
                })
                .Build();

            for (int i = 0; i < schema.Fields.Count; i++)
            {
                switch (schema.Fields[i].Type)
                {
                    case FieldType.None:
                        break;
                    case FieldType.Primitive:
                        Field field = schema.Fields[i];
                        Assert.IsNotNull(field);
                        Assert.That(field.Id, Is.EqualTo("field1").Or.EqualTo("field4").Or.EqualTo("field5"));
                        break;
                    case FieldType.Map:
//                        MapField mapField = schema.Fields[i].Cast<MapField>();
//                        Assert.IsNotNull(mapField);
//                        Assert.AreEqual("field2", mapField.Id);
                        break;
                    case FieldType.List:
//                        ListField listField = schema.Fields[i].Cast<ListField>();
//                        Assert.IsNotNull(listField);
//                        Assert.AreEqual("field3", listField.Id);
                        break;
                    case FieldType.Decimal:
                        DecimalField decimalField = schema.Fields[i].Cast<DecimalField>();
                        Assert.IsNotNull(decimalField);
                        Assert.AreEqual("field6", decimalField.Id);
                        break;
                    case FieldType.Structure:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_empty_list()
        {
            IFieldList fields = new FieldList();
            
            Assert.IsFalse(fields.TryGetValue(0, out _));
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_negative_index()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive)
                .Build();
            
            Assert.IsFalse(schema.Fields.TryGetValue(-1, out _));
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_greater_than_count_index()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldType.Primitive)
                .Build();
            
            Assert.IsFalse(schema.Fields.TryGetValue(schema.Fields.Count + 1, out _));
        }

        [Test]
        public void Verify_can_create_list_of_fields_with_list3()
        {
            IFieldList fields = new FieldList();
            
            Assert.IsFalse(fields.TryGetValue(0, out var f1));
            Assert.Throws<FieldOutOfRangeException>(() =>
            {
                Assert.AreEqual("field1", f1.Id);
            });
        }

        [Test]
        public void Verify_TryGetValue_does_not_throw_when_empty()
        {
            IFieldList fields = new FieldList();
            
            Assert.IsFalse(fields.TryGetValue(0, out _));
        }
    }
}