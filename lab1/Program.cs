//часть 1
var max=0;//максимальный элемент
var proizv = 1;//произведение элементов между первым и вторым нулевыми элементами
var firstNul = 0;//первый нулевой элемент
var secondNul = 0;//второй нулевой элемент
var indexMax = 0;//номер максимального элемента

var rnd = new Random();//генератор случайных чисел
try
{
    Console.Write("введите количество элементов массива: ");
    var N = Convert.ToInt32(Console.ReadLine()); //количество элементов массива
    
var mas = new int[N];//массив
for(var i= 0; i<N; i++)
{
    mas[i] = rnd.Next(-100,100);//заполнение массива случайными числами
    Console.Write(mas[i]+" ");//вывод массива
}

for(var i = 0; i<N; i++)
{
    if(mas[i]>max)//нахождение максимального элемента и его номера
    {
        max = mas[i];
        indexMax = i+1;
    }

    if (mas[i] == 0 && firstNul == 0)//нахождение первого нулевого элемента
    {
        firstNul = i;
    }
    else if (mas[i] == 0 && firstNul != 0)//нахождение второго нулевого элемента
    {
        secondNul = i;
    }
    {
        firstNul = i;
    }
}
Console.WriteLine();
Console.WriteLine($"номер максимального элемента: {indexMax}");

for(var i=firstNul; i <= secondNul; i++)//нахождение произведения элементов между первым и вторым нулевыми элементами
{
    proizv *= mas[i];
}

if (proizv == 1)//если нулевых элементов нет
{
    Console.WriteLine("нулевых элементов нет");
}
else
{
    Console.WriteLine($"произведение элементов между первым и вторым нулевыми элементами: {proizv}");
}


var newMas = new int[mas.Length];//новый массив
var index = 0;//индекс нового массива

for (var i = 1; i < mas.Length; i += 2) {//заполнение нового массива элементами, стоявшими в нечетных позициях
    newMas[index++] = mas[i];
}

for (var i = 0; i < mas.Length; i += 2) {//заполнение нового массива элементами, стоявшими в четных позициях
    newMas[index++] = mas[i];
}
for(var i = 0; i < N; i++)
{
    Console.Write(newMas[i]+" ");//вывод нового массива
}
}

catch (Exception e)
{
    Console.WriteLine("неправильный формат ввода");
}
//часть 2
Console.WriteLine();
Console.WriteLine("----------------------");//разделитель

var m = 8;//количество строк
var n = 8;//количество столбцов
var matrix = new int[m,n];//матрица
var sum = 0;//сумма элементов матрицы
var same = true;//количество совпадений
var negative = true;//наличие отрицательных элементов

for(var i=0; i<m; i++)
{
    for(var j=0; j<n; j++)
    {
        matrix[i,j] = rnd.Next(-100,100);//заполнение матрицы случайными числами
        Console.Write(matrix[i,j]+" ");//вывод матрицы
    }
    Console.WriteLine();
}

//проверка на совпадение элементов в строке и столбце
for (var k = 0; k < n; k++)
{
    for (var l = 0; l < m; l++)
    {
        if (matrix[k,l] != matrix[l,k])
        {
            same = false;
        }
    }
    if (same)
    {
        Console.WriteLine($"совпадение в строке {k} и столбце {k}");
    }
}
if(!same)
{
    Console.WriteLine("совпадений нет");
}

//нахождение суммы элементов в строках с отрицательными элементами
for (var i = 0; i < n; i++)
{
    for(var j = 0; j < m; j++)
    {
        if(matrix[i,j]<0)//проверка на отрицательные элементы
        {
            negative = false;
            break;
        }
    }
    if(!negative)
    {
        for(var j = 0; j < m; j++)
        {
            sum += matrix[i,j];//нахождение суммы 
        }
    }
}
Console.WriteLine($"сумма элементов в строках с отрицательными элементами: {sum}");

if(negative)
{
    Console.WriteLine("отрицательных элементов нет");
}

Console.ReadKey();
