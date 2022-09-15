/*
Let suppose you have 2 entities, Items and company. One company can have many items,One item can belong to many comapnies.
*/

public class Item: FullAuditModel
{
public string Name { get; set; }
 public int Quantity { get; set; }
 public string Description { get; set; }
 public decimal? PurchasePrice { get; set; }
public virtual List<Company> Companies { get; set; } = new List<Company>();
}
