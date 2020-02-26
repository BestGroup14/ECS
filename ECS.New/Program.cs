using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.New
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempsensor = new TempSensor();
            var heater = new Heater();
            var window = new Window();
            var ecs = new ECSClass(28,40,tempsensor,heater,window);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();

            bool cont = true;
            int _value = 0;
            int _uppervalue = 0;

            while (cont)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char keyChar = keyInfo.KeyChar;
                if (keyChar == 'a')
                {
                    _value = Convert.ToInt32(Console.ReadLine());
                    ecs.SetThreshold(_value);
                }

                if (keyChar == 'b')
                {
                    _uppervalue = Convert.ToInt32(Console.ReadLine());
                    ecs.SetUpperThreshold(_uppervalue);
                }

            }
        }
    }
}
