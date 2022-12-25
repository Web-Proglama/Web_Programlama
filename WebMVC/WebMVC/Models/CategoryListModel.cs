namespace WebMVC.Models
{
    public class CategoryListModel
    {
        public string CategoryID { get; set; }
        public string  CategoryName { get; set; }
        public List<CategoryViewModel> CategoryList { get; set; }
    }
}
