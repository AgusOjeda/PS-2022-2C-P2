using Application.Interfaces;
using Application.Response;
using Domain.Dtos;
using Domain.Entities;
using Domain.Mappers;
using Domain.Models;
using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace Application.UseCase.Customers
{
    public class ClienteService : IClienteService
    {
        private readonly ICommandHandler<Cliente> _command;
        private readonly IClienteQuery _query;

        public ClienteService(ICommandHandler<Cliente> command, IClienteQuery query)
        {
            _command = command;
            _query = query;
        }

        
        public Task<ClienteDto> CreateCustomer()
        {
            try
            {
                string name = ClienteValidation.AskForString("Ingrese nombre: ");
                string lastName = ClienteValidation.AskForString("Ingrese apellido: ");
                string dni = ClienteValidation.AskForDni("Ingrese el DNI sin puntos: ");
                Console.Write("Ingrese la direccion: ");
                string address = Console.ReadLine();
                string phone = ClienteValidation.AskForPhoneNumber("Ingrese numero telefonico sin Codigo de area ni espacios: ");

                var customer = new Cliente
                {
                    DNI = dni,
                    Nombre = name,
                    Apellido = lastName,
                    Direccion = address,
                    Telefono = phone,
                };
                _command.Insert(customer);
                return Task.FromResult(ClienteMapper.MapCliente(customer));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error al registrar el cliente: " + ex.Message);
                return null;
            }
        }

        public ClienteDto GetCustomerByDni(string dni)
        {
            var customer = _query.GetCustomerByDni(dni);
            if(customer == null)
                return null;
            else
                return customer;

        }
    }
}
