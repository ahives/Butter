namespace Butter.Tests
{
    using System.Collections.Generic;
    using Builders;
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class AddRangeListTests
    {
        [Test]
        public void Verify_does_not_allow_adding_duplicate_fields_using_AddRange()
        {
            var fields = new FieldList();

            var field1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.AddRange(field2);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_any_null_fields_using_AddRange_via_params()
        {
            var fields = new FieldList();

            var field1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<Primitive>()
                .Id("field2")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.AddRange(field2, null, null, null);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_any_null_fields_using_AddRange_via_IList()
        {
            var fields = new FieldList();

            var field1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field = Field.Builder<Primitive>()
                .Id("field2")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            IList<PrimitiveField> fields2 = new List<PrimitiveField>();
            fields.Add(field);
            fields.Add(null);
            
            fields.AddRange(fields2);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_all_null_fields_using_AddRange_via_params()
        {
            var fields = new FieldList();

            var field1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            fields.AddRange(null);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(1, fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_all_null_fields_using_AddRange_via_IList()
        {
            var fields = new FieldList();

            var field1 = Field.Builder<Primitive>()
                .Id("field1")
                .DataType(SchemaDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            IList<PrimitiveField> fields2 = null;
            
            fields.AddRange(fields2);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(1, fields.Count);
        }
    }
}