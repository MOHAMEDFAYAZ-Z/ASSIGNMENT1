using System;

public partial class Appointment
{
    public bool Validate()
    {
        return !string.IsNullOrEmpty(PatientName) &&
               !string.IsNullOrEmpty(Department) &&
               ConsultationFee > 0;
    }
}