namespace Butter
{
    using System.Linq;
    using Specification;

    public class ReadOnlyFieldList :
        BaseFieldList, IReadOnlyFieldList
    {
        public bool HasValues => _fields != null && _fields.Any();
        public int Count => _count;

        public PrimitiveField this[int index]
        {
            get
            {
                TryGetValue(index, out PrimitiveField field);

                return field;
            }
        }

        public PrimitiveField this[string id]
        {
            get
            {
                TryGetValue(id, out PrimitiveField field);

                return field;
            }
        }

        protected ReadOnlyFieldList(bool notifyObservers)
            : base(notifyObservers)
        {
        }

        public bool TryGetValue(int index, out PrimitiveField field)
        {
            if (index < 0 || _count <= 0)
            {
                field = SchemaCache.OutOfRangeField;
                return false;
            }

            if (index < _count)
            {
                if (_fields[index] == null)
                {
                    field = SchemaCache.MissingField;
                    return false;
                }
                
                field = _fields[index];
                return true;
            }

            field = SchemaCache.OutOfRangeField;
            return false;
        }

        public bool TryGetValue(string id, out PrimitiveField field)
        {
            if (_count <= 0)
            {
                field = SchemaCache.OutOfRangeField;
                return false;
            }

            for (int i = 0; i < _count; i++)
            {
                if (_fields[i] == null)
                    continue;
                
                if (_fields[i].Id != id)
                    continue;
                
                field = _fields[i];
                return true;
            }
            
            field = SchemaCache.MissingField;
            return false;
        }

        public bool Contains(PrimitiveField field) => field != null && _fields.Contains(field, _containsComparer);

        public void Sort() => _fields.Sort(_sortComparer);

        public bool Contains(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;
            
            for (int i = 0; i < _fields.Count; i++)
            {
                if (_fields[i].Id == id)
                    return true;
            }

            return false;
        }

        public bool Equals(IReadOnlyFieldList other)
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
    }
}