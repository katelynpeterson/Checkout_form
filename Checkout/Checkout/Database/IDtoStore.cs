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
        void AddCustomer(CustomerDTO c);
        IEnumerable<CustomerDTO> GetAllCustomers();
        void AddProduct(ProductDTO p);
        IEnumerable<ProductDTO> GetAllProducts();
    }
}
