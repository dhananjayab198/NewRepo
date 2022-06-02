namespace shopApplicationapi.Models
{
    public class ShopItem
    {
        public int ShopItemID { get; set; }
        public string ShopItemName { get; set; } = string.Empty;

        public string ShopItemDescription { get; set; } = string.Empty;
        public int ShopItemPrice { get; set; }

        public string ShopItemModifiedBy { get; set; } = string.Empty;
        public DateTime? ShopItemModifiedDate { get; set; }
        public string ShopItemStatus { get; set; } = string.Empty;

    }
}
