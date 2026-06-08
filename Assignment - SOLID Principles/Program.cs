using SmartCourierApp.Models;
using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Notifications;
using SmartCourierApp.Invoices;
using SmartCourierApp.Services;

Customer customer = new Customer();

Console.Write("Customer Name : ");
customer.Name = Console.ReadLine();

Console.Write("Email : ");
customer.Email = Console.ReadLine();

Console.Write("Mobile : ");
customer.MobileNumber = Console.ReadLine();

Parcel parcel = new Parcel();

Console.Write("Weight : ");
parcel.Weight = Convert.ToDouble(Console.ReadLine());

Console.Write("Source City : ");
parcel.SourceCity = Console.ReadLine();

Console.Write("Destination City : ");
parcel.DestinationCity = Console.ReadLine();

Console.Write("Delivery Type : ");
string deliveryType = Console.ReadLine();

Console.Write("Notification Type : ");
string notificationType = Console.ReadLine();

CourierBooking booking = new CourierBooking
{
    Customer = customer,
    Parcel = parcel,
    DeliveryType = deliveryType,
    NotificationType = notificationType
};

IDeliveryChargeCalculator calculator;

if (deliveryType == "Standard")
{
    calculator = new StandardDeliveryCalculator();
}
else if (deliveryType == "Express")
{
    calculator = new ExpressDeliveryCalculator();
}
else
{
    calculator = new InternationalDeliveryCalculator();
}

INotificationService notificationService;

if (notificationType == "Email")
{
    notificationService = new EmailNotificationService();
}
else if (notificationType == "SMS")
{
    notificationService = new SmsNotificationService();
}
else
{
    notificationService = new WhatsAppNotificationService();
}

IInvoiceGenerator invoiceGenerator =
    new ConsoleInvoiceGenerator();

CourierBookingService service =
    new CourierBookingService(
        calculator,
        notificationService,
        invoiceGenerator);

service.BookCourier(booking);