using System;

public class MyClass
{
    private string myProperty;

    public MyClass(string myProperty)
    {
        this.myProperty = myProperty;
    }

    public void MyMethod()
    {
        Console.WriteLine("Мой метод выполняется.");
    }

    public string MyProperty
    {
        get { return myProperty; }
        set { myProperty = value; }
    }

    public static void Main()
    {
        MyClass myObject = new MyClass("Пример");
        myObject.MyMethod();
        myObject.MyProperty = "Новое значение";
        Console.WriteLine("Значение свойства: " + myObject.MyProperty);
    }
}
