using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Tests
{
    internal class TemplateEngineTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("meghu","gundu","theju")]
        public void Test1(string value1 , string value2, string value3)
        {
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.SetTemplate("Hello {{name1}} {{name2}} {{name3}}");

            // Act
            templateEngine.SetName("name1", value1);
            templateEngine.SetName("name2", value2);
            templateEngine.SetName("name3", value3);
            var result = templateEngine.Render();

            // Assert
            Assert.AreEqual("Hello"+" "+value1+" " +value2+" "+value3, result);
            //TemplateEngine templateEngine = new TemplateEngine();
            //TemplateEngine.setTemplate("Hello {{name}}");
            //TemplateEngine.SetName("name", "Meghu");
            //var result = TemplateEngine.Render();
            //Assert.AreEqual(result, "Hello Meghu");
        }

    }
}
