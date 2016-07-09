using System.Text;

namespace PolyLibrary
{
  /// <summary>
  /// Polinomial class consists common ariphmetic operations for work with polinomians
  /// </summary>
  public class Polynomial
  {
    private readonly Сoefficients сoefficients;
    private readonly int length;

    /// <summary>
    /// Constructor initializes polinomian coefficients and length 
    /// </summary>
    /// <param name="arr"></param>
    public Polynomial(double[] arr)
    {
      сoefficients = new Сoefficients(arr);
      length = arr.Length;
    }

    /// <summary>
    /// Ovwrrided operator +, summes coefficients 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator +(Polynomial a, Polynomial b)
    {
      int resultLength = (a.length > b.length) ? a.length : b.length;
      double[] result = new double[resultLength];
      for (int i = 0; i < resultLength; i++)
      {
        if (a.length > i && b.length > i)
        {
          result[i] = a.сoefficients.koefArr[i] + b.сoefficients.koefArr[i];
        }
        else
        {
          if (a.length < i)
          {
            result[i] = b.сoefficients.koefArr[i];
          }
          else
          {
            result[i] = a.сoefficients.koefArr[i];
          }
        }
      }
      return new Polynomial(result);
    }

    /// <summary>
    /// Ovwrrided operator -, minuses coefficients 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator -(Polynomial a, Polynomial b)
    {
      int resultLength = (a.length > b.length) ? a.length : b.length;
      double[] result = new double[resultLength];
      for (int i = 0; i < resultLength; i++)
      {
        if (a.length > i && b.length > i)
        {
          result[i] = a.сoefficients.koefArr[i] - b.сoefficients.koefArr[i];
        }
        else
        {
          if (a.length < i)
          {
            result[i] = -b.сoefficients.koefArr[i];
          }
          else
          {
            result[i] = a.сoefficients.koefArr[i];
          }
        }
      }
      return new Polynomial(result);
    }

    /// <summary>
    /// Ovwrrided operator *, multiples coefficients 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator *(Polynomial a, Polynomial b)
    {
      int resultLength =a.length + b.length-1;
      double[] result = new double[resultLength];
      for (int i = 0; i < a.length; i++)
      {
        for (int j = 0; j < b.length; j++)
        {
          result[i + j] += a.сoefficients.koefArr[i] * b.сoefficients.koefArr[j];
        }
      }
      return new Polynomial(result);
    }

    /// <summary>
    /// Ovwrrided operator *, multiples coefficients on value
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator *(Polynomial a, int b)
    {      
      double[] result = new double[a.length];
      for (int i = 0; i < a.length; i++)
      {
        result[i] = a.сoefficients.koefArr[i] * b;
      }
      return new Polynomial(result);
    }

    /// <summary>
    /// Ovwrrided operator *, multiples coefficients on value
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Polynomial operator *(int b, Polynomial a)
    {
      double[] result = new double[a.length];
      for (int i = 0; i < a.length; i++)
      {
        result[i] = a.сoefficients.koefArr[i] * b;
      }
      return new Polynomial(result);
    }

    /// <summary>
    /// Ovwrrided operator ==, checks polinomian ecuality
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Polynomial a,Polynomial b)
    {
      if (a.length != b.length)
      {
        return false;
      }
      bool result = true;
      for (int i = 0; i < a.length; i++)
      {
        if (a.сoefficients.koefArr[i]!=b.сoefficients.koefArr[i])
        {
          result = false;
        }
      }
      return result;
    }

    /// <summary>
    /// Ovwrrided operator ==, checks polinomian unecuality
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Polynomial a, Polynomial b)
    {
      if (a.length != b.length)
      {
        return true;
      }
      bool result = true;
      for (int i = 0; i < a.length; i++)
      {
        if (a.сoefficients.koefArr[i] != b.сoefficients.koefArr[i])
        {
          result = false;
        }
      }
      return !result;
    }

    /// <summary>
    /// Overrided System.Object method equals, checks polinomian ecuality
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      Polynomial p = obj as Polynomial;
      if (obj == null)
      {
        return false;
      }

      return this == p;
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

      result.AppendFormat("{0}",сoefficients.koefArr[0]);
      for(int i =1;i<length;i++)
      {
        if (сoefficients.koefArr[i]>=0)
        {
          result.AppendFormat("+{0}x^{1}", сoefficients.koefArr[i], i);
        }
        else
        {
          result.AppendFormat("{0}x^{1}", сoefficients.koefArr[i], i);
        }        
      }

      return result.ToString();
    }
  }

  struct Сoefficients
  {
    public double[] koefArr { get; private set; }


    public Сoefficients(double[] arr)
    {
      koefArr = arr;
    }
  }
}
