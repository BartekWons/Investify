using NUnit.Framework;
using Investify.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
using Investify.MVVM.ViewModel.Account;

namespace Investify.MVVM.ViewModel.Tests
{
    [TestFixture()]
    public class LogInViewModelTests
    {
        [Test()]
        public void ValidationTest_LoginIsNullAndPasswordIsEmpty_ThrowsArgumentException()
        {
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Login = null;
            viewModel.Password = "";

            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LoginIsEmptyAndPasswordIsNull_ThrowsArgumentException()
        {
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Login = "";
            viewModel.Password = null;

            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LoginAndPasswordAreNull_ThrowsArgumentException()
        {
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Login = null;
            viewModel.Password = null;

            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LoginIsValidAndPasswordAIsNull_ThrowsArgumentException()
        {
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Login = "test";
            viewModel.Password = null;

            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LoginIsNullAndPasswordIsValid_ThrowsArgumentException()
        {
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Login = null;
            viewModel.Password = "test";

            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LoginAndPasswordAreEmpty_ReturnsFalse()
        {
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Login = "";
            viewModel.Password = "";

            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_ValidEmailAndPassword_ReturnsTrue()
        { 
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Login = "test";
            viewModel.Password = "test";

            Assert.IsTrue(viewModel.Validation());
        }
    }
}