using System;
using System.Text.RegularExpressions;

namespace PrimitiveAndMessageObsession.PrimitiveObsession
{
	public class DummyService
	{
		public void SaveCustomer(string name, int age, string email)
		{
			var customer = new PrimitiveCustomer(name, age, email);
			var newEmail = "something@gmail.com";
			customer.ChangeEmail(newEmail);

			// save customer in database ...
		}

		public void SaveCustomer(Customer customer)
		{
			var newEmail = Email.Create("someemail@gmail.com");
			newEmail = (Email)"someotheremail@gmail.com";  // explicit operator - this will break encapsulation as it will allow us to create Email instance bypassing the Create method. 
			string email = customer.Email; // implicit operator

			Console.WriteLine($"Customer email: {customer.Email}"); // ToString method

			// save customer in database ...
		}
	}
}