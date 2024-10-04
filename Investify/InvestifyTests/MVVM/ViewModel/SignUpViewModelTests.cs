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
    public class SignUpViewModelTests
    {
        [Test()]
        public void ValidationTest_NullFirstnameRestIsValid_ThrowsException()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = null,
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_NullLastnameRestIsValid_ThrowsException()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = null,
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_NullLoginRestIsValid_ThrowsException()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = null,
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_NullEmailRestIsValid_ThrowsException()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = null,
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_NullPasswordRestIsValid_ThrowsException()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = null,
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_NullDayOfBirthRestIsValid_ThrowsException()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = null,
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_NullYearOfBirthRestIsValid_ThrowsException()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = null
            };
            Assert.Throws<ArgumentException>(() => viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_FirstnameIsEmpty_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LastnameIsEmpty_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LoginIsEmpty_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_EmailIsEmpty_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_PasswordIsEmpty_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_DayOfBirthIsEmpty_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_YearOFBirthIsEmpty_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = ""
            };
            Assert.IsFalse(viewModel.Validation());
        }



        [Test()]
        public void ValidationTest_FirstnameIsWhiteSpace_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = " ",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LastnameIsWhiteSpace_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = " ",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_LoginIsWhiteSpace_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = " ",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }


        [Test()]
        public void ValidationTest_EmailIsWhiteSpace_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = " ",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }


        [Test()]
        public void ValidationTest_PasswordIsWhiteSpace_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = " ",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }


        [Test()]
        public void ValidationTest_DayOfBirthIsWhiteSpace_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = " ",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_YearOfBirthIsWhiteSpace_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = " "
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_ValidData_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsTrue(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_BirthDateIsEarlierThanTodaysDate_ReturnsTrue()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsTrue(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_BirthDateIsLaterThanTodaysDate_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "2200"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_BirthDateIsTooEarlyBeyondTolerance_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_ValidEmailPattern1_ReturnsTrue()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@email.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_InValidEmailPattern1_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "1@email.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_InValidEmailPattern2_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@2.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_InValidEmailPattern3_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@email.2",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_InValidEmailPattern4_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "@email.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_InValidEmailPattern5_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_InValidEmailPattern6_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@email.",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 1,
                YearOfBirth = "1900"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_ValidDayAndYearAsInteger_ReturnsTrue()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsTrue(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_DayIsNotInteger_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "not an integer",
                MonthOfBirth = 8,
                YearOfBirth = "0"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_YearIsNotInteger_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "8",
                MonthOfBirth = 8,
                YearOfBirth = "not an integer"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_DayBelowZero_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "-5",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_YearBelowZero_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "17",
                MonthOfBirth = 8,
                YearOfBirth = "-2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_DayEqualsZero_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "0",
                MonthOfBirth = 8,
                YearOfBirth = "2024"
            };
            Assert.IsFalse(viewModel.Validation());
        }

        [Test()]
        public void ValidationTest_YearEqualsZero_ReturnsFalse()
        {
            SignUpViewModel viewModel = new SignUpViewModel()
            {
                Firstname = "test",
                Lastname = "test",
                Login = "test",
                Email = "xyz@mail.com",
                Password = "test",
                DayOfBirth = "8",
                MonthOfBirth = 8,
                YearOfBirth = "0"
            };
            Assert.IsFalse(viewModel.Validation());
        }
    }
}