using NUnit.Framework;
using PolyLibrary;

namespace PoliLibraryTests
{
  /// <summary>
  /// Class tests polinomian class
  /// </summary>
  [TestFixture]
  public class PolinomianTests
  {
    public Polynomial polyA;
    public Polynomial polyB;

    /// <summary>
    /// Tested polinomian initializing
    /// </summary>
    [TestFixtureSetUp]
    public void PolynomianInitialization()
    {
      polyA = new Polynomial(new double[] { 0, 3, 2, 8, 5 });
      polyB = new Polynomial(new double[] { 1, 1, 1, 1 });
    }

    /// <summary>
    /// Test of minus operations
    /// </summary>
    [Test]
    public void Minus()
    {
      Polynomial expended = new Polynomial(new double[] { -1, 2, 1, 7, 5 });

      Polynomial actual = polyA - polyB;

      Assert.AreEqual(expended, actual);
    }

    /// <summary>
    /// Test of plus operation
    /// </summary>
    [Test]
    public void Plus()
    {
      Polynomial expended = new Polynomial(new double[] { 1, 4, 3, 9, 5 });

      Polynomial actual = polyA + polyB;

      Assert.AreEqual(expended, actual);
    }

    /// <summary>
    /// Test of multiply
    /// </summary>
    [Test]
    public void Multiply()
    {
      Polynomial expended = new Polynomial(new double[] {0, 3, 5, 13, 18, 15, 13, 5 });

      Polynomial actual = polyA * polyB;

      Assert.AreEqual(expended, actual);
    }

    /// <summary>
    /// Test of ToString method
    /// </summary>
    [Test]
    public void ToStringTest()
    {
      string expended = "0+3x^1+2x^2+8x^3+5x^4";

      string actual = polyA.ToString();

      Assert.AreEqual(expended, actual);
    }

    /// <summary>
    /// Overrided System.Object Equals
    /// </summary>
    [Test]
    public void Equality()
    {
      Assert.IsTrue( polyA.Equals(polyA));     
    }

    /// <summary>
    /// Overrided System.Object static Equals
    /// </summary>
    [Test]
    public void StaticEquality()
    {
      Assert.IsTrue( Equals(polyA, polyA));
    }
  }
}
