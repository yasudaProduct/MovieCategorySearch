namespace MovieCategorySearch.Application.Domain.Categorys.ValueObject
{
    public sealed class CategoryName
    {
        private readonly string _value;

        public CategoryName(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("カテゴリ名が未入力です");
            }
            if (value.Length > 30)
            {
                throw new ArgumentException("カテゴリ名は50文字以内で入力してください");
            }
            _value = value;
        }

        public string Value => _value;
    }
}
