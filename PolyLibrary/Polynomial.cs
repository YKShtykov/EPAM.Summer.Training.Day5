using System;
using System.Collections.Generic;
using System.Text;

namespace PolyLibrary
{
  /// <summary>
  /// Polinomial class consists common ariphmetic operations for work with polinomians
  /// </summary>
  public class Polynomial
  {
    public struct Сoefficient
    {
      public double coefficient;
      public int degree;

      public Сoefficient(double c, int d)
      {
        coefficient = c;
        degree = d;
      }
    }

    private readonly Сoefficient[] coeficients;
    private readonly int degree;
    private readonly int length;
    public static readonly double epsilon;


    /// <summary>
    /// Constructor initializes polinomian coefficients and degree 
    /// </summary>
    /// <param name="arr"></param>
    public Polynomial(double[] arr)
    {
      int temp = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        if (Math.Abs(arr[i]) > epsilon)
        {
          temp++;
        }
      }

      coeficients = new Сoefficient[temp];
      temp = 0;
      int tempDegree = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        if (Math.Abs(arr[i]) > epsilon)
        {
          coeficients[temp] = new Сoefficient(arr[i], i);
          tempDegree = i;
          temp++;
        }
      }
      degree = tempDegree;
      length = temp;
    }

    private Polynomial(Сoefficient[] arr)
    {
      coeficients = arr;
      length = arr.Length;
      int temp = 0;
      foreach (var item in arr)
      {
        if (item.degree > temp)
        {
          temp = item.degree;
        }
      }
      degree = temp;

    }

    /// <summary>
    /// Ovwrrided operator +, summes coefficients 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator +(Polynomial a, Polynomial b)
    {
      List<Сoefficient> list = new List<Сoefficient>();

      foreach (var item in a.coeficients)
      {
        bool consist = false;
        foreach (var anItem in b.coeficients)
        {
          if (item.degree == anItem.degree)
          {
            consist = true;
            list.Add(new Сoefficient(item.coefficient + anItem.coefficient, item.degree));
          }
        }
        if (!consist)
        {
          list.Add(new Сoefficient(item.coefficient, item.degree));
        }
      }

      foreach (var item in b.coeficients)
      {
        bool consists = false;
        foreach (var anItem in list)
        {
          if (item.degree == anItem.degree)
          {
            consists = true;
          }
        }
        if (!consists)
        {
          list.Add(new Сoefficient(item.coefficient, item.degree));
        }
      }

      Сoefficient[] arr = list.ToArray();

      return new Polynomial(arr);
    }

    /// <summary>
    /// Ovwrrided operator -, minuses coefficients 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator -(Polynomial a, Polynomial b)
    {
      return a + (-1 * b);
    }

    /// <summary>
    /// Ovwrrided operator *, multiples coefficients 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator *(Polynomial a, Polynomial b)
    {
      int resultlength = a.length + b.length - 1;
      Сoefficient[] arr = new Сoefficient[resultlength];
      for (int i = 0; i < a.length; i++)
      {
        for (int j = 0; j < b.length; j++)
        {
          arr[i + j].coefficient += a.coeficients[i].coefficient * b.coeficients[j].coefficient;
          arr[i + j].degree = a.coeficients[i].degree + b.coeficients[j].degree;
        }
      }
      return new Polynomial(arr);
    }

    /// <summary>
    /// Ovwrrided operator *, multiples coefficients on value
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator *(Polynomial a, int b)
    {
      Сoefficient[] arr = new Сoefficient[a.length];
      for (int i = 0; i < a.length; i++)
      {
        arr[i].coefficient = a.coeficients[i].coefficient * b;
        arr[i].degree = a.coeficients[i].degree;
      }
      return new Polynomial(arr);
    }

    /// <summary>
    /// Ovwrrided operator *, multiples coefficients on value
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator *(int b, Polynomial a)
    {
      return a * b;
    }

    /// <summary>
    /// Ovwrrided operator ==, checks polinomian ecuality
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Polynomial a, Polynomial b)
    {
      return a.Equals(b);
    }

    /// <summary>
    /// Ovwrrided operator ==, checks polinomian unecuality
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Polynomial a, Polynomial b)
    {
      return !a.Equals(b);
    }

    /// <summary>
    /// Overrided System.Object method equals, checks polinomian ecuality
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() == typeof(Polynomial))
      {
        return Equals((Polynomial)obj);
      }
      return false;
    }

    public bool Equals(Polynomial poly)
    {
      if (ReferenceEquals(null, poly)) return false;
      if (ReferenceEquals(this, poly)) return true;
      if (length != poly.length) return false;

      foreach (var item in coeficients)
      {
        bool consist = false;

        foreach (var anitem in poly.coeficients)
        {
          if (item.coefficient == anitem.coefficient && item.degree == anitem.degree)
          {
            consist = true;
          }
        }
        if (!consist)
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Overrided System.Object method GetHashCode
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return coeficients.GetHashCode();
    }

    public static bool Equals(Polynomial a, Polynomial b)
    {
      return a.Equals(b);
    }

    /// <summary>
    /// Overrided System.Object method ToString, return polinomian string view
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public override string ToString()
    {
      var result = new StringBuilder();

      for (int i = 0; i < length; i++)
      {
        if (coeficients[i].coefficient >= 0)
        {
          result.AppendFormat("+{0}x^{1}", coeficients[i].coefficient, coeficients[i].degree);
        }
        else
        {
          result.AppendFormat("{0}x^{1}", coeficients[i].coefficient, coeficients[i].degree);
        }
      }

      return result.ToString();
    }
  }
}
