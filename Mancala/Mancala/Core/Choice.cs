using System;

namespace Mancala.Core
{
    public class Choice
    {
        private readonly Func<bool> question;
        private readonly Action yes;
        private readonly Action no;

        public Choice(Func<bool> question, Action yes, Action no)
        {
            this.question = question;
            this.yes = yes;
            this.no = no;
        }

        public void Choose()
        {
            if (question.Invoke())
                yes.Invoke();
            else
                no.Invoke();
        }
    }
}
