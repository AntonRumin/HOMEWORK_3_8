/* Задача 58: 
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.Clear();

Console.WriteLine(" --- Произведение матриц ---");
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
// Массив 1
Console.WriteLine ("Исходные данные первого массива: ");

int rowOne = GetNumber("Введите число строк массива: ");
int columnOne = GetNumber("Введите число столбцов массива: ");
int leftBoundOne = GetNumber ("Введите нижнюю границу случайных значений элементов массива: ");
int rigthBoundOne = 0;

while (true) // Проверка на правильность внесения интервала
{
rigthBoundOne = GetNumber ("Введите верхнюю границу случайных значений элементов массива: "); 

    if (leftBoundOne <= rigthBoundOne) break;

    else Console.WriteLine("Верхняя граница значений не может быть меньше нижней границы. Повторите ввод");
}

int [ , ] firstArray = InitArray(rowOne, columnOne, leftBoundOne, rigthBoundOne); // Заполнение массива случайными значениями

Console.WriteLine ("Первый массив: ");

PrintArray (firstArray); // Вывод массива на экран

// Массив 2
Console.WriteLine ();
Console.WriteLine ("Исходные данные второго массива: ");

int rowTwo = GetNumber("Введите число строк массива: ");
int columnTwo = GetNumber("Введите число столбцов массива: ");
int leftBoundTwo = GetNumber ("Введите нижнюю границу случайных значений элементов массива: ");
int rigthBoundTwo = 0;

while (true) // Проверка на правильность внесения интервала
{
rigthBoundTwo = GetNumber ("Введите верхнюю границу случайных значений элементов массива: "); 

    if (leftBoundTwo <= rigthBoundTwo) break;

    else Console.WriteLine("Верхняя граница значений не может быть меньше нижней границы. Повторите ввод");
}

int [ , ] secondArray = InitArray(rowTwo, columnTwo, leftBoundTwo, rigthBoundTwo); // Заполнение массива случайными значениями

Console.WriteLine ("Второй массив: ");

PrintArray (secondArray); // Вывод массива на экран

if (columnOne != rowTwo)
{
Console.Write ("Умножение матриц выполнить нельзя!"); 

}
else
{

int [ , ] multiMatrix = new int [firstArray.GetLength(0), secondArray.GetLength(1)];

for (int i = 0; i < firstArray.GetLength (0); i++)
{
for(int j = 0;  j < secondArray.GetLength (1); j++)
{
   multiMatrix [i,j] = 0;
   int sum = 0;

for (int p = 0; p < firstArray.GetLength (1); p++)
{
 sum = sum + firstArray [i,p] * secondArray [p,j];

}
   multiMatrix [i,j] = sum;
}

}
Console.WriteLine();
Console.WriteLine ($"Матрица - произведение (имеет размерность {rowOne} x {columnTwo}): ");
Console.WriteLine ();
PrintArray (multiMatrix);

}

