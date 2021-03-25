using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities;
using Polaris.Application.Repositories;

namespace Polaris.Services.DataAccess.OnMemory.Stores
{
    public abstract class Store<T> : ICrudRepository<T> where T : class, IEntity
    {
        private static readonly Dictionary<Guid, T> OrganizationsCommitted = new Dictionary<Guid, T>();
        private readonly Dictionary<Guid, StateTracker<T>> _organizations = new Dictionary<Guid, StateTracker<T>>();
        
        public virtual IEnumerable<T> GetAll()
        {
            return OrganizationsCommitted.Values;
        }

        public virtual IEnumerable<T> Where(Predicate<T> expression)
        {
            return OrganizationsCommitted.Values.Where(expression.Invoke);
        }

        public virtual T FirstOrDefault(Predicate<T> expression)
        {
            return OrganizationsCommitted.Values.FirstOrDefault(expression.Invoke);
        }

        public virtual T FindByGuid(Guid id)
        {
            OrganizationsCommitted.TryGetValue(id, out var value);
            return value;
        }

        public virtual void Add(T input)
        {
            _organizations.Add(input.Id, new StateTracker<T>(input){Added = true});
        }

        public virtual T Update(Guid id, T updatedData)
        {
            var (key, value) = _organizations.FirstOrDefault(x => x.Value.Value.Id == id);
            value.Updated = true;
            _organizations[key] = value;
            return value.Value;
        }

        public virtual void Delete(T input)
        {
            var (key, value) = _organizations.FirstOrDefault(x => x.Value.Value.Id == input.Id);
            value.Deleted = true;
            _organizations[key] = value;
        }

        public virtual void Delete(Guid id)
        {
            var (key, value) = _organizations.FirstOrDefault(x => x.Value.Value.Id == id);
            value.Deleted = true;
            _organizations[key] = value;
        }

        public virtual void TryCommitChanges()
        {
            lock (OrganizationsCommitted)
            {
                foreach (var (key, tracker) in _organizations)
                {
                    if (tracker.Updated)
                    {
                        OrganizationsCommitted[key] = tracker.Value;
                        break;
                    }
                    if (tracker.Added)
                    {
                        OrganizationsCommitted.Add(key, tracker.Value);
                        break;
                    }
                    if (tracker.Deleted)
                    {
                        OrganizationsCommitted.Remove(key);
                        break;
                    }
                }
                _organizations.Clear();
            }
        }

        public virtual bool TryRollbackChanges()
        {
            _organizations.Clear();
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