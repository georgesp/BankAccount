using System.Collections.Generic;
using BankAccount.Implementations;
using BankAccount.Tools;

namespace BankAccount.Interface
{
	public interface ICommandInterpreter
	{
		List<ActionEnum> GetAvailableActions();

		void ExecuteAction(string input, Account account);
	}
}
