namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appointment> appointments = new List<Appointment>
        {
            new Appointment
            {
                AppointmentId = 1,
                PatientName = "Fayaz",
                Department = "Cardiology",
                Status = "Scheduled",
                AppointmentDate = DateTime.Now.AddDays(2),
                ConsultationFee = 700
            },
            new Appointment
            {
                AppointmentId = 2,
                PatientName = "Rahul",
                Department = "Neurology",
                Status = "Completed",
                AppointmentDate = DateTime.Now.AddDays(-2),
                ConsultationFee = 900
            },
            new Appointment
            {
                AppointmentId = 3,
                PatientName = "Arun",
                Department = "Cardiology",
                Status = "Completed",
                AppointmentDate = DateTime.Now.AddDays(-1),
                ConsultationFee = 600
            },
            new Appointment
            {
                AppointmentId = 4,
                PatientName = "Kumar",
                Department = "Orthopedics",
                Status = "Scheduled",
                AppointmentDate = DateTime.Now.AddDays(5),
                ConsultationFee = 400
            }
        };

            Console.WriteLine("All Appointments");
            appointments.ForEach(a => a.Display());

            Console.WriteLine("\nScheduled Appointments");
            appointments.Where(a => a.Status == "Scheduled")
                        .ToList()
                        .ForEach(a => a.Display());

            Console.WriteLine("\nCompleted Appointments");
            appointments.Where(a => a.Status == "Completed")
                        .ToList()
                        .ForEach(a => a.Display());

            Console.WriteLine("\nCardiology Appointments");
            appointments.Where(a => a.Department == "Cardiology")
                        .ToList()
                        .ForEach(a => a.Display());

            Console.WriteLine("\nConsultation Fee > 500");
            appointments.Where(a => a.ConsultationFee > 500)
                        .ToList()
                        .ForEach(a => a.Display());

            Console.WriteLine("\nSorted By Appointment Date");
            appointments.OrderBy(a => a.AppointmentDate)
                        .ToList()
                        .ForEach(a => a.Display());

            Console.WriteLine("\nSearch By Patient Name");
            appointments.Where(a => a.PatientName.Contains("Fayaz"))
                        .ToList()
                        .ForEach(a => a.Display());

            Console.WriteLine("\nGroup By Department");
            var deptGroup = appointments.GroupBy(a => a.Department);

            foreach (var group in deptGroup)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                    item.Display();
            }

            Console.WriteLine("\nCount By Status");
            var statusCount = appointments.GroupBy(a => a.Status)
                                          .Select(g => new
                                          {
                                              Status = g.Key,
                                              Count = g.Count()
                                          });

            foreach (var item in statusCount)
                Console.WriteLine($"{item.Status} : {item.Count}");

            Console.WriteLine("\nTotal Revenue From Completed Appointments");
            Console.WriteLine(
                appointments.Where(a => a.Status == "Completed")
                            .Sum(a => a.ConsultationFee));

            Console.WriteLine("\nAverage Consultation Fee");
            Console.WriteLine(
                appointments.Average(a => a.ConsultationFee));

            Console.WriteLine("\nUpcoming Appointments");
            appointments.Where(a => a.AppointmentDate > DateTime.Now)
                        .ToList()
                        .ForEach(a => a.Display());
        }
    }
}
