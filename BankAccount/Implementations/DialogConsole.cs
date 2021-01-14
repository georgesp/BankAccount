using BankAccount.Interface;
using System;

namespace BankAccount.Implementations
{
	public class DialogConsole : IDialogConsole
	{
		public void DisplayUser(string message)
		{
			Console.WriteLine(message);
		}

		public string GetUserAnswer()
		{
			return Console.ReadLine();
		}
	}
}
