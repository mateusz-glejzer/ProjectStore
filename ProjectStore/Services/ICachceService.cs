using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectStore.Services
{
    public interface ICachceService
    {
        Task<string> GetCacheValue(string key);
        Task SetCacheValue(string key,string value);



    }
}
