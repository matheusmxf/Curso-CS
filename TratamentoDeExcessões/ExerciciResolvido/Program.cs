using System;
using Course.Entities;
using Course.Entities.Exceptions;

namespace Course
{
    class Program
    {
        static void Main1(string[] args)
        {
            try{
                System.Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine()!);
                System.Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine()!);
                System.Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine()!);

                
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                System.Console.WriteLine("Reservation: " + reservation);
                
                System.Console.WriteLine();
                System.Console.WriteLine("Enter date to update the reservation: ");
                checkIn = DateTime.Parse(Console.ReadLine()!);
                System.Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine()!);
    
                reservation.UpdateDates(checkIn, checkOut);
                System.Console.WriteLine("Reservation" + reservation);
            }
            catch (DomainException e)
            {
                System.Console.WriteLine("Error in reservation: " + e.Message);
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Format error: " +e.Message);
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}