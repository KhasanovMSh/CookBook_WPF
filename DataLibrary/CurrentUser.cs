namespace DataLibrary
{
    public class CurrentUser : User
    {
        private static User _currentuser;

        public static User currentUser
        {
            get => _currentuser;
            set => _currentuser = value;
        }
    }
}
