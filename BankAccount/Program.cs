using System;
using System.Collections.Generic;
using BankAccount.CommandProcessors;
using BankAccount.Implementations;
using BankAccount.Interface;
using BankAccount.Tools;

namespace BankAccount
{
	class Program
	{
		private static ICommandInterpreter _interpreter;
		private static IBanker _banker;
		private static Account _myAccount;
		private static IDialogConsole _dialogConsole;

		static void Main(string[] args)
		{
			_dialogConsole = new DialogConsole();

			string input;
			string exitCommand = "exit";

			_dialogConsole.DisplayUser("Hello !");
			_dialogConsole.DisplayUser($"Welcome, type your name to create a bank account or \"{exitCommand}\" to exit the application");
			input = _dialogConsole.GetUserAnswer();

			if (input == exitCommand)
				return;

			_dialogConsole.DisplayUser($"Thank you {input} for creating your bank account");
			AccountInitialization(input);

			while (input != exitCommand)
			{
				DisplayAvailableActions();
				input = _dialogConsole.GetUserAnswer();

				_interpreter.ExecuteAction(input, _myAccount);

			}
		}

		private static void AccountInitialization(string name)
		{
			_banker = new Banker();
			_myAccount = _banker.CreateAccount(name);
			_interpreter = new CommandInterpreter(_banker, _dialogConsole);
		}

		private static void DisplayAvailableActions()
		{
			IEnumerable<ActionEnum> commands = _interpreter.GetAvailableActions();

			_dialogConsole.DisplayUser($"{Environment.NewLine}Which operation do you want to proceed ?");
			foreach (ActionEnum actionEnum in commands)
			{
				_dialogConsole.DisplayUser($"{Convert.ToInt32(actionEnum)} - {actionEnum.ToString()}");
			}
		}
	}
}
