namespace Butter.Tests
{
    using NUnit.Framework;
    using Specification;

    [TestFixture]
    public class RemoveListTests
    {
        [Test]
        public void Verify_can_remove_field_first_using_id()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove("field1");
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_middle_using_id()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove("field2");
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_last_using_id()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove("field3");
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_first_using_index()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove(0);
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_remove_does_not_throw_when_index_less_than_zero()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove(-1);
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_remove_does_not_throw_when_index_greater_than_field_list()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove(5);
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_middle_using_index()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove(1);
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_last_using_index()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            PrimitiveField specification = fields.Remove(2);
            
            Assert.IsNotNull(specification);
            Assert.IsFalse(fields.Contains(specification));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_does_not_throw_when_index_less_than_zero()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsFalse(fields.TryRemove(-1, out PrimitiveField field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_does_not_throw_when_index_greater_than_field_list()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsFalse(fields.TryRemove(5, out PrimitiveField field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_can_remove_field_first_using_index()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsTrue(fields.TryRemove(0, out PrimitiveField field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_can_remove_field_middle_using_index()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsTrue(fields.TryRemove(1, out PrimitiveField field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_can_remove_field_last_using_index()
        {
            IFieldList fields = new FieldList();

            var field1 = Field.Builder<FieldBuilder>()
                .Id("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Field.Builder<FieldBuilder>()
                .Id("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Field.Builder<FieldBuilder>()
                .Id("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsTrue(fields.TryRemove(2, out PrimitiveField field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }
    }
}