using HealthMonitor.Infrastructure;
using HealthMonitor.Repo;
using System;
using HealthMonitor.Entity;
using System.Collections.Generic;

namespace HealthMonitor.DAC
{
    public class DataProvider:IDataProvider
    {
        public string _repoType = RepositoryConfig.RepoType;
        private IUserRepoMongo _mongoRepository;
        private IUserRepoEF _efRepository;

        public DataProvider(IUserRepoMongo userRepoMongo, IUserRepoEF userRepoEF)
        {
            if (_repoType == "Mongo")
                _mongoRepository = userRepoMongo;
            else
                _efRepository = userRepoEF;
        }

        public List<User> GetAllUsers()
        {
            var result = new List<User>();
            if (_mongoRepository != null)
                result = _mongoRepository.GetAllUsers();
            else
                result = _efRepository.GetAllUser();

            return result;
        }

        public User GetUser(string name)
        {
            var result = new User();
            result = (_mongoRepository != null) ? _mongoRepository.GetUser(name) : _efRepository.GetUser(name);

            return result;
        }
    }
}
