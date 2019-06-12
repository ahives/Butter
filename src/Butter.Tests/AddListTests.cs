namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class AddListTests
    {
        [Test]
        public void Test()
        {
            var fields = new FieldList();
            
            fields.Add<FieldBuilder>(x => x.Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<FieldBuilder>(x => x.Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<DecimalFieldBuilder>(x => x.Id("field6").Precision(2).Scale(5).IsNullable().Build());

            Assert.AreEqual(6, fields.Count);
        }
    }
}