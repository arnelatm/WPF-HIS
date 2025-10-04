using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AATM.Contracts.Interfaces.Services;

namespace AATM.UI.Winforms.BaseControls
{
    internal sealed class GridCrudController<TDto> : IGridCrudController
        where TDto : class, IEntityWithId, new()
    {
        private readonly ICrudService<TDto> _service;
        private readonly BindingList<TDto> _typedItems = new BindingList<TDto>();

        private readonly PropertyInfo[] _simpleProps;
        private readonly Dictionary<string, Func<TDto, object>> _valueGetters;
        private readonly BindingList<object> _untypedAdapter;
        private readonly List<GridPropertyDescriptor> _gridPropertyDescriptors;

        public GridCrudController(ICrudService<TDto> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            _simpleProps = typeof(TDto)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead &&
                            (p.PropertyType == typeof(string) ||
                             p.PropertyType.IsValueType))
                .ToArray();

            _valueGetters = _simpleProps.ToDictionary(p => p.Name, CompileGetter);

            // Live adapter (no per-load copying)
            _untypedAdapter = new BindingList<object>();
            _typedItems.ListChanged += (_, __) => SyncUntypedAdapter();

            _gridPropertyDescriptors = _simpleProps
                .Select(p => new GridPropertyDescriptor(p.Name, p.PropertyType))
                .ToList();
        }

        public Type DtoType => typeof(TDto);

        public BindingList<object> LiveUntypedItems => _untypedAdapter;

        public IReadOnlyList<GridPropertyDescriptor> GridProperties => _gridPropertyDescriptors;

        public async Task LoadAsync(CancellationToken ct)
        {
            var list = await _service.GetAllAsync(ct) ?? Array.Empty<TDto>();
            _typedItems.RaiseListChangedEvents = false;
            try
            {
                _typedItems.Clear();
                foreach (var e in list) _typedItems.Add(e);
            }
            finally
            {
                _typedItems.RaiseListChangedEvents = true;
                _typedItems.ResetBindings();
            }
            SyncUntypedAdapter();
        }

        private void SyncUntypedAdapter()
        {
            _untypedAdapter.RaiseListChangedEvents = false;
            try
            {
                _untypedAdapter.Clear();
                foreach (var t in _typedItems)
                    _untypedAdapter.Add(t);
            }
            finally
            {
                _untypedAdapter.RaiseListChangedEvents = true;
                _untypedAdapter.ResetBindings();
            }
        }

        public object CreateNew() => new TDto();

        public async Task<object> SaveAsync(object model, CancellationToken ct)
        {
            var dto = (TDto)model;
            var saved = await _service.UpsertAsync(dto, ct);
            return saved;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _service.DeleteAsync(id, ct);
        }

        public int GetId(object entity) => entity is TDto t ? t.ID : 0;

        public IEnumerable<object> Filter(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return _typedItems;

            query = query.Trim();
            return _typedItems.Where(item =>
                _simpleProps.Any(p =>
                {
                    var val = p.GetValue(item);
                    return val != null &&
                           val.ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
                })).Cast<object>().ToList();
        }

        public IEnumerable<object> Sort(string propertyName, bool ascending)
        {
            if (string.IsNullOrEmpty(propertyName) ||
                !_valueGetters.TryGetValue(propertyName, out var getter))
                return _typedItems;

            return ascending
                ? _typedItems.OrderBy(getter).Cast<object>().ToList()
                : _typedItems.OrderByDescending(getter).Cast<object>().ToList();
        }

        private Func<TDto, object> CompileGetter(PropertyInfo prop)
        {
            var param = Expression.Parameter(typeof(TDto), "x");
            Expression body = Expression.Property(param, prop);
            if (body.Type.IsValueType)
                body = Expression.Convert(body, typeof(object));
            return Expression.Lambda<Func<TDto, object>>(body, param).Compile();
        }
    }
}