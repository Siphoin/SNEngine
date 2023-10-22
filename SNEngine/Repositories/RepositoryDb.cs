using System;
using System.Collections.Generic;

namespace SNEngine.Repositories
{
    public sealed class RepositoryDb
    {
        private Dictionary<Type, RepositoryBase> _repositories;
        public void Initialize()
        {
            _repositories = new Dictionary<Type, RepositoryBase>();

            RepositoryBase[] repositories =
            {
            };

            foreach (var repository in repositories)
            {
                _repositories.Add(repository.GetType(), repository);

                repository.Initialize();
            }


        }

        public T Get<T>() where T : RepositoryBase
        {
            return (T)_repositories[typeof(T)];
        }
    }
}
