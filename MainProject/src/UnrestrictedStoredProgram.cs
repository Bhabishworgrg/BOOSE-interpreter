using BOOSE;

namespace MainProject
{
    public class UnrestrictedStoredProgram : StoredProgram
	{
		private Stack<ConditionalCommand> stack = new Stack<ConditionalCommand>();

		public UnrestrictedStoredProgram(ICanvas canvas) : base(canvas) { }

        public override void Push(ConditionalCommand Com)
        {
            stack.Push(Com);
        }

        public override ConditionalCommand Pop()
		{
			try
			{
				return stack.Pop();
			}
			catch (InvalidOperationException)
			{
				throw new StoredProgramException("Orphaned end-while/if/for/method");
			}
		}

		public override void Run()
		{
			int num = 0;
			
			while (base.Commandsleft())
			{
				ICommand command = (ICommand) base.NextCommand();
				try
				{
					command.Execute();
				}
				catch (BOOSEException ex)
				{
					base.SyntaxOk = false;
					throw new StoredProgramException($"{ex.Message} {PC}");
				}
				if (num > 50000 && PC < 20)
				{
					throw new StoredProgramException("Infinite loop");
				}
			}
			if (stack.Count != 0)
			{
				Pop();
				base.SyntaxOk = false;
				throw new StoredProgramException("Missing end");
			}
		}
    
	}
}
