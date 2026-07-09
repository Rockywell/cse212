/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Include the 0 as max size to verify if the default value is used (10)
        // Expected Result: It must use 10 as the maxsize by default
        // Defect(s) Found: None
        Console.WriteLine("Test 1");

        var cs = new CustomerService(0);
        Console.WriteLine($"Max size should be 10: {cs}");


        Console.WriteLine("=================");

        // Test 2
        // Scenario: Include a customer 3 to a maxsize of 2
        // Expected Result: It must not allow this operation, only have 2 people in queue and display error message.
        // Defect(s) Found: I dected an error here if (_queue.Count > _maxSize), change this > for >=
        Console.WriteLine("Test 2");

        var service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine("Error message should be displayed above.");
        Console.WriteLine($"Should only have 2 people. Service Queue: {service}");


        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Can a customer properly be added then served?
        // Expected Result: This should display the customer that was just added and served.
        // Defect(s) Found: ServeCustomer does not return the served customer but the one after.
        Console.WriteLine("Test 3");

        service = new CustomerService(2);
        service.AddNewCustomer();
        service.ServeCustomer();
        Console.WriteLine("Should display the customer that was just added and served.");

        Console.WriteLine("=================");

        // Test 4
        // Scenario: As input include an ordered list of customers
        // Expected Result: Verify that the program maintains this order.
        // Defect(s) Found: None.
        Console.WriteLine("Test 4");

        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");



        Console.WriteLine("=================");

        // Test 5
        // Scenario: All orders were finished and there are no more customers on the queue. Try to call a customer on this scenario
        // Expected Result: An error message will be displayed
        // Defect(s) Found: There is nothing handling if the user has zero customers on the queue. Need to check the length of the queue.
        Console.WriteLine("Test 5");
        service = new CustomerService(5);
        service.ServeCustomer();
        Console.WriteLine("Should return an error message about no customers being present.");


        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {

        if (_queue.Count == 0)
        {
            // throw new CustomerServiceException("No Customers in Queue.");

            Console.WriteLine("No Customers in Queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}