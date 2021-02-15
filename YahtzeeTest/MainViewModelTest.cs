using NUnit.Framework;
using yahtzeeWPF;

namespace YahtzeeTest
{
    [TestFixture]
    public class MainViewModelTest
    {
        private MainViewModel _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new MainViewModel();
        }
    }
}