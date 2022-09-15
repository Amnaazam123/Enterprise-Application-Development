public class Item: FullAuditModel
{

      public string Name { get; set; }
      public int Quantity { get; set; }
      public string Description { get; set; }
      public decimal? PurchasePrice { get; set; }
      public int? CategoryId { get; set; } 
      public virtual Category Category { get; set; }       //each item belongs to one category.
 
}

/*
Now instead of writing inner join queries, you will just write following line of code
and will get all items with their corresponding categories.

_context.Categories.Items.ToList();

*/
