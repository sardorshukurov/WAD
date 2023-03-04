﻿using System;

namespace BookStoreAPI.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
