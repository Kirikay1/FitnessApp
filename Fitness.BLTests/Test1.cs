namespace Fitness.BL.Controller.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            DateTime birthDate = DateTime.Now.AddYears(-18);
            var weigth = 70;
            var heigth = 170;
            var gender = "man";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, birthDate, weigth, heigth);

            //Asert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller.CurrentUser.BirthDate);
            Assert.AreEqual(weigth, controller.CurrentUser.Weigth);
            Assert.AreEqual(heigth, controller.CurrentUser.Heigth);
            Assert.AreEqual(gender, controller.CurrentUser.Gender.Name);

        }

        [TestMethod]
        public void SaveTest()
        {
            //Arrange
            var userName = "awfdas";

            //Act
            var controller = new UserController(userName);

            //Asert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}
