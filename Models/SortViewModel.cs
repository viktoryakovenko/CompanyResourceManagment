namespace Company.Models
{
    public enum SortState
    {
        NameAsc,
        NameDesc,  
        SurnameAsc,
        SurnameDesc,
        AgeAsc,
        AgeDesc,
        DepartmentAsc,
        DepartmentDesc
    }

    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState SurnameSort { get; private set; } 
        public SortState AgeSort { get; private set; }
        public SortState DepartmentSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            SurnameSort = sortOrder == SortState.SurnameAsc ? SortState.SurnameDesc : SortState.SurnameAsc;
            DepartmentSort = sortOrder == SortState.DepartmentAsc ? SortState.DepartmentDesc : SortState.DepartmentAsc;
            Current = sortOrder;
        }
    }
}
