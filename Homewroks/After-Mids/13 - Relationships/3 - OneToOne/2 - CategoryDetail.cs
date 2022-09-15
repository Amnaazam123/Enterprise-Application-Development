/*
In this case you do not need to explicitly add FK coloumn. You will see correspondance of PK of one cloumn to PK of other coloumn.

*/
public class CategoryDetail : IIdentityModel
{

[Key, ForeignKey("Category")]
[Required]
public int Id { get; set; }


public string ColorValue { get; set; }
public string ColorName { get; set; }
public virtual Category Category { get; set; }
}
