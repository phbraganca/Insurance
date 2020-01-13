using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Interfaces
{
    public interface ICustomer: IRepositoryBase<Customer>
    {
        bool CheckTaxIdentification(string cpf);
    }
}
