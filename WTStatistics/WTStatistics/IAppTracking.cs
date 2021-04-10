using System.Threading.Tasks;

namespace WTStatistics
{
    public interface IAppTracking
    {
        Task<bool> IsAuthorized();
        Task<bool> RequestAuthorizationAsync();
    }
}
