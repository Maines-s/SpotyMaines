namespace SpotyMaines.ViewModel.AuthModule
{
    public class TokenViewModel
    {
        public string Key { get; set; }
        public DateTime ExpirationTime { get; set; }
        public UserTokenViewModel UserVM { get; set; }
    }
}
