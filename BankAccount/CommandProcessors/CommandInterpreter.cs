using System;
using System.Collections.Generic;
using System.Linq;
using BankAccount.Implementations;
using BankAccount.Interface;
using BankAccount.Interpreter;
using BankAccount.Tools;

namespace BankAccount.CommandProcessors
{
	public class CommandInterpreter : ICommandInterpreter
	{
		private readonly List<ActionEnum> _availableActions;
		private readonly Dictionary<ActionEnum, Func<AbstractDialogInterpreter>> _interpreterMapping;

		public CommandInterpreter(IBanker banker, IDialogConsole dialogConsole)
		{
			_availableActions = Enum.GetValues(typeof(ActionEnum)).Cast<ActionEnum>().ToList();

			_interpreterMapping = new Dictionary<ActionEnum, Func<AbstractDialogInterpreter>>();
			_interpreterMapping.Add(ActionEnum.Withdraw, () => new WithdrawDialogInterpreter(banker, dialogConsole));
			_interpreterMapping.Add(ActionEnum.Deposit, () => new DepositDialogInterpreter(banker, dialogConsole));
			_interpreterMapping.Add(ActionEnum.Balance, () => new BalanceDialogInterpreter(banker, dialogConsole));
			_interpreterMapping.Add(ActionEnum.History, () => new HistoryDialogInterpreter(banker, dialogConsole));
		}
		
		public List<ActionEnum> GetAvailableActions()
		{
			return _availableActions;
		}

		public void ExecuteAction(string input, Account account)
		{
			ActionEnum action = CallActionFromInput(input);

			if (!_interpreterMapping.ContainsKey(action))
				return;

			_interpreterMapping[action].Invoke().StartDialogWithBanker(account);
		}

		private ActionEnum CallActionFromInput(string input)
		{
			foreach (ActionEnum actionEnum in _availableActions)
			{
				if (input.Contains(Convert.ToInt32(actionEnum).ToString()))
					return actionEnum;

				if (input.ToLower().Contains(actionEnum.ToString().ToLower()))
					return actionEnum;
			}

			return ActionEnum.None;
		}

		
	}
}
