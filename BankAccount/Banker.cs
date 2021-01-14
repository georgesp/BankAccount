using System.Collections.Generic;
using BankAccount.Implementations;
using BankAccount.Interface;

namespace BankAccount
{
	public class Banker : IBanker
	{
		public Account CreateAccount(string client)
		{
			return new Account(client);
		}

		public void Deposit(Account account, decimal amount, string operationName = null)
		{
			Operation operation = new Operation(operationName, amount);
			account.AddOperation(operation);
		}

		public void Withdraw(Account account, decimal amount, string operationName = null)
		{
			Operation operation = new Operation(operationName, -amount);
			account.AddOperation(operation);
		}

		public decimal GetAmount(Account account)
		{
			return account.GetAmount();
		}

		public List<Operation> GetOperations(Account account)
		{
			return account.GetOperations();
		}
	}
}
