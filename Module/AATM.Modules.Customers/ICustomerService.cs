using System.Collections.Generic;

namespace AATM.Modules.Customers
{
    /// <summary>
/// Defines a contract for the business logic related to customers.
/// This interface decouples the presenter from the service's implementation.
/// </summary>
    public interface ICustomerService
    {
        /// <summary>
    /// Gets a list of all customers.
    /// </summary>
    /// <returns>A list of CustomerDTO objects.</returns>
        List<CustomerDTO> GetCustomers();

        /// <summary>
    /// Saves a customer to the data store.
    /// This method handles both creating a new customer and updating an existing one.
    /// </summary>
    /// <param name="customer">The customer to be saved.</param>
    /// <returns>A ValidationResult indicating the outcome of the save operation.</returns>
        ValidationResult SaveCustomer(CustomerDTO customer);

        /// <summary>
    /// Deletes a customer from the data store by their ID.
    /// </summary>
    /// <param name="customerID">The ID of the customer to be deleted.</param>
    /// <returns>A ValidationResult indicating the outcome of the delete operation.</returns>
        ValidationResult DeleteCustomer(int customerID);

    }
}