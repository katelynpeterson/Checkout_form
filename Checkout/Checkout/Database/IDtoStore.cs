using Checkout.Database.DTO;
using Checkout.VMs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Database
{
    public interface IDtoStore
    {
        void AddLog(LogDTO l);
        void AddCustomer(CustomerDTO c);
        void UpdateCustomer(CustomerDTO c);
        IEnumerable<CustomerDTO> GetAllCustomers();
        IEnumerable<CustomerDTO> GetCustomerByEmail(string email);
        void AddProduct(ProductDTO p);
        IEnumerable<ProductDTO> GetAllProducts();
    }
}
