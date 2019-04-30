namespace Butter.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Linq;
    using Builders;
    using Entities.Model;
    using Metadata;
    using NUnit.Framework;

    [TestFixture]
    public class FieldListTests
    {
        [Test]
        public void Verify_can_create_list_of_fields_with_variable_parameters()
        {
//            FieldList fields = DataFieldList.Initialize(
//                DataField.Create<int>("field1"),
//                DataField.Create<int>("field2"),
//                DataField.Create<int>("field3"),
//                DataField.Create<int>("field4"),
//                DataField.Create<int>("field5"));
//            
//            Assert.IsTrue(fields.TryGetValue(0, out var field1));
//            Assert.AreEqual("field1", field1.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(1, out var field2));
//            Assert.AreEqual("field2", field2.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(2, out var field3));
//            Assert.AreEqual("field3", field3.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(3, out var field4));
//            Assert.AreEqual("field4", field4.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(4, out var field5));
//            Assert.AreEqual("field5", field5.Name);
        }

        [Test]
        public void Test()
        {
//            FieldList fields = DataFieldList.Initialize(
//                DataField.Create("field1", DataType.INT32),
//                DataField.Create("field2", DataType.INT32),
//                DataField.Create("field3", DataType.INT32),
//                DataField.Create("field4", DataType.INT32),
//                DataField.Create("field5", DataType.INT32));
//            
//            Assert.IsTrue(fields.TryGetValue(0, out var field1));
//            Assert.AreEqual("field1", field1.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(1, out var field2));
//            Assert.AreEqual("field2", field2.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(2, out var field3));
//            Assert.AreEqual("field3", field3.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(3, out var field4));
//            Assert.AreEqual("field4", field4.Name);
//            
//            Assert.IsTrue(fields.TryGetValue(4, out var field5));
//            Assert.AreEqual("field5", field5.Name);
        }

        [Test]
        public void Verify_can_create_list_of_fields_with_list()
        {
            var builder = SchemaFactory.Instance.GetBuilder<FieldBuilder>();
            var field1 = builder.Create(x => { x.Id("field1"); });
            var field2 = builder.Create(x => { x.Id("field2"); });
            var field3 = builder.Create(x => { x.Id("field3"); });
            var field4 = builder.Create(x => { x.Id("field4"); });
            var field5 = builder.Create(x => { x.Id("field5"); });

            IEntityList<Field> fields = new FieldList();
            fields.Add(field1);
            fields.Add(field2);
            fields.Add(field3);
            fields.Add(field4);
            fields.Add(field5);
            
            Assert.IsTrue(fields.TryGetValue(0, out var f1));
            Assert.AreEqual("field1", f1.Id);
            
            Assert.IsTrue(fields.TryGetValue(1, out var f2));
            Assert.AreEqual("field2", f2.Id);
            
            Assert.IsTrue(fields.TryGetValue(2, out var f3));
            Assert.AreEqual("field3", f3.Id);
            
            Assert.IsTrue(fields.TryGetValue(3, out var f4));
            Assert.AreEqual("field4", f4.Id);
            
            Assert.IsTrue(fields.TryGetValue(4, out var f5));
            Assert.AreEqual("field5", f5.Id);
        }

        [Test]
        public void Verify_TryGetValue_does_not_throw_when_empty()
        {
            IEntityList<Field> fields = new FieldList();
            
            Assert.IsFalse(fields.TryGetValue(0, out _));
        }
    }
}