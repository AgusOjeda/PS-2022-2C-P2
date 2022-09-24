using Application.Interfaces;
using Application.Response;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Menu
{
    public class CustomerMenu
    {
        private readonly IClienteService _customerServices;

        public CustomerMenu(IClienteService customerServices)
        {
            _customerServices = customerServices;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Menu Gestion de Clientes");
            Console.WriteLine("1. Añadir cliente");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    var success = true;
                    while (success)
                    {
                        Console.Clear();
                        success = AddCustomer().Result;
                        Console.WriteLine("Desea agregar otro cliente? n para no, pulse cualquier tecla para continuar ingresando clientes...");
                        string? answer = Console.ReadLine().ToLower();
                        if (answer == "n")
                        {
                            success = false;
                        }
                    }
                    break;
                case 7:
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        }

        private async Task<bool> AddCustomer()
        {
            var response = await _customerServices.CreateCustomer();
            if (response != null)
            {
                Console.Clear();
                Console.WriteLine("Cliente creado exitosamente");
                Console.WriteLine("Id: {0}\nNombre Completo: {1} {2}\n Dni: {3}\nTelefono: {4}\nDireccion: {5}", response.ClienteId, response.Nombre, response.Apellido, response.DNI, response.Telefono, response.Direccion);
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
