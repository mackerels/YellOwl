using System.Threading.Tasks;

namespace YellOwl.Abstractions.Provider
{
    public interface IGenericProvider<T>
    {
        Task<T> Provide();
    }
}