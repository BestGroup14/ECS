using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.New
{
    public class ECSClass
    {
        private int _threshold;
        private int _upperthreshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public ECSClass(int thr, int upperthr,ITempSensor tempSensor, IHeater heater, IWindow window)
        {
            SetThreshold(thr);
            SetUpperThreshold(upperthr);
            _tempSensor = tempSensor;
            _heater = heater;
            _window = window;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold && t < _upperthreshold)
            {
                _heater.TurnOn();
                _window.CloseWindow();
            }
            else if (t > _threshold && t > _upperthreshold)
            {
                _heater.TurnOff();
                _window.OpenWindow();
            }
            else if (t > _threshold && t < _upperthreshold)
            {
                _heater.TurnOff();
                _window.CloseWindow();
            }
        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public void SetUpperThreshold(int upperthr)
        {
            _upperthreshold = upperthr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
