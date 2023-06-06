namespace Core.Services.Locator
{
    public interface IServiceLocator
    { 
        T GetService<T>() where T : IService;
    }
}