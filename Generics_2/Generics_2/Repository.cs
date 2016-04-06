using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics_2
{
    public class Repository
    {
        private readonly Dictionary<Guid, object> _repository = new Dictionary<Guid, object>();
        private readonly Dictionary<Type, List<Guid>> _guidsByType = new Dictionary<Type, List<Guid>>();

        public TObject Create<TObject>()
            where TObject : new()
        {
            var obj = new TObject();
            var guid = Guid.NewGuid();
            var type = typeof(TObject);

            _repository.Add(guid, obj);

            if( !_guidsByType.ContainsKey(type))
                _guidsByType[type] = new List<Guid>();
            _guidsByType[type].Add(guid);

            return obj;
        }

        public IEnumerable<Tuple<Guid, TObject>> All<TObject>()
        {
            return _guidsByType[typeof (TObject)]
                .Select(x => new Tuple<Guid, TObject>(x, (TObject) _repository[x]));
        }

        public TObject Get<TObject>(Guid guid)
        {
            if (!_repository.ContainsKey(guid) || !(_repository[guid] is TObject))
                return default(TObject);
            return (TObject) _repository[guid];
        }
    }
}
