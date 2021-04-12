using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_DreamTeam.DataAccess
{
    public interface IUnitOfWork
    {
        public void Save();
    }
}
