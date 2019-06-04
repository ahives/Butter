namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class ReadOnlyFieldListExtensionsTests
    {
        [Test]
        public void Test()
        {
            var schema = Schema.Builder()
                .Field<StructFieldBuilder>(x =>
                {
                    return x.Id("field1")
                        .Field<FieldBuilder>(f => f.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<FieldBuilder>(f => f.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<DecimalFieldBuilder>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<FieldBuilder>(x => x.Id("field6").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field7").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field8").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field9").IsNullable().Build())
                .Field<FieldBuilder>(x => x.Id("field10").IsNullable().Build())
                .Build();

            IReadOnlyFieldList fieldList = schema.Fields.SelectMany();
            
            Assert.AreEqual(10, fieldList.Count);
        }


    }
}