namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class ReadOnlyFieldListExtensionsTests
    {
        [Test]
        public void Test()
        {
            var schema = Schema.Builder()
                .Field<Struct>(x =>
                {
                    return x.Id("field1")
                        .Field<Primitive>(f => f.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<Primitive>(f => f.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                        .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                        .Build();
                })
                .Field<Primitive>(x => x.Id("field6").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field7").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field8").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field9").IsNullable().Build())
                .Field<Primitive>(x => x.Id("field10").IsNullable().Build())
                .Build();

            IReadOnlyFieldList fieldList = schema.Fields.SelectMany();
            
            Assert.AreEqual(10, fieldList.Count);
        }


    }
}