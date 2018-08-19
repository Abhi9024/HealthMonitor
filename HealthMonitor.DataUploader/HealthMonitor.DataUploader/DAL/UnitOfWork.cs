using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.DataUploader.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;

        public UnitOfWork(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IUserRepository userRepository => _userRepository;
    }
}
