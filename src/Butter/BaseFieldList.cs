namespace Butter
{
    using System.Collections.Generic;
    using Notification;
    using Specification;

    public abstract class BaseFieldList :
        ObservableList
    {
        protected readonly List<PrimitiveField> _fields;
        protected int _count;
        protected readonly IEqualityComparer<PrimitiveField> _containsComparer;
        protected readonly IComparer<PrimitiveField> _sortComparer;

        protected BaseFieldList(bool notifyObservers)
            : base(notifyObservers)
        {
            _fields = new List<PrimitiveField>();
            _containsComparer = new FieldEqualityComparer();
            _sortComparer = new FieldSortComparer();
            _count = 0;
        }

        
        class FieldEqualityComparer :
            IEqualityComparer<PrimitiveField>
        {
            public bool Equals(PrimitiveField x, PrimitiveField y)
            {
                if (x == null || y == null)
                    return false;

                return x.Id == y.Id;
            }

            public int GetHashCode(PrimitiveField obj) => obj.Id.GetHashCode();
        }

        
        class FieldSortComparer :
            IComparer<PrimitiveField>
        {
            public int Compare(PrimitiveField x, PrimitiveField y)
            {
                if (x == null)
                {
                    if (y == null)
                        return 0;
                    
                    return -1;
                }

                if (y == null)
                    return 1;
                
                if (x.Index == y.Index)
                    return 0;
                
                if (x.Index > y.Index)
                    return 1;
                
                return -1;
            }
        }
    }
}