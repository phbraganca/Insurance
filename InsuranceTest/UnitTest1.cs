using Insurance.Domain.Interfaces;
using Insurance.Domain.Models;
using InsuranceWebAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace InsuranceTest
{
    public class InsuranceTest
    {

        private Mock<ICustomer> mock;
        private CustomerController controller;

        private static Address address = new Address()
        {
            AddressId = 1,
            AdressType = new AdressType()
            {
                AddressTypeId = 1,
                Description = "Residencial"
            },
            City = new City()
            {
                CityId = 12,
                Name = "Rio de Janeiro",
                State = new State()
                {
                    StateId = 2,
                    Name = "RJ",
                    Country = new Country()
                    {
                        CountryId = 1,
                        Name = "Brasil"
                    },
                },
            },
            Neighborhood = "Copacabana",
            Street = "Av. Nossa Senhora de Copacabana"

        };

        [Fact]
        public void Setup()
        {
            this.mock = new Mock<ICustomer>();
            this.controller = new CustomerController(mock.Object);
        }

        [Fact]
        public void DeveRetornarNullCasoNaoAcheOCliente()
        {
            var obj = new Customer()
            {
                CustomerId = It.IsIn<Int32>()
            };

            this.mock.Setup(x => x.Get(obj))
                .Returns(obj);

            var result = this.controller.Get(-1);

            Assert.Null(result);
        }

        [Fact]
        public void DeveRetornarOkCasoAcheOCliente()
        {
            var obj = new Customer()
            {
                CustomerId = It.IsIn<Int32>()
            };

            mock.Setup(p => p.Get(obj)).Returns(obj);
            
            string result = this.controller.Get(obj.CustomerId).Name;
            Assert.Equal("Joao da Silva", result);            
        }

        [Fact]
        public void DeveRetornarOkParaTodosOsClientes()
        {

            

            var lista = new List<Customer>()
            {
                new Customer()
                {
                    CustomerId = 10,
                    Name = "Joao da Silva",
                    TaxIdentification = "12334566777",
                    Address = new List<Address>(){ address },
                    Age = 15,
                    DateOfBith = DateTime.Today
                },
                 new Customer()
                {
                    CustomerId = 10,
                    Name = "Pedro Braganca",
                    TaxIdentification = "12334566777",
                    Address = new List<Address>(){ address },
                    Age = 15,
                    DateOfBith = DateTime.Today
                },
            };

            this.mock.Setup(x => x.GetAll(new Customer()))
                .Returns(new List<Customer>(lista));

            var result = this.controller.GetAll();            
                       
            Assert.Equal(lista, result);

        }

        [Fact]
        public void DeveRetornarOKParaInsercao()
        {
            var cust = new Customer()
            {
                CustomerId = 11,
                Name = "Peter Parker",
                TaxIdentification = "12334566777",
                Address = new List<Address>() { address },
                Age = 15,
                DateOfBith = DateTime.Today
            };

            this.mock.Setup(x => x.Save(cust));                

            var result = this.controller.Get(cust.CustomerId);

            Assert.Equal(cust, result);
        }

    }
}
