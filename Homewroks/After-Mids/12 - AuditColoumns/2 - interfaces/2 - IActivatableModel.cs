/*
This interface class is created for soft delete.
SOFT DELETE : hm DB sy data permanently delete nai krty blky softly delete krty hen, So we make column "is Active" in table.
ye agr true ho tou mtlb delete nai hai, agr false hai tou mtlb wo row softly delete hai.

*/

public interface IActivatableModel
    {
        public bool IsActive { get; set; }
    }
