﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.ExceptionHandler
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            : base("One or more validation errors have occured")
        {
            Errors = new Dictionary<string, string[]>();

        }

        //will handle errors from our custom validation using fluent valiidation
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {

            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }

    }
}
