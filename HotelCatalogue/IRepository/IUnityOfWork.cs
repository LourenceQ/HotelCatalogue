using HotelCatalogue.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCatalogue.IRepository
{
    public interface IUnityOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels{ get; }
        Task Save();
    }
}
