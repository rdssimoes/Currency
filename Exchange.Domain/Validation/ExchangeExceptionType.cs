namespace Exchange.Domain
{
    public class ExchangeExceptionType
    {
        #region [ Constructor ]

        public ExchangeExceptionType(string erroCode, string message)
        {
            _erroCode = erroCode;
            _message = message;
        }

        #endregion

        #region [ Members ]

        readonly string _erroCode;
        readonly string _message;

        #endregion

        #region [ Properties ]

        public string ErroCode => _erroCode;

        public string Message => _message;

        #endregion
    }
}
