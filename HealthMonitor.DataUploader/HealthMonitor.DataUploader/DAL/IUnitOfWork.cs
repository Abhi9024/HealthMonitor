using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.DataUploader.DAL
{
    public interface IUnitOfWork
    {
        IUserRepository userRepository { get; }
    }
}
