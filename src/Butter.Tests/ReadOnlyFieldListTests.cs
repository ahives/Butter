namespace Butter.Tests
{
    using System;
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class ReadOnlyFieldListTests
    {
        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_negative_index()
        {
            FieldSpec spec = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec)
                .Build();
            
            Assert.IsFalse(schema.Fields.TryGetValue(-1, out _));
        }

        [Test]
        public void Verify_does_not_throw_when_attempting_to_access_greater_than_count_index()
        {
            FieldSpec spec = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec)
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
        
                [Test]
        public void Verify_can_access_list_using_indexer()
        {
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec6 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
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
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec6 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Build();
            
            Assert.IsFalse(schema.Fields.TryGetValue(-1, out FieldSpec field));
            Assert.IsNotNull(field);
        }

        [Test]
        public void Verify_TryGetValue_will_not_throw_when_index_greater_than_count()
        {
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec6 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Build();
            
            int count = schema.Fields.Count;
            Assert.IsFalse(schema.Fields.TryGetValue(count + 1, out FieldSpec field));
            Assert.IsNotNull(field);
        }

        [Test]
        public void Verify_TryGetValue_will_return_field()
        {
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec6 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Build();
            
            Assert.IsTrue(schema.Fields.TryGetValue(3, out FieldSpec field));
            Assert.IsNotNull(field);
            Assert.AreEqual("field4", field.Id);
            Assert.AreEqual(FieldDataType.Primitive, field.DataType);
        }

        [Test]
        public void Verify_TryGetValue_will_return_field_given_identifier()
        {
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec6 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Build();
            
            Assert.IsTrue(schema.Fields.TryGetValue("field4", out FieldSpec field));
            Assert.IsNotNull(field);
            Assert.AreEqual("field4", field.Id);
            Assert.AreEqual(FieldDataType.Primitive, field.DataType);
        }

        [Test]
        public void Verify_can_access_list_with_multiple_field_types()
        {
            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.List)
                .Build();

            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.List)
                .Build();

            FieldSpec spec4 = Field.Builder<FieldSpecBuilder>()
                .Id("field4")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec5 = Field.Builder<FieldSpecBuilder>()
                .Id("field5")
                .DataType(FieldDataType.Primitive)
                .Build();

            FieldSpec spec6 = Field.Builder<FieldSpecBuilder>()
                .Id("field3")
                .DataType(FieldDataType.List)
                .Build();
            
            var schema = Schema.Builder()
                .Field(spec1)
                .Field(spec2)
                .Field(spec3)
                .Field(spec4)
                .Field(spec5)
                .Field(spec6)
                .Build();
            
            for (int i = 0; i < schema.Fields.Count; i++)
            {
                switch (schema.Fields[i].DataType)
                {
                    case FieldDataType.None:
                        break;
                    case FieldDataType.Primitive:
                        FieldSpec specification = schema.Fields[i];
                        Assert.IsNotNull(specification);
                        Assert.That(specification.Id, Is.EqualTo("field1").Or.EqualTo("field4").Or.EqualTo("field5"));
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
                        DecimalFieldSpec spec = schema.Fields[i].Cast<DecimalFieldSpec>();
                        Assert.IsNotNull(spec);
                        Assert.AreEqual("field6", spec.Id);
                        break;
                    case FieldDataType.Struct:
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
    }
}