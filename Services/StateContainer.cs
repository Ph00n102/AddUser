namespace HosxpUi.Services 
{
    public class StateContainer
    {
    
        private string _loginName;
        private string _role;
    
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

        public string Role
        {
            get => _role;
            set
            {
                if (_role != value)
                {
                    _role = value;
                    NotifyStateChanged();
                }
            }
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}