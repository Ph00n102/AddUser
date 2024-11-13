namespace HosxpUi.Services 
{
    public class StateContainer
    {
        private string _loginName;

        // Event to notify when LoginName changes
        public event Action OnChange;

        public string LoginName
        {
            get => _loginName;
            set
            {
                if (_loginName != value)
                {
                    _loginName = value;
                    NotifyStateChanged();
                }
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}