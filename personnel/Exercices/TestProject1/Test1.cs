using ConsoleApp1;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestSum()
        {
            //Arrange
            int x = 10;
            int y = 5;
            int z = -10;

            //Act
            int res = MyMath.Sum(x, y);
            int res1 = MyMath.Sum(y, z);

            //Assert
            Assert.AreEqual(15, res);
            Assert.AreEqual(-5, res1);
        }
    }
}
