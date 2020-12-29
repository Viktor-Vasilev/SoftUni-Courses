using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;
using Moq;

namespace Chainblock.Tests
{
    [TestFixture]

    public class ChainblockTests
    {
        public ITransaction transaction { get; set; }

        public IChainblock Chainblock { get; set; }

        [SetUp]
        public void SetUp()
        {
            // Arrange
            this.transaction = new Transaction()
            {
                Id = 1,
                From = "Filip",
                To = "Viktor",
                Status = TransactionStatus.Successfull,
                Amount = 1
            };

            this.Chainblock = new Chainblocks();
        }


        [Test]
        [Category("[Add method]")]
        public void Given_Transaction_WhenAddTransactionIsCalled_ThenTransactionsCountIncrease()
        {


            // Act
            this.Chainblock.Add(this.transaction);

            // Assert

            Assert.AreEqual(1, Chainblock.Count);

        }

        [Test]
        [Category("[Add method]")]
        public void Given_DuplicateTransaction_WhenAddTransactionIsCalled_ThenThrowInvalidOperationException()
        {


            // Act
            this.Chainblock.Add(transaction);

            // Assert

            Assert.Throws<InvalidOperationException>(() => this.Chainblock.Add(this.transaction));
        }

        [Test]
        [Category("[Count Property]")]
        public void Given_PropertyCountValue_WhenCountGetterIsCalled_ThenProperNumberIsReturned()
        {
            int expectedChainblockCount = 0;
            Assert.AreEqual(expectedChainblockCount, this.Chainblock.Count);
        }

        [Test]
        [Category("[Contains --> id Method]")]
        public void Given_ExistingId_WhenContainsByIdIsCalled_ThenReturnsTrue()
        {
            this.Chainblock.Add(this.transaction);
            bool result = this.Chainblock.Contains(this.transaction.Id);

            Assert.IsTrue(result);
        }

        [Test]
        [Category("[Contains --> id Method]")]
        public void Given_NonExistingId_WhenContainsByIdIsCalled_ThenReturnsFalse()
        {
            Assert.That(this.Chainblock.Contains(this.transaction.Id), Is.False);
        }

        [Test]
        [Category("[Contains --> id Method]")]
        public void Given_NegativeId_WhenContainsByIdIsCalled_ThenThrowInvalidArgumentException()
        {
            int invalidId = -1;
            Assert.Throws<ArgumentException>(() => this.Chainblock.Contains(invalidId));
        }

        [Test]
        [Category("[Contains --> Transaction method]")]
        public void Given_ExistingTransaction_WhenContainsByTransactionIsCalled_ThenReturnsTrue()
        {
            this.Chainblock.Add(this.transaction);
            Assert.That(this.Chainblock.Contains(transaction), Is.True);
        }

        [Test]
        [Category("[Contains --> Transaction method]")]
        public void Given_NonExistingTransaction_WhenContainsByTransactionIsCalled_ThenReturnsFalse()
        {
            Assert.IsFalse(this.Chainblock.Contains(this.transaction));
        }

        [Test]
        [Category("[ChangeTransactionStatus method]")]
        public void Given_ValidIdAndStatus_WhenStatusISCalled_ThenStatusIsChanged()
        {
            this.transaction.Status = TransactionStatus.Successfull;
            
            this.Chainblock.Add(this.transaction);

            TransactionStatus newStatus = TransactionStatus.Aborted;

            this.Chainblock.ChangeTransactionStatus(this.transaction.Id, newStatus);

            Assert.AreEqual(newStatus, this.transaction.Status);
        }

        [Test]
        [Category("[ChangeTransactionStatus method]")]
        public void Given_ValidIdAndSameStatus_WhenStatusISCalled_ThenThrowInvalidOperationException()
        {
            this.transaction.Status = TransactionStatus.Successfull;

            this.Chainblock.Add(this.transaction);

            TransactionStatus newStatus = TransactionStatus.Successfull;          

            Assert.Throws<InvalidOperationException>(() => this.Chainblock.ChangeTransactionStatus(this.transaction.Id, newStatus));
        }

        [Test]
        [Category("[ChangeTransactionStatus method]")]
        public void Given_InValidIdAndStatus_WhenStatusISCalled_ThenThrowArgumentException()
        {
            this.Chainblock.Add(this.transaction);

            int notExistingId = 2;

            Assert.Throws<ArgumentException>(() => this.Chainblock.ChangeTransactionStatus(notExistingId, TransactionStatus.Aborted));
        }

        [Test]
        [Category("[ChangeTransactionStatus method]")]
        public void Given_ValidIdAndNotExistingStatus_WhenStatusISCalled_ThenThrowInvalidOperationException()
        {
            int invalidTransactionStatusValue = 15;

            Assert.Throws<InvalidOperationException>(() => this.Chainblock.ChangeTransactionStatus(this.transaction.Id, (TransactionStatus)invalidTransactionStatusValue));
        }

        
        [Test]        
        [Category("[ChangeTransactionStatus method]")]
        public void Given_MinusIdAndStatus_WhenStatusISCalled_ThenThrowArgumentException()
        {
            int minusId = -1;

            Assert.Throws<ArgumentException>(() => this.Chainblock.ChangeTransactionStatus(minusId, TransactionStatus.Successfull));
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTransactionFromChainblockCorrectly()
        {
            this.Chainblock.Add(this.transaction);
            this.Chainblock.RemoveTransactionById(1);

            Assert.AreEqual(0, this.Chainblock.Count);
        }

        [Test]
        [TestCase(666)]
        public void RemoveTransactionByIdShouldThrowInvalidOperationExceptionInAttemptToRemoveInvalidTransaction(int id)
        {
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.RemoveTransactionById(id));
                                                                               
        }

        [Test]
        [TestCase(1)]
        public void GetByIdMethodShouldReturnCorrectTransaction(int id)
        {
            this.Chainblock.Add(this.transaction);

            ITransaction transaction = this.Chainblock.GetById(id);

            Assert.AreEqual(this.transaction.Id, transaction.Id);
        }

        [Test]
        [TestCase(999)]
        public void GetByIdMethodShouldThrowInvalidOperationExceptionInAttemptToGetInvalidTransaction(int id)
        {
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.GetById(id));
                                                                
        }



    }
}
