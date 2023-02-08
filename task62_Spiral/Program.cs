/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/
Console.Clear();

Console.WriteLine(" - - - Заполнение массива значениями по спирали (вправо) - - -");

// Объявление методов
// Метод 1. Ввод числового значения. Необходимо для задания размерности массива

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


// Метод 2. Объявление одномерного массива и заполнение его значениями

string [] InitDataArray(int num)
{
    string[] arr = new string [num];

    for (int i = 0; i < num; i++)
    {
        if (i<9) arr[i]=("0" + (i+1+String.Empty));
        else arr[i] =(i+1)+String.Empty;
    }
    return arr;
}


// Метод 3. Вывод Пользователю значений массива

void PrintArray(string [ , ] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
       for (int j = 0; j < array.GetLength(1); j++)
        {
          Console.Write(array[i,j]+"  ");
        }
        Console.WriteLine ();
    }
    
}

// Методы 4 - 7. Функции переходов Вправо - Влево, Вверх-Вниз

(int, int) GoRigth (int column)
{
    column = column + 1;
    int direction = 1;
    return (column, direction);  
}

(int, int) GoDown (int row)
{
    row = row + 1;
    int direction = 2;
    return (row, direction);  
}
(int, int) GoLeft (int column)
{
    column = column - 1;
    int direction = 3;
    return (column, direction);  
}
(int, int) GoUp (int row)
{
    row = row - 1;
    int direction = 4;
    return (row, direction);  
}

// Объявление переменных и заполнение массива данных

int side = GetNumber("Задайте размер квадратного массива: ");

string [] dataArray = InitDataArray (side*side);

string [,] baseArray = new string [side,side];

    baseArray [0,0] = dataArray [0];

int i = 0, j =0, k =1, direct = 1;

int step = 1;

// Алгоритм переходов и присвоения значений элементам основного массива

while (step < side*side)
{

switch (direct)
    {
    case 1:
            if ( j+1 < side && baseArray[i,j+1] == null )
            {
                (j,direct) = GoRigth (j);
                baseArray [i,j] = dataArray [k];
            }
            else if ( j+1 >= side | baseArray[i,j] != null )
            {
                (i,direct) = GoDown (i);
                baseArray [i,j] = dataArray [k];
            }
            else Console.WriteLine ("ошибка 1");
    break;

    case 2:
            if ( i+1 < side && baseArray[i+1,j] == null )
            {
                (i,direct) = GoDown (i);
                baseArray [i,j] = dataArray [k];
            }
            else if ( i+1 >= side | baseArray[i,j] != null )
            {
                (j,direct) = GoLeft (j);
                baseArray [i,j] = dataArray [k];
            }
            else Console.WriteLine ("ошибка 2");
    break;

    case 3:
            if ( j-1 >= 0 && baseArray[i,j-1] == null ) 
            {
                (j,direct) = GoLeft(j);
                baseArray [i,j] = dataArray [k];
            }
            else if ( j-1 <= side | baseArray[i,j] != null )
            {
                (i,direct) = GoUp (i);
                baseArray [i,j] = dataArray [k];
            }
            else Console.WriteLine ("ошибка 3");
    break;

    case 4:
            if (i-1 >= 0 && baseArray[i-1,j] == null)
            {
            (i,direct) = GoUp (i);
            baseArray [i,j] = dataArray [k];
            }
            else if (i-1 <= side | baseArray[i-1,j] != null) 
            {
            (j,direct) = GoRigth (j);
            baseArray [i,j] = dataArray [k];
            }
            else Console.WriteLine ("ошибка 4");
    break;

    default:
            Console.WriteLine ("Ошибка по дефолту");
    break;
   }
    step = step +1;
    k +=1;
}

Console.WriteLine ("Первоначальный массив:    ");
Console.WriteLine ();

PrintArray (baseArray); // Вывод на экран начального массива
