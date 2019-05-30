namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class StructFieldTests
    {
        [Test]
        public void Test()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Id("fieldA")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Id("fieldB")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Id("fieldC")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);

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
                .Field("field7", fields)
                .Build();

            IReadOnlyFieldList fieldList = schema.Fields.SelectMany();
            
            Assert.AreEqual(10, fieldList.Count);
        }
    }
}