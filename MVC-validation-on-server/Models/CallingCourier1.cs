using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_validation_on_server.Attributes;

namespace MVC_validation_on_server.Models
{
    [CallingCourier]
    public class CallingCourier
    {
        public int CallingCourierId { get; set; }
        [DisplayName("ИИН/БИН")]
        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "длина поля должна равняться 12")]
        public string BIN_IIN { get; set; }
        [Required]
        public string ContactPerson { get; set; }
        [Required]
        public string SendersAddress { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public System.DateTime DesirableDate { get; set; }
        [Required]
        public System.TimeSpan WhenPickUpShipment { get; set; }
        [Required]
        public int FormOfPaymentId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int DepartureTypeId { get; set; }
        [Required]
        public int TariffsViewId { get; set; }
        [Required]
        public decimal Weight { get; set; }

        public virtual FormOfPayment FormOfPayment { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual DepartureType DepartureType { get; set; }
        public virtual TariffsView TariffsView { get; set; }
    }
}