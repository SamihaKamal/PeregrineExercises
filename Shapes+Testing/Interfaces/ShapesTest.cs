using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Interfaces
{
    [TestFixture]
    class AreaTest
    {
        [Test]
        public void TriangleArea()
        {
            Triangle tri = new Triangle();
            double sideA = 10.0;
            double sideB = 10.0;
            double sideC = 10.0;
            double expectedValue = Math.Round(43.3, 1);
            tri.sidea = sideA;
            tri.sideb = sideB;
            tri.sidec = sideC;
            double actualValue = Math.Round(tri.Area(),1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void RectangleArea()
        {
            Rectangle rec = new Rectangle();
            double sideA = 10.0;
            double sideB = 12.0;
            double expectedValue = Math.Round(120.0, 1);
            rec.height = sideA;
            rec.width = sideB;
            double actualValue = Math.Round(rec.Area(), 1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void CircleArea()
        {
            Circle circ = new Circle();
            double radius = 10.0;
            double expectedValue = Math.Round(314.2, 1);
            circ.radius = radius; 
            double actualValue = Math.Round(circ.Area(), 1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }
    }

    [TestFixture]
    class perimetreTest
    {
        [Test]
        public void TrianglePeri()
        {

            Triangle tri = new Triangle();
            double sideA = 10.0;
            double sideB = 10.0;
            double sideC = 10.0;
            double expectedValue = Math.Round(30.0, 1);
            tri.sidea = sideA;
            tri.sideb = sideB;
            tri.sidec = sideC;
            double actualValue = Math.Round(tri.Perimetre(), 1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void CirclePeri()
        {
            Circle circ = new Circle();
            double radius = 10.0;
            double expectedValue = Math.Round(62.8, 1);
            circ.radius = radius;
            double actualValue = Math.Round(circ.Perimetre(), 1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void RectanglePeri()
        {
            Rectangle rec = new Rectangle();
            double sideA = 10.0;
            double sideB = 12.0;
            double expectedValue = Math.Round(44.0, 1);
            rec.height = sideA;
            rec.width = sideB;
            double actualValue = Math.Round(rec.Perimetre(), 1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }
    }

    [TestFixture]
    class TriangleCheck
    {
        [Test]
        public void isTriangleArea()
        {

            Triangle tri = new Triangle();
            double expectedValue = 0;
            tri.sidea = 2.0;
            tri.sideb = 2.0;
            tri.sidec = 10.0;
            double actualValue = Math.Round(tri.Area(), 1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void isTrianglePeri()
        {

            Triangle tri = new Triangle();
            double expectedValue = 0;
            tri.sidea = 2.0;
            tri.sideb = 2.0;
            tri.sidec = 10.0;
            double actualValue = Math.Round(tri.Perimetre(), 1);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }
    }
}
