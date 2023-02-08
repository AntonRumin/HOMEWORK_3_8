/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

Console.Clear();

Console.WriteLine(" --- Вывод значений трехмерного массива c адресами ---");
// Объявление методов
// Метод 1. Ввод числового значения
int GetNumber(string msg)
{
    int result = 0;

    while(true)
    {
        Console.Write(msg);

        if(int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Введено не число. Повторите ввод.");
        }
    }
    return result;
}

// Метод 2. Объявление двумерного массива и заполнение его случайными значениями
int [ , , ] InitArray(int line, int bar, int width, int low, int high)
{
    int[ , , ] arr = new int [line, bar, width];
    int [] res = new int [line*bar*width];

    Random rnd = new Random();
    int count = 0;

    for (int i = 0; i < line; i++)
    {
        for (int j =0; j < bar; j++)
        {
             int x = 0;
        for (int l = 0; l < width; l++)
        {  

        while (true)
        {
        x = rnd.Next (low, high+1);
        int a = 0;
        for (int k = 0; k < line*bar*width; k++)
        {
        if (x == res [k]) a +=1; 
        }
        if (a == 0) break;
        }
        res [count] = x;
        
        arr [i,j,l] = x;
        count +=1;
        }
        }   
    }
    return arr;
}

// Метод 3. Вывод Пользователю значений массива 3D
void PrintArray(int[ , , ] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
       for (int j=0; j < array.GetLength(1); j++)
        {
          for (int l =0;l < array.GetLength(2); l++)
          {
          Console.Write(array[i,j,l] + $" ({i}, {j}, {l})  ");
          }
          Console.WriteLine();
        }
        Console.WriteLine();
    }
    
}
// Вспомогательная часть. Создание и заполнение массива

int row = GetNumber("Введите число строк массива: ");
int column = GetNumber("Введите число столбцов массива: ");
int wide = GetNumber ("Введите ширину массива: ");
int leftBound = GetNumber ("Введите нижнюю границу случайных значений элементов массива: ");
int rigthBound = 0;

while (true) // Проверка на правильность внесения интервала
    {
rigthBound = GetNumber ("Введите верхнюю границу случайных значений элементов массива: "); 

    if (leftBound <= rigthBound)  break;

    else Console.WriteLine("Верхняя граница значений не может быть меньше нижней границы. Повторите ввод");
    }


int [ , , ] randomArray = InitArray(row, column, wide, leftBound, rigthBound); // Заполнение массива случайными значениями


Console.WriteLine ("Элементы массива с адресами: ");
Console.WriteLine();

PrintArray (randomArray); // Вывод на экран начального массива
