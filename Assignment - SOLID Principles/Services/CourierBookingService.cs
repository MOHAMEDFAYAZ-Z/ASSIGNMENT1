using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Invoices;
using SmartCourierApp.Models;
using SmartCourierApp.Notifications;

namespace SmartCourierApp.Services
{
    public class CourierBookingService
    {
        private readonly IDeliveryChargeCalculator calculator;
        private readonly INotificationService notificationService;
        private readonly IInvoiceGenerator invoiceGenerator;

        public CourierBookingService(
            IDeliveryChargeCalculator calculator,
            INotificationService notificationService,
            IInvoiceGenerator invoiceGenerator)
        {
            this.calculator = calculator;
            this.notificationService = notificationService;
            this.invoiceGenerator = invoiceGenerator;
        }

        public void BookCourier(CourierBooking booking)
        {
            double charge =
                calculator.CalculateCharge(
                    booking.Parcel.Weight);

            notificationService.SendNotification(
                "Courier Booked Successfully");

            invoiceGenerator.GenerateInvoice(
                booking,
                charge);
        }
    }
}