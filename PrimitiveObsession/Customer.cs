using System;
using System.Text.RegularExpressions;

namespace PrimitiveAndMessageObsession.PrimitiveObsession
{
    // Value Object
    public class Customer  
	{
		public Customer(Name name, Age age, Email email)
		{
			Name = name;
			Age = age;
			Email = email;
		}

		public Name Name { get; }
		public Age Age { get; }
		public Email Email { get; }
	}

    // Value Object
    public class Email 
	{
		private readonly string _email;

		private Email(string email)
		{
			_email = email;
		}

		public static Email Create(string email)
		{
			const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
			                          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentNullException("Email cannot be empty.");
			if (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
				throw new ArgumentException("Email is not in a valid format.");

			return new Email(email);
		}

		public override string ToString()
		{
			return _email;
		}

		public override bool Equals(object obj)
		{
			var email = obj as Email;
			if (ReferenceEquals(obj, null)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;

			return email != null && this._email.Equals(email._email);
		}

		public override int GetHashCode()
		{
			return _email.GetHashCode();
		}

		public static implicit operator string(Email email)
		{
			return email._email;
		}

		public static explicit operator Email(string email)
		{
            // bug is introduced
            // it should call Create() method because that method validates email before it is created
			return new Email(email);
		}
	}

    // Value Object
	public class Age
	{
		private readonly int _age;

		private Age(int age)
		{
			_age = age;
		}

		public static Age Create(int age)
		{
			if (age < 0)
				throw new ArgumentException("Age cannot be negative number.");

			return new Age(age);
		}

		public override string ToString()
		{
			return _age.ToString();
		}

		public override bool Equals(object obj)
		{
			var age = obj as Age;
			if (ReferenceEquals(obj, null)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;

			return age != null && this._age.Equals(age._age);
		}

		public override int GetHashCode()
		{
			return _age.GetHashCode();
		}
	}

    // Value Object
	public class Name
	{
		private readonly string _name;

		private Name(string name)
		{
			_name = name;
		}

		public static Name Create(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("Name cannot be empty.");
			if (name.Length < 5)
				throw new ArgumentException("Name must be longer than 5 characters.");

			return new Name(name);
		}

		public override string ToString()
		{
			return _name;
		}

		public override bool Equals(object obj)
		{
			var name = obj as Name;
			if (ReferenceEquals(obj, null)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;

			return name != null && this._name.Equals(name._name);
		}

		public override int GetHashCode()
		{
			return _name.GetHashCode();
		}
	}
}