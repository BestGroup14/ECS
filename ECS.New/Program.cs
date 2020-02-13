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
        }
    }
}
