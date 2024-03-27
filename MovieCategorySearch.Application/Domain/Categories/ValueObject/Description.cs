namespace MovieCategorySearch.Application.Domain.Categories.ValueObject
{
    public sealed class Description
    {
        private readonly string _value;

        public Description(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("説明が未入力です");
            }
            if (value.Length > 100)
            {
                throw new ArgumentException("カテゴリ名は100文字以内で入力してください");
            }
            _value = value;
        }
        public string Value => _value;
    }
}
