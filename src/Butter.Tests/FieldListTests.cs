namespace Butter.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListTests
    {
        [Test]
        public void Verify_can_access_list_using_indexer()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
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
        public void Verify_TryGetValue_will_not_throw_when_index_less_than_zero()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Build();
            
            Assert.IsFalse(schema.Fields.TryGetValue(-1, out Field field));
            Assert.IsNotNull(field);
        }

        [Test]
        public void Verify_TryGetValue_will_not_throw_when_index_greater_than_count()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Build();

            int count = schema.Fields.Count;
            Assert.IsFalse(schema.Fields.TryGetValue(count + 1, out Field field));
            Assert.IsNotNull(field);
        }

        [Test]
        public void Verify_TryGetValue_will_return_field()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Build();

            Assert.IsTrue(schema.Fields.TryGetValue(3, out Field field));
            Assert.IsNotNull(field);
            Assert.AreEqual("field4", field.Id);
            Assert.AreEqual(FieldDataType.Primitive, field.DataType);
        }

        [Test]
        public void Verify_TryGetValue_will_return_field_given_identifier()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Build();

            Assert.IsTrue(schema.Fields.TryGetValue("field4", out Field field));
            Assert.IsNotNull(field);
            Assert.AreEqual("field4", field.Id);
            Assert.AreEqual(FieldDataType.Primitive, field.DataType);
        }

        [Test]
        public void Verify_can_access_list_with_multiple_field_types()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Map)
                .Field("field3", FieldDataType.List)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field6",x =>
                {
                    x.SetPrecision(2);
                    x.SetScale(4);
                })
                .Build();

            for (int i = 0; i < schema.Fields.Count; i++)
            {
                switch (schema.Fields[i].DataType)
                {
                    case FieldDataType.None:
                        break;
                    case FieldDataType.Primitive:
                        Field field = schema.Fields[i];
                        Assert.IsNotNull(field);
                        Assert.That(field.Id, Is.EqualTo("field1").Or.EqualTo("field4").Or.EqualTo("field5"));
                        break;
                    case FieldDataType.Map:
//                        MapField mapField = schema.Fields[i].Cast<MapField>();
//                        Assert.IsNotNull(mapField);
//                        Assert.AreEqual("field2", mapField.Id);
                        break;
                    case FieldDataType.List:
//                        ListField listField = schema.Fields[i].Cast<ListField>();
//                        Assert.IsNotNull(listField);
//                        Assert.AreEqual("field3", listField.Id);
                        break;
                    case FieldDataType.Decimal:
                        DecimalField decimalField = schema.Fields[i].Cast<DecimalField>();
                        Assert.IsNotNull(decimalField);
                        Assert.AreEqual("field6", decimalField.Id);
                        break;
                    case FieldDataType.Structure:
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
        public void Verify_does_not_allow_adding_duplicate_fields_using_AddRange()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Build();
            var field = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            schema.Fields.AddRange(field);
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(2, schema.Fields.Count);
        }

        [Test]
        public void Verify_cannot_add_fields_with_same_identifier()
        {
            ISchemaValidator validator = new SchemaValidator();
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Field("field2", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .Field("field4", FieldDataType.Primitive)
                .Field("field5", FieldDataType.Primitive)
                .Field("field3", FieldDataType.Primitive)
                .RegisterObserver(validator)
                .Build();
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(6, schema.Fields.Count);

            Assert.IsNotEmpty(validator.Validation);
            Assert.AreEqual(1, validator.Validation.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_any_null_fields_using_AddRange_via_params()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Build();
            var field = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            schema.Fields.AddRange(field, null, null, null);
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(2, schema.Fields.Count);

//            schema.Validate();
            
//            Assert.AreEqual(3, schema.Validations.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_any_null_fields_using_AddRange_via_IList()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Build();
            var field = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            IList<Field> fields = new List<Field>();
            fields.Add(field);
            fields.Add(null);
            
            schema.Fields.AddRange(fields);
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(2, schema.Fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_all_null_fields_using_AddRange_via_params()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Build();
            
            schema.Fields.AddRange(null);
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(1, schema.Fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_all_null_fields_using_AddRange_via_IList()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Build();

            IList<Field> fields = null;
            
            schema.Fields.AddRange(fields);
            
            Assert.IsTrue(schema.Fields.HasValues);
            Assert.AreEqual(1, schema.Fields.Count);
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_negative_index()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
                .Build();
            
            Assert.IsFalse(schema.Fields.TryGetValue(-1, out _));
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_greater_than_count_index()
        {
            var schema = Schema.Builder()
                .Field("field1", FieldDataType.Primitive)
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