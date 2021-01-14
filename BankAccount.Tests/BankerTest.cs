using BankAccount.Implementations;
using BankAccount.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount.Tests
{
	[TestFixture]
	public class BankerTest
	{
		private Account _myAccount;
		private IBanker _banker;


		[SetUp]
		public void SetUp()
		{
			_banker = new Banker();
			_myAccount = _banker.CreateAccount("Me");
		}

		/*
			US 1:
			In order to save money
			As a bank client
			I want to make a deposit in my account
		*/ 
		[Test]
		public void DepositShouldAddAmount()
		{
			decimal depositAmount = 100;

			_banker.Deposit(_myAccount, depositAmount);

			decimal finalAmount = _banker.GetAmount(_myAccount);

			Assert.AreEqual(depositAmount, finalAmount);
		}
		/*
		US 2:
			In order to retrieve some or all of my savings
			As a bank client
			I want to make a withdrawal from my account
		*/
		[Test]
		public void WithdrawShouldSubstractAmount()
		{
			decimal withdrawAmount = 10;
			decimal expectedFinalAmount = - withdrawAmount;

			_banker.Withdraw(_myAccount, withdrawAmount);

			decimal finalAmount = _banker.GetAmount(_myAccount);

			Assert.AreEqual(expectedFinalAmount, finalAmount);
		}

		/*
			US 3:
			In order to check my operations
			As a bank client
			I want to see the history (operation, date, amount, balance)  of my operations
		*/
		[Test]
		public void DepositShouldSaveOperationName()
		{
			decimal depositAmount = 10;
			string operationName = "First Operation";

			_banker.Deposit(_myAccount, depositAmount, operationName);

			List<Operation> operations = _banker.GetOperations(_myAccount);

			Assert.AreEqual(1, operations.Count);
			Assert.AreEqual(operationName, operations.FirstOrDefault().Name);
		}

		[Test]
		public void DepositShouldSaveOperationDate()
		{
			decimal depositAmount = 10;

			_banker.Deposit(_myAccount, depositAmount);

			List<Operation> operations = _banker.GetOperations(_myAccount);

			Assert.AreEqual(1, operations.Count);
			Assert.IsNotNull(operations.FirstOrDefault().Date);
		}


		[Test]
		public void BalanceShouldBeCorrectWithMultipleOperations()
		{
			int operationCount = 4;
			decimal expectedFinalAmount = 0;

			for(int i = 1; i<=operationCount; i++)
			{
				decimal amount = i * 10;
				expectedFinalAmount += amount;

				_banker.Deposit(_myAccount, amount, $"Operation {i}");
			}

			List<Operation> operations = _banker.GetOperations(_myAccount);

			Assert.AreEqual(expectedFinalAmount, _banker.GetAmount(_myAccount));
			Assert.AreEqual(operationCount, operations.Count);
		}
	}
}
