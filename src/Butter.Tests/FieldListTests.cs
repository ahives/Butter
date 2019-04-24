namespace Butter.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Metadata;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListTests
    {
        [Test]
        public void Verify_can_create_list_of_fields_with_variable_parameters()
        {
            var fields = DataFieldList.Create(
                DataField.Create<int>("field1"),
                DataField.Create<int>("field2"),
                DataField.Create<int>("field3"),
                DataField.Create<int>("field4"),
                DataField.Create<int>("field5"));
            
            Assert.IsTrue(fields.TryGetValue(0, out var field1));
            Assert.AreEqual("field1", field1.Name);
            
            Assert.IsTrue(fields.TryGetValue(1, out var field2));
            Assert.AreEqual("field2", field2.Name);
            
            Assert.IsTrue(fields.TryGetValue(2, out var field3));
            Assert.AreEqual("field3", field3.Name);
            
            Assert.IsTrue(fields.TryGetValue(3, out var field4));
            Assert.AreEqual("field4", field4.Name);
            
            Assert.IsTrue(fields.TryGetValue(4, out var field5));
            Assert.AreEqual("field5", field5.Name);
        }

        [Test]
        public void Test()
        {
            var fields = DataFieldList.Create(
                DataField.Create("field1", DataType.INT32),
                DataField.Create("field2", DataType.INT32),
                DataField.Create("field3", DataType.INT32),
                DataField.Create("field4", DataType.INT32),
                DataField.Create("field5", DataType.INT32));
            
            Assert.IsTrue(fields.TryGetValue(0, out var field1));
            Assert.AreEqual("field1", field1.Name);
            
            Assert.IsTrue(fields.TryGetValue(1, out var field2));
            Assert.AreEqual("field2", field2.Name);
            
            Assert.IsTrue(fields.TryGetValue(2, out var field3));
            Assert.AreEqual("field3", field3.Name);
            
            Assert.IsTrue(fields.TryGetValue(3, out var field4));
            Assert.AreEqual("field4", field4.Name);
            
            Assert.IsTrue(fields.TryGetValue(4, out var field5));
            Assert.AreEqual("field5", field5.Name);
        }

        [Test]
        public void Verify_can_create_list_of_fields_with_list()
        {
            var fieldList = new List<Field<int>>
            {
                DataField.Create<int>("field1"),
                DataField.Create<int>("field2"),
                DataField.Create<int>("field3"),
                DataField.Create<int>("field4"),
                DataField.Create<int>("field5")
            };

            var readOnlyFields = new ReadOnlyCollection<Field<int>>(fieldList);
            
            var fields = DataFieldList.Create(readOnlyFields);
            
            Assert.IsTrue(fields.TryGetValue(0, out var field1));
            Assert.AreEqual("field1", field1.Name);
            
            Assert.IsTrue(fields.TryGetValue(1, out var field2));
            Assert.AreEqual("field2", field2.Name);
            
            Assert.IsTrue(fields.TryGetValue(2, out var field3));
            Assert.AreEqual("field3", field3.Name);
            
            Assert.IsTrue(fields.TryGetValue(3, out var field4));
            Assert.AreEqual("field4", field4.Name);
            
            Assert.IsTrue(fields.TryGetValue(4, out var field5));
            Assert.AreEqual("field5", field5.Name);
        }

        [Test]
        public void Test2()
        {
            var fields = DataFieldList.Create<int>();
            
            Assert.IsFalse(fields.TryGetValue(0, out var _));
        }
    }
}