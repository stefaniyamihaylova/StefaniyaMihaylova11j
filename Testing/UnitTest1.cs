using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using BusinessLayer;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        PotrebitelContext context;
        Potrebitel ElUsero;

        [TestInitialize]
        public void Setup()
        {
            var context = new OpisanieDBContext();
            var _context = new PotrebitelContext(context);
            this.context = _context;

            Potrebitel user = new Potrebitel(0, "Stefaniq", "Mihaylova", 22, "zodiq", "123123", "poshta123@gmail.com", 0);
            ElUsero = user;
        }
        [TestCleanup]
        public void CleanUp()
        {
            
            context.Delete(ElUsero);
            
            context.Create(ElUsero);
        }


        [TestMethod]
        public void CreateTest()
        {            
            Assert.IsNotNull(context.Read(0));
        }
        [TestMethod]
        public void ReadTest()
        {           
            var data = context.Read(0);

            Assert.AreEqual(21, data.Vuzrast);
        }
        [TestMethod]
        public void UpdateTest()
        {
            var newuser = new Potrebitel(0, "Stefaniq", "Mihaylova", 22, "zodiq", "123123", "poshta123@gmail.com", 0);
            context.Update(newuser);

            Assert.AreEqual("Stefaniq", context.Read(0).Name);
        }
        [TestMethod]
        public void DeleteTest()
        {
            context.Delete(0);

            Assert.IsNull(context.Read(0));
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(context.ReadAll());
        }
    }
}
