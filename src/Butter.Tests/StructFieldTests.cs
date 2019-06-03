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

            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("fieldA")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(spec1);
            
            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("fieldB")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(spec2);
            
            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("fieldC")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(spec3);

            DecimalFieldSpec spec4 = Field.Builder<DecimalFieldSpecBuilder>()
                .Id("fieldD")
                .Precision(5)
                .Scale(2)
                .Build();
            
            fields.Add(spec4);

            var spec5 = Field.Builder<StructFieldSpecBuilder>()
                .Id("field1")
                .IsNullable()
                .Fields(fields)
                .Build();

            var schema = Schema.Builder()
                .Field(spec5)
                .Field<FieldSpecBuilder>(x => x.Id("field6").IsNullable().Build())
                .Field<FieldSpecBuilder>(x => x.Id("field7").IsNullable().Build())
                .Field<FieldSpecBuilder>(x => x.Id("field8").IsNullable().Build())
                .Field<FieldSpecBuilder>(x => x.Id("field9").IsNullable().Build())
                .Field<FieldSpecBuilder>(x => x.Id("field10").IsNullable().Build())
                .Build();

            IReadOnlyFieldList fieldList = schema.Fields.SelectMany();
            
            Assert.AreEqual(10, fieldList.Count);
        }

        [Test]
        public void Test1()
        {
            var fields = new FieldList(false);

            FieldSpec spec1 = Field.Builder<FieldSpecBuilder>()
                .Id("fieldA")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(spec1);
            
            FieldSpec spec2 = Field.Builder<FieldSpecBuilder>()
                .Id("fieldB")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(spec2);
            
            FieldSpec spec3 = Field.Builder<FieldSpecBuilder>()
                .Id("fieldC")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(spec3);

            DecimalFieldSpec spec4 = Field.Builder<DecimalFieldSpecBuilder>()
                .Id("field")
                .Precision(5)
                .Scale(2)
                .Build();
            
            fields.Add(spec4);

            var schema = Schema.Builder()
                .Field<StructFieldSpecBuilder>(x => x.Id("fieldX").IsNullable().Fields(fields).Build())
                .Build();

            Assert.AreEqual(1, schema.Fields.Count);
        }
    }
}