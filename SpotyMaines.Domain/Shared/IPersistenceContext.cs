using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Domain.Shared
{
    public interface IPersistenceContext
    {
        Task<bool> SaveData();

        void UndoChanges();
    }
}
