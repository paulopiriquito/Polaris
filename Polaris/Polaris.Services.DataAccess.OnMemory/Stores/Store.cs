using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Repositories;
using Polaris.Domain.Entities;

namespace Polaris.Services.DataAccess.OnMemory.Stores
{
    public abstract class Store<T> : ICrudRepository<T> where T : class, IEntity
    {
        private static readonly Dictionary<Guid, T> OrganisationsCommitted = new Dictionary<Guid, T>();
        private readonly Dictionary<Guid, StateTracker<T>> _organisations = new Dictionary<Guid, StateTracker<T>>();
        
        public virtual IEnumerable<T> GetAll()
        {
            return OrganisationsCommitted.Values;
        }

        public virtual IEnumerable<T> Where(Predicate<T> expression)
        {
            return OrganisationsCommitted.Values.Where(expression.Invoke);
        }

        public virtual T FirstOrDefault(Predicate<T> expression)
        {
            return OrganisationsCommitted.Values.FirstOrDefault(expression.Invoke);
        }

        public virtual T FindByGuid(Guid id)
        {
            OrganisationsCommitted.TryGetValue(id, out var value);
            return value;
        }

        public virtual void Add(T input)
        {
            _organisations.Add(input.Id, new StateTracker<T>(input){Added = true});
        }

        public virtual T Update(Guid id, T updatedData)
        {
            var (key, value) = _organisations.FirstOrDefault(x => x.Value.Value.Id == id);
            value.Updated = true;
            _organisations[key] = value;
            return value.Value;
        }

        public virtual void Delete(T input)
        {
            var (key, value) = _organisations.FirstOrDefault(x => x.Value.Value.Id == input.Id);
            value.Deleted = true;
            _organisations[key] = value;
        }

        public virtual void Delete(Guid id)
        {
            var (key, value) = _organisations.FirstOrDefault(x => x.Value.Value.Id == id);
            value.Deleted = true;
            _organisations[key] = value;
        }

        public virtual void TryCommitChanges()
        {
            lock (OrganisationsCommitted)
            {
                foreach (var (key, tracker) in _organisations)
                {
                    if (tracker.Updated)
                    {
                        OrganisationsCommitted[key] = tracker.Value;
                        break;
                    }
                    if (tracker.Added)
                    {
                        OrganisationsCommitted.Add(key, tracker.Value);
                        break;
                    }
                    if (tracker.Deleted)
                    {
                        OrganisationsCommitted.Remove(key);
                        break;
                    }
                }
                _organisations.Clear();
            }
        }

        public virtual bool TryRollbackChanges()
        {
            _organisations.Clear();
            return true;
        }
        
        private class StateTracker<TK>
        {
            public StateTracker(TK value)
            {
                Value = value;
            }
        
            public TK Value { get; }
            public bool Added { get; set; }
            public bool Deleted { get; set; }
            public bool Updated { get; set; }
        }
    }
}