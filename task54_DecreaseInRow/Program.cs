// See https://aka.ms/new-console-template for more information
Console.Clear();

Console.WriteLine(" --- Cортировка масcива по убыванию в строках ---");
// Объявление методов

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

while (true)
{
rigthBound = GetNumber ("Введите верхнюю границу случайных значений элементов массива: "); // Проверка на правильность внесения интервала

    if (leftBound <= rigthBound) break;

    else Console.WriteLine("Верхняя граница значений не может быть меньше нижней границы. Повторите ввод");
}

int [ , ] randomArray = InitArray(row, column, leftBound, rigthBound); // Заполнение массива случайными значениями

Console.WriteLine ("Первоначальный массив");
PrintArray (randomArray); // Вывод на экран начального массива

// Тело задачи
for (int k = 1; k < randomArray.GetLength (1)-1; k++)
{
    for (int i = 0; i < randomArray.GetLength(0); i++)
    {
        int templace = 0;
        for (int j = 0; j < randomArray.GetLength(1)-1; j++)
        {
            if (randomArray[i,j] < randomArray[i,j+1]) 
            {
                templace = randomArray[i,j]; 
                randomArray[i,j] = randomArray[i,j +1];
                randomArray[i,j+1] = templace;
            }
        }
    }
}

// Вывод на экран массива после сортировки 

Console.WriteLine ();
Console.WriteLine ("Массив после сортировки:");

PrintArray (randomArray); // Печать массива