﻿using InquirerCore.Console;
using System.Linq;

namespace InquirerCore.Prompts
{
    public class Input : BasePrompt
    {
        private string answer;
        public Input(string name, string message, IRender consoleRender, IConsole console = null) : base(name, message, consoleRender, console)
        {
        }

        public override string Answer()
        {
            return answer;
        }

        public override void Ask()
        {
            var pos = consoleRender.RenderMultipleMessages(GetQuestion());
            answer = Console.ReadLine();
            while (!IsValidAnswer(answer))
            {
                consoleRender.Clean(pos[0, 1], pos[1, 1]);
                consoleRender.RenderMultipleMessages(GetQuestion());
                answer = Console.ReadLine();
            }
        }

        public override string[] GetQuestion()
        {
            return new string[] { message };
        }

        public override void Render()
        {
            GetQuestion().ToList().ForEach(line => Console.WriteLine(line));
        }
    }
}
