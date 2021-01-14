using System.Collections.Generic;
using BankAccount.CommandProcessors;
using BankAccount.Implementations;
using BankAccount.Interface;
using BankAccount.Tools;
using Moq;
using NUnit.Framework;

namespace BankAccount.Tests
{
	[TestFixture]
	public class CommandInterpreterTests
	{
		private ICommandInterpreter _interpreter;
		private Mock<IBanker> _bankerMock;
		private Mock<IDialogConsole> _dialogConsole;
		private Account _account;
		[SetUp]
		public void SetUp()
		{
			_bankerMock = new Mock<IBanker>();
			_dialogConsole = new Mock<IDialogConsole>();

			_dialogConsole.Setup(d => d.GetUserAnswer()).Returns("10");

			_interpreter = new CommandInterpreter(_bankerMock.Object, _dialogConsole.Object);
			_account = new Account("Me");
		}


		[Test]
		public void WhenWithdrawActionThenWithdrawDialog()
		{
			
			_interpreter.ExecuteAction(ActionEnum.Withdraw.ToString(), _account);
			_bankerMock.Verify(b => b.Withdraw(It.IsAny<Account>(), It.IsAny<decimal>(), It.IsAny<string>()), Times.Once);
		}

		[Test]
		public void WhenDepositActionThenDepositDialog()
		{

			_interpreter.ExecuteAction(ActionEnum.Deposit.ToString(), _account);
			_bankerMock.Verify(b => b.Deposit(It.IsAny<Account>(), It.IsAny<decimal>(), It.IsAny<string>()), Times.Once);
		}

		[Test]
		public void WhenBalanceActionThenBalanceDialog()
		{

			_interpreter.ExecuteAction(ActionEnum.Balance.ToString(), _account);
			_bankerMock.Verify(b => b.GetAmount(It.IsAny<Account>()), Times.Once);
		}

		[Test]
		public void WhenHistoryctionThenHistoryDialog()
		{
			_interpreter.ExecuteAction(ActionEnum.History.ToString(), _account);
			_bankerMock.Verify(b => b.GetOperations(It.IsAny<Account>()), Times.Once);
		}

	}
}
