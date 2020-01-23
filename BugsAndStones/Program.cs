using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugsAndStones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> emptySegments = new List<long>();//список размеров пустых отрезков
            Console.WriteLine("Введите число камней");
            long stonesCount = Convert.ToInt64(Console.ReadLine());//Количество камней
            Console.WriteLine("Введите число жуков < числа камней");
            long bugsCount = Convert.ToInt64(Console.ReadLine());//Количество жуков

            emptySegments.Add(stonesCount);//Помещаем в список размер первого пустого отрезка (стартовое количество камней)

            Console.WriteLine();
            for(int i = 0; i < bugsCount; i++)
            {
                long maxSegment = emptySegments[0];//Выбираем из списка размер максимального свободного отрезка, он всегда первый в списке
                DivideResult divideResult = Divide(maxSegment);//Делим этот отрезок на 2 части (помещаем жука в центр)
                if (i == bugsCount - 1)//Проверяем последний ли это жук, и если да то выводим результат на экран
                {
                    Console.WriteLine("Число незанятых камней слева и справа");
                    Console.WriteLine(divideResult.LeftSegmentSize.ToString() + "/" + divideResult.RightSegmentSize.ToString());
                    Console.ReadLine();
                    return;
                }


                emptySegments.Remove(maxSegment); //Убираем из списка только что разделенный отрезок (а точнее его размер)                
                emptySegments.Add(divideResult.RightSegmentSize); //Добавляем размер отрезка справа от только что помещенного жука
                emptySegments.Add(divideResult.LeftSegmentSize); //Добавляем размер отрезка слева от только что помещенного жука
            }            
        }

        /// <summary>
        /// Вычисляет размер отрезка слева и размер отрезка справа от помещенного жука
        /// </summary>
        /// <param name="segmentSize">Размер входного отрезка для разделения</param>
        /// <returns></returns>
        static DivideResult Divide(long segmentSize)
        {
            DivideResult r = new DivideResult();
            if(segmentSize % 2 != 0)//если число нечетное
            {
                r.LeftSegmentSize = (segmentSize - 1) / 2;
                r.RightSegmentSize = (segmentSize - 1) / 2;
            }
            else
            {
                r.LeftSegmentSize = (segmentSize / 2) - 1;
                r.RightSegmentSize = segmentSize / 2;
            }
            return r;
        }
    }
}
