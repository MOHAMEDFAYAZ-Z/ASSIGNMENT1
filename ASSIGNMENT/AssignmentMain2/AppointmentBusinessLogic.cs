using System;

public partial class Appointment
{
    public void Display()
    {
        Console.WriteLine($"{AppointmentId} {PatientName} {Department} {Status} {AppointmentDate.ToShortDateString()} {ConsultationFee}");
    }
}