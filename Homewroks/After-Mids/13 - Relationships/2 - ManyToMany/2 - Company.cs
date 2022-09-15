public class Company : FullAuditModel
{
public string Name { get; set; }
public string Description { get; set; }
public virtual List<Item> Items { get; set; } = new List<Item>();
}
