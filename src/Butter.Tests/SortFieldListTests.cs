namespace Butter.Tests
{
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class SortFieldListTests
    {
        [Test]
        public void Verify_can_sort()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field4").Index(4).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Struct>(x => x.Id("field7")
                .Index(7)
                .Field<Primitive>(f => f.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(f => f.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(f => f.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                .Build());
            fields.Add<Primitive>(x => x.Id("field1").Index(1).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Decimal>(x => x.Id("field6").Index(6).Precision(2).Scale(5).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").Index(2).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").Index(5).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").Index(3).DataType(FieldDataType.Primitive).IsNullable().Build());

            Assert.AreEqual(7, fields.Count);
            
            Assert.AreEqual("field4", fields[0].Id);
            Assert.AreEqual("field7", fields[1].Id);
            Assert.AreEqual("field1", fields[2].Id);
            Assert.AreEqual("field6", fields[3].Id);
            Assert.AreEqual("field2", fields[4].Id);
            Assert.AreEqual("field5", fields[5].Id);
            Assert.AreEqual("field3", fields[6].Id);
            Assert.AreEqual(FieldDataType.Struct, fields[1].DataType);
            Assert.AreEqual(FieldDataType.Decimal, fields[3].DataType);

            fields.Sort();
            
            Assert.AreEqual(7, fields.Count);
            Assert.AreEqual("field1", fields[0].Id);
            Assert.AreEqual("field2", fields[1].Id);
            Assert.AreEqual("field3", fields[2].Id);
            Assert.AreEqual("field4", fields[3].Id);
            Assert.AreEqual("field5", fields[4].Id);
            Assert.AreEqual("field6", fields[5].Id);
            Assert.AreEqual("field7", fields[6].Id);
            Assert.AreEqual(FieldDataType.Struct, fields[6].DataType);
            Assert.AreEqual(FieldDataType.Decimal, fields[5].DataType);
        }

        [Test]
        public void Verify_can_sort_when_indexes_are_same()
        {
            var fields = new FieldList();
            
            fields.Add<Primitive>(x => x.Id("field4").Index(3).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Struct>(x => x.Id("field7")
                .Index(6)
                .Field<Primitive>(f => f.Id("fieldA").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(f => f.Id("fieldB").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<Primitive>(f => f.Id("fieldC").DataType(FieldDataType.Primitive).IsNullable().Build())
                .Field<Decimal>(f => f.Id("fieldD").Precision(5).Scale(2).IsNullable().Build())
                .Build());
            fields.Add<Primitive>(x => x.Id("field1").Index(1).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Decimal>(x => x.Id("field6").Index(5).Precision(2).Scale(5).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field2").Index(2).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field5").Index(4).DataType(FieldDataType.Primitive).IsNullable().Build());
            fields.Add<Primitive>(x => x.Id("field3").Index(3).DataType(FieldDataType.Primitive).IsNullable().Build());

            Assert.AreEqual(7, fields.Count);
            
            Assert.AreEqual("field4", fields[0].Id);
            Assert.AreEqual("field7", fields[1].Id);
            Assert.AreEqual("field1", fields[2].Id);
            Assert.AreEqual("field6", fields[3].Id);
            Assert.AreEqual("field2", fields[4].Id);
            Assert.AreEqual("field5", fields[5].Id);
            Assert.AreEqual("field3", fields[6].Id);
            Assert.AreEqual(FieldDataType.Struct, fields[1].DataType);
            Assert.AreEqual(FieldDataType.Decimal, fields[3].DataType);

            fields.Sort();
            
            Assert.AreEqual(7, fields.Count);
            Assert.AreEqual("field1", fields[0].Id);
            Assert.AreEqual("field2", fields[1].Id);
            Assert.AreEqual("field4", fields[2].Id);
            Assert.AreEqual("field3", fields[3].Id);
            Assert.AreEqual("field5", fields[4].Id);
            Assert.AreEqual("field6", fields[5].Id);
            Assert.AreEqual("field7", fields[6].Id);
            Assert.AreEqual(FieldDataType.Struct, fields[6].DataType);
            Assert.AreEqual(FieldDataType.Decimal, fields[5].DataType);
        }
    }
}