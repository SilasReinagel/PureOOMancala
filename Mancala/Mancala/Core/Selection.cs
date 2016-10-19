using System;

namespace Mancala.Core
{
    public class Selection<T>
    {
        private readonly Predicate<T> conditional;
        private readonly T trueValue;
        private readonly T falseValue;

        public Selection(Predicate<T> conditional, T trueValue, T falseValue)
        {
            this.conditional = conditional;
            this.trueValue = trueValue;
            this.falseValue = falseValue;
        }

        public T Choose(T condition)
        {
            return conditional(condition) ? trueValue : falseValue;
        }
    }
}
