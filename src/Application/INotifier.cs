using System;
using System.Threading.Tasks;

namespace Application
{
    public interface INotifier
    {
        Task NotifyAsync(string message);
    }
}
