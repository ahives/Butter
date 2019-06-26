namespace Butter.Tests
{
    using System;
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ReadOnlyFieldListTests
    {
        [Test]
        public void Verify_can_access_list_using_indexer()
        {
            var fields = new FieldList();
            
            fields.Add(Field.Builder<Primitive>().Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            Assert.IsNotNull(temp[0]);
            Assert.IsNotNull(temp[1]);
            Assert.IsNotNull(temp[2]);
            Assert.IsNotNull(temp[3]);
            Assert.IsNotNull(temp[4]);
            Assert.AreEqual("field1", temp[0].Id);
            Assert.AreEqual("field2", temp[1].Id);
            Assert.AreEqual("field3", temp[2].Id);
            Assert.AreEqual("field4", temp[3].Id);
            Assert.AreEqual("field5", temp[4].Id);
        }

        [Test]
        public void Verify_can_access_list_with_multiple_field_types()
        {
            var fields = new FieldList();
            
            fields.Add(Field.Builder<Primitive>().Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field2").DataType(SchemaDataType.Map).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field3").DataType(SchemaDataType.List).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add(Field.Builder<Primitive>().Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            for (int i = 0; i < temp.Count; i++)
            {
                switch (temp[i].DataType)
                {
                    case SchemaDataType.None:
                        break;
                    case SchemaDataType.Primitive:
                        PrimitiveField specification = temp[i];
                        Assert.IsNotNull(specification);
                        Assert.That(specification.Id, Is.EqualTo("field1").Or.EqualTo("field4").Or.EqualTo("field5"));
                        break;
                    case SchemaDataType.Map:
//                        MapField mapField = schema.Fields[i].Cast<MapField>();
//                        Assert.IsNotNull(mapField);
//                        Assert.AreEqual("field2", mapField.Id);
                        break;
                    case SchemaDataType.List:
//                        ListField listField = schema.Fields[i].Cast<ListField>();
//                        Assert.IsNotNull(listField);
//                        Assert.AreEqual("field3", listField.Id);
                        break;
                    case SchemaDataType.Decimal:
                        DecimalField spec = temp[i].Cast<DecimalField>();
                        Assert.IsNotNull(spec);
                        Assert.AreEqual("field6", spec.Id);
                        break;
                    case SchemaDataType.Struct:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}