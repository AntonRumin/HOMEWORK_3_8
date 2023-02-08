/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.Clear();

Console.WriteLine(" --- Нахождение строки с минимальной суммой ---");
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
int [ , ] InitArray(int line, int bar, int low, int high)
{
    int[ , ] arr = new int [line, bar];

    Random rnd = new Random();

    for (int i = 0; i < line; i++)
    {
        for (int j = 0; j < bar; j++)
        {
        arr[i,j] =rnd.Next (low, high+1);
        }
    }
    return arr;
}

// Метод 3. Вывод Пользователю значений массива
void PrintArray(int[ , ] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
       for (int j=0; j < array.GetLength(1); j++)
        {
          Console.Write(array[i,j] + "  ");
        }
        Console.WriteLine();
    }
    
}
// Вспомогательная часть. Создание и заполнение массива

int row = GetNumber("Введите число строк массива: ");
int column = GetNumber("Введите число столбцов массива: ");
int leftBound = GetNumber ("Введите нижнюю границу случайных значений элементов массива: ");
int rigthBound = 0;

while (true) // Проверка на правильность внесения интервала
{
rigthBound = GetNumber ("Введите верхнюю границу случайных значений элементов массива: "); 

    if (leftBound <= rigthBound) break;

    else Console.WriteLine("Верхняя граница значений не может быть меньше нижней границы. Повторите ввод");
}

int [ , ] randomArray = InitArray(row, column, leftBound, rigthBound); // Заполнение массива случайными значениями

Console.WriteLine ("Первоначальный массив");

PrintArray (randomArray); // Вывод на экран начального массива

int minSum = randomArray [0,0];
int minNumRow = 0;

for (int i = 0; i < randomArray.GetLength (0); i++)
{
int sumRow = 0;
int numRow = i;

    for (int j = 0; j < randomArray.GetLength (1); j++)
    {
    sumRow += randomArray[i,j];
    }

// Console.WriteLine ($"Сумма в строке {i} равна {sumRow}");

if (sumRow < minSum) 
{
    minSum = sumRow;
    minNumRow = numRow;
}
}

Console.WriteLine($"В строке {minNumRow+1} сумма элементов минимальна и равна {minSum}");