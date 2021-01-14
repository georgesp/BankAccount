using BankAccount.Implementations;
using BankAccount.Interface;
using System;

namespace BankAccount.Interpreter
{
	public abstract class AbstractDialogInterpreter
	{
		protected readonly IBanker Banker;

		protected decimal Amount;
		protected string OperationName;
		protected IDialogConsole DialogConsole;

		protected AbstractDialogInterpreter(IBanker banker, IDialogConsole dialogConsole)
		{
			Banker = banker;
			DialogConsole = dialogConsole;
		}

		public abstract void StartDialogWithBanker(Account account);

		public abstract void ExecuteActionOnAccount(Account account);

		protected bool GetAmountFromUser()
		{
			Amount = 0;

			DialogConsole.DisplayUser("How much ?");
			string input = DialogConsole.GetUserAnswer();

			decimal amount;
			if (decimal.TryParse(input, out amount))
			{
				Amount = amount;
				return true;
			}

			return false;
		}

		protected void GetOperationNameFromUser()
		{
			DialogConsole.DisplayUser("How do you want to call the operation ?");
			OperationName = DialogConsole.GetUserAnswer();
		}

		protected void DisplayBalance(Account account)
		{
			decimal currentAmount = Banker.GetAmount(account);
			DialogConsole.DisplayUser($"You have now {currentAmount} on your account.");
		}
	}
}
