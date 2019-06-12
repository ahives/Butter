namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class EqualsListTests
    {
        [Test]
        public void Verify_readonly_list_are_equal()
        {
            var fields1 = new FieldList();
            
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            var fields2 = new FieldList();
            
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());
            
            IReadOnlyFieldList temp1 = fields1;
            IReadOnlyFieldList temp2 = fields2;
            
            Assert.IsTrue(temp1.Equals(temp2));
        }

        [Test]
        public void Verify_readonly_list_are_not_equal()
        {
            var fields1 = new FieldList();
            
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            var fields2 = new FieldList();
            
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field6").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add<FieldBuilder>(x => x.Id("field6").DataType(FieldDataType.Primitive).IsNullable().Build());
            IReadOnlyFieldList temp1 = fields1;
            IReadOnlyFieldList temp2 = fields2;
            
            Assert.IsFalse(temp1.Equals(temp2));
        }

        [Test]
        public void Verify_list_are_equal()
        {
            var fields1 = new FieldList();
            
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            var fields2 = new FieldList();
            
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());
            
            Assert.IsTrue(fields1.Equals(fields2));
        }

        [Test]
        public void Verify_list_are_not_equal()
        {
            var fields1 = new FieldList();
            
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields1.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());

            var fields2 = new FieldList();
            
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field1").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field2").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field3").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field4").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field5").DataType(FieldDataType.Primitive).IsNullable().Build());
            fields2.Add(FieldSpec.Builder<FieldBuilder>().Id("field6").DataType(FieldDataType.Primitive).IsNullable().Build());
            
            Assert.IsFalse(fields1.Equals(fields2));
        }
    }
}