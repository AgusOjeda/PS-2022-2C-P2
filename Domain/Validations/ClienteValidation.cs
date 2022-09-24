using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class ClienteValidation
    {
        public static string AskForString(string message)
        {
            bool valid = true;
            Console.Write(message);
            string name = Console.ReadLine();
            while(ValidateStringInput(name))
            {
                Console.WriteLine("El dato ingresado no es valido, intente nuevamente:");
                name = Console.ReadLine();
            }
            return name;
        }
        public static string AskForDni(string message)
        {
            bool valid = true;
            Console.Write(message);
            string dni = Console.ReadLine();
            while (ValidateNumberInput(dni))
            {
                Console.WriteLine("El dato ingresado no es valido:");
                dni = Console.ReadLine();
            }
            return dni;
        }
        public static string AskForPhoneNumber(string message)
        {
            bool valid = true;
            Console.Write(message);
            string phoneNumber = Console.ReadLine();
            while (ValidateNumberInput(phoneNumber))
            {
                Console.WriteLine("El dato ingresado no es valido:");
                phoneNumber = Console.ReadLine();
            }
            return phoneNumber;
        }
        private static bool ValidateStringInput(String input)
        {
            Regex regex = new Regex(@"\d+");
            var result = regex.IsMatch(input);
            return result;
        }
        private static bool ValidateNumberInput(String input)
        {
            Regex regex = new Regex(@"[a-zA-Z_'¡´+{ñ´,.\s]");
            var result = regex.IsMatch(input);
            return result;
        }
    }
}
