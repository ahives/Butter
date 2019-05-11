namespace Butter.Tests
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Data.Model;
    using Data.Model.Descriptors;
    using Exceptions;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListTests
    {
        [Test]
        public void Verify_can_create_list_of_fields_with_list()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field2");
            var field3 = descriptor.Define("field3");
            var field4 = descriptor.Define("field4");
            var field5 = descriptor.Define("field5");

            IFieldList fields = new FieldList();
            fields.Add(field1);
            fields.Add(field2);
            fields.Add(field3);
            fields.Add(field4);
            fields.Add(field5);
            
            Assert.IsTrue(fields.TryGetValue(0, out var f1));
            Assert.AreEqual("field1", f1.Id);
            
            Assert.IsTrue(fields.TryGetValue(1, out var f2));
            Assert.AreEqual("field2", f2.Id);
            
            Assert.IsTrue(fields.TryGetValue(2, out var f3));
            Assert.AreEqual("field3", f3.Id);
            
            Assert.IsTrue(fields.TryGetValue(3, out var f4));
            Assert.AreEqual("field4", f4.Id);
            
            Assert.IsTrue(fields.TryGetValue(4, out var f5));
            Assert.AreEqual("field5", f5.Id);
        }

        [Test]
        public void Verify_can_access_list_using_indexer()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field2");
            var field3 = descriptor.Define("field3");
            var field4 = descriptor.Define("field4");
            var field5 = descriptor.Define("field5");

            IFieldList fields = new FieldList();
            fields.Add(field1);
            fields.Add(field2);
            fields.Add(field3);
            fields.Add(field4);
            fields.Add(field5);
            
            Assert.IsNotNull(fields[0]);
            Assert.AreEqual("field1", fields[0].Id);
            
            Assert.IsNotNull(fields[1]);
            Assert.AreEqual("field2", fields[1].Id);
            
            Assert.IsNotNull(fields[2]);
            Assert.AreEqual("field3", fields[2].Id);
            
            Assert.IsNotNull(fields[3]);
            Assert.AreEqual("field4", fields[3].Id);
            
            Assert.IsNotNull(fields[4]);
            Assert.AreEqual("field5", fields[4].Id);
        }

        [Test]
        public void Verify_cannot_add_fields_with_same_identifier()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field2");
            var field3 = descriptor.Define("field3");
            var field4 = descriptor.Define("field4");
            var field5 = descriptor.Define("field5");
            var field6 = descriptor.Define("field3");

            IFieldList fields = new FieldList();
            fields.Add(field1);
            fields.Add(field2);
            fields.Add(field3);
            fields.Add(field4);
            fields.Add(field5);
            fields.Add(field6);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(5, fields.Count);
        }

        [Test]
        public void Verify_cannot_add_range_of_fields_with_same_identifier()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field2");
            var field3 = descriptor.Define("field3");
            var field4 = descriptor.Define("field4");
            var field5 = descriptor.Define("field5");
            var field6 = descriptor.Define("field3");

            IFieldList fields = new FieldList();
            fields.AddRange(field1, field2, field3, field4, field5, field6);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(5, fields.Count);
        }

        [Test]
        public void Verify_cannot_add_list_range_of_fields_with_same_identifier()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field1 = descriptor.Define("field1");
            var field2 = descriptor.Define("field2");
            var field3 = descriptor.Define("field3");
            var field4 = descriptor.Define("field4");
            var field5 = descriptor.Define("field5");
            var field6 = descriptor.Define("field3");

            List<Field> listOfFields = new List<Field>();
            listOfFields.Add(field1);
            listOfFields.Add(field2);
            listOfFields.Add(field3);
            listOfFields.Add(field4);
            listOfFields.Add(field5);
            listOfFields.Add(field6);
            
            IFieldList fields = new FieldList();
            fields.AddRange(listOfFields);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(5, fields.Count);
        }

        [Test]
        public void Verify_can_access_list_with_multiple_field_types()
        {
            var fieldDescriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var mapFieldDescriptor = Descriptor.Factory.Get<MapFieldDescriptor>();
            var listFieldDescriptor = Descriptor.Factory.Get<ListFieldDescriptor>();

            IFieldList fields = new FieldList();
            fields.Add(fieldDescriptor.Define("field1"));
            fields.Add(mapFieldDescriptor.Define("field2"));
            fields.Add(listFieldDescriptor.Define("field3"));
            fields.Add(fieldDescriptor.Define("field4"));
            fields.Add(fieldDescriptor.Define("field5"));

            for (int i = 0; i < fields.Count; i++)
            {
                switch (fields[i].Type)
                {
                    case FieldType.None:
                        break;
                    case FieldType.Primitive:
                        Field field = fields[i];
                        Assert.IsNotNull(field);
                        Assert.That(field.Id, Is.EqualTo("field1").Or.EqualTo("field4").Or.EqualTo("field5"));
                        break;
                    case FieldType.List:
                        ListField listField = (ListField) fields[i];
                        Assert.IsNotNull(listField);
                        Assert.AreEqual("field3", listField.Id);
                        break;
                    case FieldType.Map:
                        MapField mapField = (MapField) fields[i];
                        Assert.IsNotNull(mapField);
                        Assert.AreEqual("field2", mapField.Id);
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
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field = descriptor.Define("field1");

            IFieldList fields = new FieldList();
            fields.Add(field);
            
            Assert.IsFalse(fields.TryGetValue(-1, out _));
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_greater_than_count_index()
        {
            var descriptor = Descriptor.Factory.Get<FieldDescriptor>();
            var field = descriptor.Define("field1");

            IFieldList fields = new FieldList();
            fields.Add(field);
            
            Assert.IsFalse(fields.TryGetValue(fields.Count + 1, out _));
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