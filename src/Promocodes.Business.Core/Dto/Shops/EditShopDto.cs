namespace Promocodes.Business.Core.Dto.Shops
{
    public class EditShopDto : IntegerIdentityDto, IDtoBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Site { get; set; }
    }
}
