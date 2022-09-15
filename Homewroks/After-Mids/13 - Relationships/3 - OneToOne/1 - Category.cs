public class Category : FullAuditModel
{
public string Name { get; set; }
public virtual CategoryDetail CategoryDetail { get; set; }
}
