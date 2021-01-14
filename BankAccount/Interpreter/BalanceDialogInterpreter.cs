using System;
using BankAccount.Implementations;
using BankAccount.Interface;

namespace BankAccount.Interpreter
{
	public class BalanceDialogInterpreter : AbstractDialogInterpreter
	{
		
		public BalanceDialogInterpreter(IBanker banker, IDialogConsole dialogConsole) : base(banker, dialogConsole)
		{
		}

		public override void StartDialogWithBanker(Account account)
		{
			ExecuteActionOnAccount(account);
		}

		public override void ExecuteActionOnAccount(Account account)
		{
			DisplayBalance(account);
		}
	}
}
