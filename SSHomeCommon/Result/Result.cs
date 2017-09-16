using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeDatalayerCommon;

namespace SSHomeCommon
{
    public class Result<T>
    {
        #region Private Members

        private List<ResultError> _errors = new List<ResultError>();

        #endregion Private Members



        #region Properties


        public ResultStatus Status { get; set; }

        //public string Message { get; set; }

        public T Model { get; set; }

        public List<ResultError> Errors { get { return _errors; } }


        #endregion Properties



        #region Constructor

        // default empty constructor
        public Result()
        {
        }

        // constructor that takes in default status i.e true for no validation required at all
        public Result(ResultStatus status)
        {
            Status = status;
        }

        #endregion Constructor



        #region Public methods


        public Result<T> AddModelError(Exception ex)
        {
            this._errors.Add(new ResultError
            {
                Property = string.Empty,
                Exception = ex.Message
            });

            return this;
        }

        public Result<T> AddModelError(string propertyName, string message)
        {
            this._errors.Add(new ResultError
            {
                Property = string.Empty,
                Exception = message
            });

            return this;
        }

        public Result<T> AddModelError(string propertyName, string errorCode, string message)
        {
            this._errors.Add(new ResultError
            {
                Property = string.Empty,
                Exception = message
            });

            return this;
        }

        public Result<T> AddModelError(ResultError error)
        {
            this._errors.Add(error);
            return this;
        }


        #endregion Public methods
    }


    /// <summary>
    ///
    /// </summary>
    /// <remarks></remarks>
    public class ResultError
    {
        public string errorCode { get; set; }

        public string Property { get; set; }

        public string Exception { get; set; }
    }
}