using System;
using SmartCourierApp.Models;

namespace SmartCourierApp.Invoices
{
    public class ConsoleInvoiceGenerator : IInvoiceGenerator
    {
        public void GenerateInvoice(CourierBooking booking, double charge)
        {
            Console.WriteLine("\n------ INVOICE ------");

            Console.WriteLine("Customer : " + booking.Customer.Name);
            Console.WriteLine("Source : " + booking.Parcel.SourceCity);
            Console.WriteLine("Destination : " + booking.Parcel.DestinationCity);
            Console.WriteLine("Weight : " + booking.Parcel.Weight);
            Console.WriteLine("Delivery Type : " + booking.DeliveryType);
            Console.WriteLine("Total Charge : " + charge);

            Console.WriteLine("---------------------");
        }
    }
}