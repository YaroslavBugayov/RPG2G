namespace UI.Core
{
    public interface IScreenPresenter
    {
        ScreenType ScreenType { get; }
        void Initialize();
        void Complete();
        void OnDestroy();
    }
}