namespace UI.Core
{
    public abstract class ScreenPresenter<TView, TModel> : IScreenPresenter
        where TView : ScreenView
        where TModel : IModel
    {
        protected readonly TView View;
        protected readonly TModel Model;

        public ScreenType ScreenType => View.ScreenType;

        protected ScreenPresenter(TView view, TModel model)
        {
            View = view;
            Model = model;
        }

        public virtual void Initialize() => View.Show();
        public virtual void Complete() => View.Hide();

        public abstract void OnDestroy();
    }
}