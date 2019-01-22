using System;
using System.Text.RegularExpressions;

namespace PrimitiveAndMessageObsession.PrimitiveObsession
{
	public class PrimitiveCustomer
	{
		private const string EmailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		                                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

		public string Name { get; private set; }
		public int Age { get; private set; }
		public string Email { get; private set; }

		public PrimitiveCustomer(string name, int age, string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentNullException("Email cannot be empty.");
			if (!Regex.IsMatch(email, EmailRegex, RegexOptions.IgnoreCase))
				throw new ArgumentException("Email is not in a valid format.");
			if (age < 0)
				throw new ArgumentException("Age cannot be negative number.");
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("Name cannot be empty.");
			if (name.Length < 5)
				throw new ArgumentException("Name must be longer than 5 characters.");

			Name = name;
			Age = age;
			Email = email;
		}

		public void ChangeEmail(string newEmail)
		{
			if (string.IsNullOrWhiteSpace(newEmail))
				throw new ArgumentNullException("Email cannot be empty.");
			if (!Regex.IsMatch(newEmail, EmailRegex, RegexOptions.IgnoreCase))
				throw new ArgumentException("Email is not in a valid format.");

			Email = newEmail;
		}
	}
}