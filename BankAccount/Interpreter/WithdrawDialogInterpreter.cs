using System;
using BankAccount.Implementations;
using BankAccount.Interface;

namespace BankAccount.Interpreter
{
	public class WithdrawDialogInterpreter : AbstractDialogInterpreter
	{
		
		public WithdrawDialogInterpreter(IBanker banker, IDialogConsole dialogConsole) : base(banker, dialogConsole)
		{
		}

		public override void StartDialogWithBanker(Account account)
		{
			DialogConsole.DisplayUser("Ok so you want to withdraw.");

			if (!GetAmountFromUser())
				return;

			GetOperationNameFromUser();

			ExecuteActionOnAccount(account);
		}

		public override void ExecuteActionOnAccount(Account account)
		{
			Banker.Withdraw(account, Amount, OperationName);

			DisplayBalance(account);
		}
	}
}
