using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_validation_on_server.Models;

namespace MVC_validation_on_server.Attributes
{
    public class CallingCourierAttribute : ValidationAttribute
    {
        private readonly ServerValidation_DbEntities _db = new ServerValidation_DbEntities();
        public override bool IsValid(object value)
        {
            if (value is CallingCourier feedback)
            {

                return true;
            }
            else
            {
                ErrorMessage = "Не удалось преобразоват объект к типу \'Feedback\'";
                return false;

            }
        }
    }