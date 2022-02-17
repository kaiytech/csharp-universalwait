using System;
using System.Diagnostics;

namespace Whatever
{
    public class Wait
    {
        private Func<bool> _condition;
        private bool _until;

        private Wait(Func<bool> condition, bool until)
        {
            _condition = condition;
            _until = until;
        }

        public static Wait Until(Func<bool> condition) => new(condition, true);

        public static Wait AsLongAs(Func<bool> condition) => new(condition, false);

        public void Is(object target, int timeout = 10)
        {
            if (_condition.Method.ReturnType != target.GetType())
                throw new Exception("Can't compare variables of different type.");

            if (timeout < 1)
                throw new Exception("Timeout needs to be a positive integer");

            var sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed.TotalSeconds <= 10)
            {
                switch (_until)
                {
                    case true when _condition.Invoke().Equals(target):
                    case false when !_condition.Invoke().Equals(target):
                        return;
                }
            }

            throw new Exception($"Timed out while waiting for {_condition} to be {target}");
        }
    }
}
