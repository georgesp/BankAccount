using System;
using BankAccount.Implementations;
using BankAccount.Interface;

namespace BankAccount.Interpreter
{
	public class DepositDialogInterpreter : AbstractDialogInterpreter
	{
		
		public DepositDialogInterpreter(IBanker banker, IDialogConsole dialogConsole) : base(banker, dialogConsole)
		{
		}

		public override void StartDialogWithBanker(Account account)
		{
			DialogConsole.DisplayUser("Ok so you want to deposit.");

			if (!GetAmountFromUser())
				return;

			GetOperationNameFromUser();

			ExecuteActionOnAccount(account);
		}

		public override void ExecuteActionOnAccount(Account account)
		{
			Banker.Deposit(account, Amount, OperationName);

			DisplayBalance(account);
		}
	}
}
