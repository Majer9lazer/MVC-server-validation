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
            if (value is CallingCourier callingCourier)
            {
                FormOfPayment payment = _db.FormOfPayments.Find(callingCourier.FormOfPaymentId);
                if (payment == null || !payment.Name.Contains("Договор"))
                {
                    if (callingCourier.WhenPickUpShipment.Hours < 8 ||
                        (callingCourier.WhenPickUpShipment.Hours > 22 || callingCourier.WhenPickUpShipment.Minutes > 0))
                    {
                        ErrorMessage = "Курьер может забрать посылку только с 8:00 до 22:00ы";
                        return false;
                    }
                }

                if (_db.DepartureTypes.Find(callingCourier.DepartureTypeId).DepartureTypeName.Contains("Термогруз"))
                {
                    int[] almatyAndAstanaIdArray = _db.Cities.Where(w => w.CityName.Contains("Алматы") || w.CityName.Contains("Астана")).Select(s => s.CityId).ToArray();
                    if (!almatyAndAstanaIdArray.Contains(callingCourier.CityId))
                    {
                        ErrorMessage = "Тип отправления», выбранное как «Термогруз», доступно только для городов – Алматы, Астана";
                        return false;
                    }
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