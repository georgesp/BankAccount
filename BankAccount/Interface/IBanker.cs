using BankAccount.Implementations;
using System.Collections.Generic;

namespace BankAccount.Interface
{
	public interface IBanker
	{
		Account CreateAccount(string client);

		void Withdraw(Account account, decimal amount, string operationName = null);

		void Deposit(Account account, decimal amount, string operationName = null);

		decimal GetAmount(Account account);

		List<Operation> GetOperations(Account account);
	}
}
