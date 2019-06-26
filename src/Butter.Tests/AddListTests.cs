namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class AddListTests
    {
        [Test]
        public void Test()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field1").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field4").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").DataType(SchemaDataType.Primitive).IsNullable().Build());
            fields.Add<Decimal>(x => x.Id("field6").Precision(2).Scale(5).IsNullable().Build());

            Assert.AreEqual(6, fields.Count);
        }
    }
}