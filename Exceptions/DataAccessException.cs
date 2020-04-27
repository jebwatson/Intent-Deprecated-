// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataAccessException.cs" company="Joint Systems Integration Laboratory">
//   Copyright © 2020 Joint Systems Integration Laboratory
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Intent.Exceptions
{
    public class DataAccessException : Exception, IDataAccessException
    {
    }

    public interface IDataAccessException
    {
    }
}