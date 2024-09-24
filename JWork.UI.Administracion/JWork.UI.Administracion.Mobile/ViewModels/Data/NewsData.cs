/* [grial-metadata] id: Grial#NewsData.cs version: 1.0.1 */
namespace JWork.UI.Administracion.Mobile
{

    public class NewsTopicData
    {
        public string? Image { get; set; }
        public string? SectionTitle { get; set; }
        public string? NewsCount { get; set; }
        public string? When { get; set; }
    }

    public class NewsMembershipPlan
    {
        public required string Name { get; set; }
        public required string Price { get; set; }
        public required string Description { get; set; }
        public bool IsRecommended { get; set; }
    }

}
