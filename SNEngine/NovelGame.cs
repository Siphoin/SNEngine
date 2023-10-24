using SNEngine.Debugging;
using SNEngine.Repositories;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine
{
    public static class NovelGame
    {
        private static RepositoryDb _repositoryDb;

        private static ServiceLocator _serviceLocator;

        [RuntimeInitializeOnLoadMethod]
        private static void Main()
        {
            Application.runInBackground = true;

            _repositoryDb = new RepositoryDb();

            _repositoryDb.Initialize();

            _serviceLocator = new ServiceLocator();

            _serviceLocator.Initialize();


        }

        public static T GetRepository<T>() where T : RepositoryBase
        {
            return _repositoryDb.Get<T>();
        }

        public static T GetService<T>() where T : IService
        {
            return _serviceLocator.Get<T>();
        }

        public static void ResetStateServices ()
        {
            NovelGameDebug.Log("Clear Screen");

            _serviceLocator.ResetState();
        }
    }
}
