using System;

namespace Mancala.Core
{
    public class ConditionalAction
    {
        private readonly Func<bool> condition;
        private readonly Action action;

        public ConditionalAction(Func<bool> condition, Action action)
        {
            this.condition = condition;
            this.action = action;
        }

        public void Invoke()
        {
            if (condition.Invoke())
                action.Invoke();
        }
    }
}
