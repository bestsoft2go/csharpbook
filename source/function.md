# C# 程式基礎：函數

## 簡介

C# 分為靜態函數與成員函數兩類，靜態函數附屬於類別，呼叫時可以直接指定類別名稱即可。成員函數附屬於物件，呼叫時必須透過物件變數進行呼叫。

通常函數會接收到一些呼叫端傳入的參數。C# 的參數有數種傳遞方式，包含傳值參數 (call by value)，傳址參數 (call by reference) 等，基本型態的參數，像是 int, double, char, ... 等，預設都使用傳值的方式，而物件形態的參數，像是 StringBuilder，陣列等，預設則是使用傳址的方式。

以下是一個 C# 的靜態函數範例，其中的 square 就是靜態函數，其功能是將傳入的數值進行平方動作後傳回，這是一個傳值參數的範例。

```CS
using System;

class Func1
{
    public static void Main(string[] args)
    {
    	int x = square(5);
    	Console.WriteLine("x="+x);
    }

    public static int square(int n) 
    {
    	return n*n;
    }
}
```

## 函數的參數

陣列也可以用來作為函數的參數，由於陣列的傳遞採用傳址的方式，因此在函數中對陣列的修改將會是永久性的修改，離開函數後並不會恢復成原先的數值。以下範例中的 add 函數用來將兩個二維陣列 (x,y) 相加，然後將結果放入 z 當中，print 函數則是將傳入的陣列 x 印出來。必須注意的是，對於二維陣列而言，要取得陣列的第一維元素個數 (列數)，可用 GetLength(0)，要取得陣列的第二維元素個數 (行數)，必須使用 GetLength(1)。

```CS
using System; 

class Func2
{ 
    public static void Main(string[] args)
    {
    	int[,] a = {{1,2}, {3,4}};
    	int[,] b = {{5,6}, {7,8}};
    	int[,] c = new int[2,2];
    	add(a, b, c);
    	Console.WriteLine("=======a=======");
    	print(a);
    	Console.WriteLine("=======b=======");
    	print(b);
    	Console.WriteLine("=======c=======");
    	print(c);
    }

    public static void add(int[,] x, int[,] y, int[,] z)
    {
    	for (int i=0; i<z.GetLength(0); i++)
    	for (int j=0; j<z.GetLength(1); j++)
    	{
    	 z[i,j] = x[i,j] + y[i,j];
    	}
    }

    public static void print(int[,] x)
    {
    	for (int i=0; i<x.GetLength(0); i++)
    	{
    	for (int j=0; j<x.GetLength(1); j++)
    	 Console.Write(x[i,j]+" ");
    	Console.WriteLine();
    }
    }
}
```

## 練習

```CS
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            sum(10);
            sum(20);
            sum(30);
        }
        
        static void sum(int n) 
        {
            int s = 0;
            for (int i = 1; i <= n; i++)
            {
                s = s + i;
            }
            Console.WriteLine("s = " + s);
        }
    }
}
```
