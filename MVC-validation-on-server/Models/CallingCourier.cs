//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_validation_on_server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CallingCourier
    {
        public int CallingCourierId { get; set; }
        public string BIN_IIN { get; set; }
        public string ContactPerson { get; set; }
        public string SendersAddress { get; set; }
        public string Email { get; set; }
        public System.DateTime DesirableDate { get; set; }
        public System.TimeSpan WhenPickUpShipment { get; set; }
        public int FormOfPaymentId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DepartureTypeId { get; set; }
        public int TariffsViewId { get; set; }
        public decimal Weight { get; set; }
    
        public virtual FormOfPayment FormOfPayment { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual DepartureType DepartureType { get; set; }
        public virtual TariffsView TariffsView { get; set; }
    }
}
