// In conetxt of code first:
// Let suppose there are 2 entites (category and item) have one to many relationship. i.e., One category has many items.

public class Category : FullAuditModel
{
      public string Name { get; set; }
      public virtual List<Item> Items { get; set; } = new List<Item>();          //because one category has many items.

}
