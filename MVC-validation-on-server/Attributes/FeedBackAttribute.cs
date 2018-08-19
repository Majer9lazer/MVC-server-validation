using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_validation_on_server.Models;

namespace MVC_validation_on_server.Attributes
{
    public class FeedBackAttribute : ValidationAttribute
    {
        private ServerValidation_DbEntities _db = new ServerValidation_DbEntities();
        public override bool IsValid(object value)
        {
            if (value is Feedback feedback)
            {
                MessageTheme complaintsAndSuggestions =
                    _db.MessageThemes.FirstOrDefault(f => f.ThemeName.Contains("Жалобы и предложения"));
                if (complaintsAndSuggestions?.MessageThemeId == feedback.MessageThemeId) return true;
                if (string.IsNullOrEmpty(feedback.Name))
                {
                    ErrorMessage = $"Поле Name должно быть заполнено.";
                    return false;
                }

                return true;
            }
            else
            {
                ErrorMessage = "Не удалось преобразоват объект к типу \'Feedback\'";
                return false;

            }

        }
    }
}