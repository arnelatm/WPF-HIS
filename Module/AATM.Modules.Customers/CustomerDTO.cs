using System;

namespace AATM.Modules.Customers
{
    /// <summary>
/// A simple Data Transfer Object for carrying customer data between layers.
/// </summary>
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }

    }
}