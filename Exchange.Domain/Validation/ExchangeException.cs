using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Domain.Validation
{
    public class ExchangeException : Exception
    {
        #region [ Constructor ]

        /// <summary>
        /// Construtor
        /// </summary>
        public ExchangeException(string message)
            : base(message)
        {
            _exceptions = new List<ExchangeExceptionType>();
            _exceptions.Add(new ExchangeExceptionType(ErrorCode.AWE000_UnexpectedError, message));
            _exceptionMessage = message;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public ExchangeException(IList<string> messages, string exceptionCode)
        {
            _exceptionCode = exceptionCode;
            _exceptionMessage = ConvertValidationToString(messages);
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public ExchangeException(string message, string exceptionCode)
            : base(message)
        {
            _exceptions = new List<ExchangeExceptionType>();
            _exceptions.Add(new ExchangeExceptionType(exceptionCode, message));
            _exceptionCode = exceptionCode;
            _exceptionMessage = message;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public ExchangeException(string message, Exception innerException)
            : base(message, innerException)
        {
            _exceptions = new List<ExchangeExceptionType>();
            _exceptions.Add(new ExchangeExceptionType(ErrorCode.AWE000_UnexpectedError, message));
            _exceptionMessage = message;
        }

        public ExchangeException(IList<ExchangeExceptionType> exceptions)
        {
            _exceptions = exceptions.ToList();
            _exceptionMessage = ConvertValidationToString(exceptions);
        }

        public ExchangeException(ExchangeExceptionType exception)
        {
            _exceptions = new List<ExchangeExceptionType>();
            _exceptions.Add(exception);
            _exceptionMessage = ConvertValidationToString(_exceptions);
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="ex">Exceção</param>
        public ExchangeException(Exception ex)
            : base(ex.Message, ex)
        {
            _exceptionMessage = ex.Message;
        }

        #endregion

        #region [ Members ]

        private readonly String _exceptionCode;
        private readonly string _exceptionMessage;
        private readonly List<ExchangeExceptionType> _exceptions;

        #endregion

        #region [ Properties ]

        public string ExceptionCode => _exceptionCode;

        public string ExceptionMessage => _exceptionMessage;

        public List<ExchangeExceptionType> Exceptions => _exceptions;

        #endregion

        #region [ Methods ]

        private string ConvertValidationToString(IList<string> errors)
        {
            string error = string.Empty;
            if (errors != null)
            {
                StringBuilder sbu = new StringBuilder();
                foreach (var item in errors)
                {
                    sbu.AppendLine(item);
                }
                error = sbu.ToString();
            }
            return error;
        }

        private string ConvertValidationToString(IList<ExchangeExceptionType> errors)
        {
            string error = string.Empty;
            if (errors != null)
            {
                StringBuilder sbu = new StringBuilder();
                foreach (var item in errors)
                {
                    sbu.AppendLine(item.Message);
                }
                error = sbu.ToString();
            }
            return error;
        }

        #endregion
    }
}