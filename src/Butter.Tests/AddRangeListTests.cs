namespace Butter.Tests
{
    using System.Collections.Generic;
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class AddRangeListTests
    {
        [Test]
        public void Verify_does_not_allow_adding_duplicate_fields_using_AddRange()
        {
            var fields = new FieldList(false);

            var field1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.AddRange(field2);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_any_null_fields_using_AddRange_via_params()
        {
            var fields = new FieldList(false);

            var field1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.AddRange(field2, null, null, null);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_any_null_fields_using_AddRange_via_IList()
        {
            var fields = new FieldList(false);

            var field1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field = Field.Builder<FieldSpecBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            IList<FieldSpec> fields2 = new List<FieldSpec>();
            fields.Add(field);
            fields.Add(null);
            
            fields.AddRange(fields2);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_does_not_allow_adding_all_null_fields_using_AddRange_via_params()
        {
            var fields = new FieldList(false);

            var field1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
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
            var fields = new FieldList(false);

            var field1 = Field.Builder<FieldSpecBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            IList<FieldSpec> fields2 = null;
            
            fields.AddRange(fields2);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(1, fields.Count);
        }
    }
}