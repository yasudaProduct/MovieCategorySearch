namespace MovieCategorySearch.Domain.User.ValueObject
{
    public class EmailAddress
    {

        private readonly string _value;

        public EmailAddress(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("メールアドレスが未入力です");
            }
            if (value.Length > 100)
            {
                throw new ArgumentException("メールアドレスは100文字以内で入力してください");
            }
            _value = value;
        }

        public string Value => _value;
    }
}
