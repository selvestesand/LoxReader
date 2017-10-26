namespace LoxReader.Core
{
    public class ApplicationViewModel : BaseViewModel
    {

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.DecryptedContentPage;
        
        public bool SideMenuVisible { get; set; } = false;

        public ApplicationPage SideMenuContent { get; set; } = ApplicationPage.DirectoryPage;

    }
}
