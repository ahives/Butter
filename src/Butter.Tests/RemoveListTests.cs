namespace Butter.Tests
{
    using Grammar;
    using NUnit.Framework;

    [TestFixture]
    public class RemoveListTests
    {
        [Test]
        public void Verify_can_remove_field_first_using_id()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove("field1");
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_middle_using_id()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove("field2");
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_last_using_id()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove("field3");
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_first_using_index()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove(0);
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_remove_does_not_throw_when_index_less_than_zero()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove(-1);
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_remove_does_not_throw_when_index_greater_than_field_list()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove(5);
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_middle_using_index()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove(1);
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_can_remove_field_last_using_index()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);

            Field field = fields.Remove(2);
            
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_does_not_throw_when_index_less_than_zero()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsFalse(fields.TryRemove(-1, out Field field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_does_not_throw_when_index_greater_than_field_list()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsFalse(fields.TryRemove(5, out Field field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(3, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_can_remove_field_first_using_index()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsTrue(fields.TryRemove(0, out Field field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_can_remove_field_middle_using_index()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsTrue(fields.TryRemove(1, out Field field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }

        [Test]
        public void Verify_TryRemove_can_remove_field_last_using_index()
        {
            var fields = new FieldList(false);

            var field1 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field1")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field1);
            
            var field2 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field2")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field2);
            
            var field3 = Schema.Field.Builder<FieldBuilder>()
                .Identifier("field3")
                .DataType(FieldDataType.Primitive)
                .IsNullable()
                .Build();
            
            fields.Add(field3);
            
            Assert.IsTrue(fields.HasValues);
            Assert.AreEqual(3, fields.Count);
            Assert.IsTrue(fields.TryRemove(2, out Field field));
            Assert.IsNotNull(field);
            Assert.IsFalse(fields.Contains(field));
            Assert.AreEqual(2, fields.Count);
        }
    }
}