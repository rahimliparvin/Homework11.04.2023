namespace FronttoBack.Models
{
    public class Slider : BaseEntity
    {
        public string? Image { get; set; }

        public ICollection<SliderInfo> Infos { get; set; }


    }
}
