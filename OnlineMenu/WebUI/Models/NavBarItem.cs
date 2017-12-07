namespace WebUI.Models
{
    public class NavBarItem
    {
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool IsActive { get; set; } 
    }
}