using System.Collections.Generic;
using System.Linq;

namespace BankAccount.Implementations
{
	public class Account
	{
		private List<Operation> _operations;

		public string Owner { get; set; }

		public Account(string owner)
		{
			Owner = owner;
			_operations = new List<Operation>();
		}

		public void AddOperation(Operation operation)
		{
			_operations.Add(operation);
		}

		public decimal GetAmount()
		{
			return _operations.Sum(o => o.Amount);
		}

		public List<Operation> GetOperations()
		{
			return _operations;
		}
	}
}
