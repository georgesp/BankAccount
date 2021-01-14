using System;

namespace BankAccount.Implementations
{
	public class Operation
	{
		public Operation(string name, decimal amount)
		{
			Name = name;
			Amount = amount;
			Date = DateTime.Now;
		}
		public string Name { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }

		public override string ToString()
		{
			return $"[{Date.ToString("R")}] {Name} : {Amount} $";
		}
	}
}
