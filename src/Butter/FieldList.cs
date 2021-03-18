namespace Butter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Builders;
    using Notification;
    using Specification;

    public class FieldList :
        ReadOnlyFieldList, IFieldList
    {
        public FieldList(bool notifyObservers = false)
            : base(notifyObservers)
        {
        }

        public PrimitiveField Remove(int index)
        {
            if (index > _count || index < 0)
                return SchemaCache.MissingField;

            if (!TryGetValue(index, out PrimitiveField field))
                return SchemaCache.MissingField;
                
            NotifyObservers(field, SchemaActionType.Delete);
                
            _fields.RemoveAt(index);
            _count = _fields.Count;

            return field;
        }

        public PrimitiveField Remove(string id)
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                if (_fields[i].Id != id)
                    continue;

                PrimitiveField field = _fields[i];
                
                _fields.RemoveAt(i);
                _count = _fields.Count;
                
                NotifyObservers(field, SchemaActionType.Delete);
                
                return field;
            }

            return SchemaCache.MissingField;
        }

        public bool TryRemove(int index, out PrimitiveField field)
        {
            if (index > _count || index < 0)
            {
                field = SchemaCache.MissingField;
                return false;
            }

            if (!TryGetValue(index, out PrimitiveField spec))
            {
                field = SchemaCache.MissingField;
                return false;
            }
            
            field = spec;
            
            _fields.RemoveAt(index);
            _count = _fields.Count;
            
            NotifyObservers(spec, SchemaActionType.Delete);

            return true;
        }

        public bool TryRemove(string id, out PrimitiveField field)
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                if (_fields[i].Id != id)
                    continue;
                
                field = _fields[i];

                _fields.RemoveAt(i);
                _count = _fields.Count;

                NotifyObservers(field, SchemaActionType.Delete);
            
                return true;
            }
            
            field = SchemaCache.MissingField;

            return false;
        }

        public PrimitiveField Replace(int index, PrimitiveField field)
        {
            if (index < 0 || index > _count)
                return SchemaCache.MissingField;

            if (!TryGetValue(index, out PrimitiveField previous))
                return SchemaCache.MissingField;

            _fields[index] = field;
            
            NotifyObservers(field, SchemaActionType.Replace);

            return previous;
        }

        public PrimitiveField Replace(string id, PrimitiveField field)
        {
            if (string.IsNullOrWhiteSpace(id))
                return SchemaCache.MissingField;

            if (!TryGetValue(id, out PrimitiveField previous))
                return SchemaCache.MissingField;

            for (int i = 0; i < _count; i++)
            {
                if (_fields[i].Id != id)
                    continue;

                _fields[i] = field;
            
                NotifyObservers(field, SchemaActionType.Replace);
                break;
            }

            return previous;
        }

        public bool TryReplace(int index, PrimitiveField field, out PrimitiveField replaced)
        {
            if (index < 0 || index > _count)
            {
                replaced = SchemaCache.MissingField;
                return false;
            }
            
            if (!TryGetValue(index, out replaced))
            {
                replaced = SchemaCache.MissingField;
                return false;
            }

            _fields[index] = field;
                
            NotifyObservers(field, SchemaActionType.Replace);
            
            return true;
        }

        public bool TryReplace(string id, PrimitiveField field, out PrimitiveField replaced)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                replaced = SchemaCache.MissingField;
                return false;
            }

            if (!TryGetValue(id, out replaced))
            {
                replaced = SchemaCache.MissingField;
                return false;
            }

            for (int i = 0; i < _count; i++)
            {
                if (_fields[i].Id != id)
                    continue;

                _fields[i] = field;
                
                NotifyObservers(field, SchemaActionType.Replace);
                
                return true;
            }
            
            replaced = SchemaCache.MissingField;
            return false;
        }

        public void Add(PrimitiveField field)
        {
            if (field == null)
            {
                NotifyObservers(field, SchemaActionType.None);
                return;
            }
            
            _fields.Add(field);
            _count = _fields.Count;
            
            NotifyObservers(field, SchemaActionType.Add);
        }

        public void Add<TBuilder>(Func<TBuilder, PrimitiveField> criteria)
            where TBuilder : IFieldBuilder
        {
            TBuilder builder = Field.Builder<TBuilder>();
            PrimitiveField field = criteria(builder);
            
            if (field == null)
            {
                NotifyObservers(field, SchemaActionType.None);
                return;
            }
            
            _fields.Add(field);
            _count = _fields.Count;
            
            NotifyObservers(field, SchemaActionType.Add);
        }

        public void AddRange(IList<PrimitiveField> field)
        {
            if (field == null)
                return;
            
            for (int i = 0; i < field.Count; i++)
            {
                if (field[i] == null)
                {
                    NotifyObservers(field[i], SchemaActionType.None);
                    continue;
                }
                
                _fields.Add(field[i]);
                _count++;
                
                NotifyObservers(field[i], SchemaActionType.Add);
            }
        }

        public void AddRange(params PrimitiveField[] fields)
        {
            if (fields == null)
                return;
            
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == null)
                {
                    NotifyObservers(fields[i], SchemaActionType.None);
                    continue;
                }
                
                _fields.Add(fields[i]);
                _count++;
                
                NotifyObservers(fields[i], SchemaActionType.Add);
            }
        }

        public bool Equals(IFieldList other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;

            if (_count != other.Count)
                return false;

            for (int i = 0; i < other.Count; i++)
            {
                if (!Contains(other[i].Id))
                    return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            
            if (ReferenceEquals(this, obj))
                return true;
            
            if (obj.GetType() != this.GetType())
                return false;
            
            return Equals((FieldList) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_fields != null ? _fields.GetHashCode() : 0) * 397) ^ _count;
            }
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();

            buffer.AppendLine("\t[FIELDS]");
            
            for (int i = 0; i < _count; i++)
            {
                buffer.AppendLine($"\t\t=> [{i + 1}] {_fields[i]}");
            }

            return buffer.ToString();
        }
    }
}