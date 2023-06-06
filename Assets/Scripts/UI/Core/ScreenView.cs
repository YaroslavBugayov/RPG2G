using UnityEngine;

namespace UI.Core
{
    public abstract class ScreenView : MonoBehaviour
    {
        [SerializeField] private Canvas _view;
        [SerializeField] private ScreenType _screenType;
        
        public ScreenType ScreenType => _screenType;
        public virtual void Show() => _view.enabled = true;
        public virtual void Hide() => _view.enabled = false;
    }
}