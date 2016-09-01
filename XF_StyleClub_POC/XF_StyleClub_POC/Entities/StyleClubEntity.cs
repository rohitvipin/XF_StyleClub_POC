using Xamarin.Forms;

namespace XF_StyleClub_POC.Entities
{
    public class StyleClubEntity: BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ImageSource ImageSource { get; set; }
    }
}
