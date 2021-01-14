using System;
using System.Linq;
using BankAccount.Implementations;
using BankAccount.Interface;

namespace BankAccount.Interpreter
{
	public class HistoryDialogInterpreter : AbstractDialogInterpreter
	{
		
		public HistoryDialogInterpreter(IBanker banker, IDialogConsole dialogConsole) : base(banker, dialogConsole)
		{
		}

		public override void StartDialogWithBanker(Account account)
		{
			ExecuteActionOnAccount(account);
		}

		public override void ExecuteActionOnAccount(Account account)
		{
			var operations = Banker.GetOperations(account);

			if(!operations.Any())
				DialogConsole.DisplayUser("You have no operations on your account.");
			else
				operations.ForEach(o => Console.WriteLine(o.ToString()));

			DisplayBalance(account);
		}
	}
}
