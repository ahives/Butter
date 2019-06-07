namespace Butter.Tests
{
    using System;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ReadOnlyFieldListTests
    {
        [Test]
        public void Verify_can_access_list_using_indexer()
        {
            var fields = new FieldList();
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

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
            
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Map).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.List).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            IReadOnlyFieldList temp = fields;
            
            for (int i = 0; i < temp.Count; i++)
            {
                switch (temp[i].DataType)
                {
                    case FieldDataType.None:
                        break;
                    case FieldDataType.Primitive:
                        Field specification = temp[i];
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
                        DecimalField spec = temp[i].Cast<DecimalField>();
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
    }
}