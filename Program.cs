using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Clinic_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {

                

                    Console.WriteLine("\n Welcome to ABC Clinic\n ");
                    Console.WriteLine("Enter Choice: ");
                    Console.WriteLine("1. Doctor's Information ");
                    Console.WriteLine("2. Patient's Information ");


                    string input = Console.ReadLine();


                    if (input == "1")
                    {
                        while (true)
                        {
                            Console.WriteLine("\n Clinic Management System");
                            Console.WriteLine("1. Add Doctor");
                            Console.WriteLine("2. View Doctors");
                            Console.WriteLine("3. Update Doctor Info");
                            Console.WriteLine("4. Delete Doctor");
                            Console.WriteLine("5. Exit");

                            Console.Write("Enter your choice: ");
                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    AddDoctor(context);
                                    break;
                                case "2":
                                    ViewDoctors(context);
                                    break;
                                case "3":
                                    UpdateDoctor(context);
                                    break;
                                case "4":
                                    DeleteDoctor(context);
                                    break;
                                case "5":
                                    Console.WriteLine("Goodbye!");
                                    return;
                                default:
                                    Console.WriteLine("Invalid choice. Try again.");
                                    break;
                            }
                        }

                    }

                    else if (input == "2")
                    {
                        while (true)
                        {
                            Console.WriteLine("\n Clinic Management System");
                            Console.WriteLine("1. Add Patient");
                            Console.WriteLine("2. View patient");
                            Console.WriteLine("3. Update Patient Info");
                            Console.WriteLine("4. Delete Patient");
                            Console.WriteLine("5. Exit");

                            Console.Write("Enter your choice: ");
                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    AddPatient(context);
                                    break;
                                case "2":
                                    ViewPatient(context);
                                    break;
                                case "3":
                                    UpdatePatient(context);
                                    break;
                                case "4":
                                    DeletePatient(context);
                                    break;
                                case "5":
                                    Console.WriteLine("Goodbye!");
                                    return;
                                default:
                                    Console.WriteLine("Invalid choice. Try again.");
                                    break;
                            }
                        }
                    }

                
                    static void AddDoctor(AppDbContext context)
                    {
                        Console.Write("Enter Doctor Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Specialty: ");
                        string specialty = Console.ReadLine();

                        Console.Write("Enter Phone Number: ");
                        string phone = Console.ReadLine();

                        Console.Write("Enter Email Address : ");
                        string email = Console.ReadLine();

                        var doctor = new Doctor { Name = name, Specialization = specialty, Phone = phone, Email = email };
                        context.Doctors.Add(doctor);
                        context.SaveChanges();

                        Console.WriteLine(" Doctor added successfully!\n");
                    }

                static void AddPatient(AppDbContext context)
                {
                    Console.Write("Enter Patient's Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Age: ");
                    int age =Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Contact Number : ");
                    string phone = Console.ReadLine();

                    var patient = new Patient { PatientName = name, Age = age, ContactNumber = phone};
                    context.Patients.Add(patient);
                    context.SaveChanges();

                    Console.WriteLine("Patient added successfully!\n");
                }

                static void ViewDoctors(AppDbContext context)
                {
                    var doctors = context.Doctors.ToList();

                    if (doctors.Count == 0)
                    {
                        Console.WriteLine(" No doctors found.\n");
                        return;
                    }

                    Console.WriteLine("\n Doctor List:");
                    foreach (var doc in doctors)
                    {
                        Console.WriteLine($" ID: {doc.Id} |  Name: {doc.Name} |  Specialty: {doc.Specialization} |  Phone: {doc.Phone} | Email: {doc.Email}");
                    }
                    Console.WriteLine();
                }

                static void ViewPatient(AppDbContext context)
                {
                    var patient = context.Patients.ToList();

                    if (patient.Count == 0)
                    {
                        Console.WriteLine(" No patient found.\n");
                        return;
                    }

                    Console.WriteLine("\n {Patient} List:");
                    foreach (var doc in patient)
                    {
                        Console.WriteLine($" ID: {doc.PatientID} |  Name: {doc.PatientName} |Age : {doc.Age} | Contact NUmber: {doc.ContactNumber} ");
                    }
                    Console.WriteLine();
                }

                static void UpdateDoctor(AppDbContext context)
                {
                    Console.Write("Enter Doctor ID to update: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var doctor = context.Doctors.FirstOrDefault(d => d.Id == id);
                    if (doctor == null)
                    {
                        Console.WriteLine(" Doctor not found.\n");
                        return;
                    }

                    Console.Write("Enter new name (or press Enter to keep current): ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                        doctor.Name = name;

                    Console.Write("Enter new specialty (or press Enter to keep current): ");
                    string specialty = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(specialty))
                        doctor.Specialization = specialty;

                    Console.Write("Enter new phone (or press Enter to keep current): ");
                    string phone = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(phone))
                        doctor.Phone = phone;

                    Console.Write("Enter new email Address (or press Enter to keep current): ");
                    string email = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(email))
                        doctor.Email = email;

                    context.SaveChanges();
                    Console.WriteLine(" Doctor updated successfully!\n");
                }

                static void UpdatePatient(AppDbContext context)
                {
                    Console.Write("Enter Patient ID to update: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var patient = context.Patients.FirstOrDefault(d => d.PatientID== id);
                    if (patient == null)
                    {
                        Console.WriteLine(" Patient not found.\n");
                        return;
                    }

                    Console.Write("Enter new name (or press Enter to keep current): ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                        patient.PatientName = name;

                    Console.Write("Enter new age (or press Enter to keep current): ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    if (age>=0)
                        patient.Age = age;


                    Console.Write("Enter new Contact Number (or press Enter to keep current): ");
                    string contact = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(contact))
                        patient.ContactNumber = contact;

                    context.SaveChanges();
                    Console.WriteLine(" Patient's Information updated successfully!\n");
                }

                static void DeleteDoctor(AppDbContext context)
                {
                    Console.Write("Enter Doctor's ID to delete: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var doctor = context.Doctors.FirstOrDefault(d => d.Id == id);
                    if (doctor == null)
                    {
                        Console.WriteLine(" Doctor" + "not found.\n");
                        return;
                    }

                    context.Doctors.Remove(doctor);
                    context.SaveChanges();
                    Console.WriteLine(" Doctor deleted successfully.\n");
                }

                static void DeletePatient(AppDbContext context)
                {
                    Console.Write("Enter Pateint's ID to delete: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var patient = context.Patients.FirstOrDefault(d => d.PatientID == id);
                    if (patient == null)
                    {
                        Console.WriteLine(" Patient" + "not found.\n");
                        return;
                    }

                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    Console.WriteLine(" Patient deleted successfully.\n");
                }
            }
        }
    }
}
