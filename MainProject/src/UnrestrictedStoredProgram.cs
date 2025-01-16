using BOOSE;

namespace MainProject
{
    /// <summary>
    /// Represents an unrestricted stored program for execution with conditional commands.
    /// </summary>
	///
    /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.StoredProgram.html">
    /// BOOSE.StoredProgram
    /// </seealso>
    public class UnrestrictedStoredProgram : StoredProgram
    {
        private Stack<ConditionalCommand> conditionalPair = new Stack<ConditionalCommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnrestrictedStoredProgram"/> class.
        /// </summary>
		///
        /// <param name="canvas">The canvas used for program execution.</param>
        public UnrestrictedStoredProgram(ICanvas canvas) : base(canvas) { }

        /// <summary>
        /// Pushes a conditional command onto the stack.
        /// </summary>
        /// 
		/// <param name="Com">The conditional command to push.</param>
		/// 
        /// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.StoredProgram#BOOSE_StoredProgram_Push_BOOSE_ConditionalCommand_.html">
        /// BOOSE.StoredProgram.Push
        /// </seealso>
        public override void Push(ConditionalCommand Com)
        {
            conditionalPair.Push(Com);
        }

        /// <summary>
        /// Pops a conditional command from the stack.
        /// </summary>
        /// 
		/// <returns>The popped conditional command.</returns>
        /// <exception cref="StoredProgramException">Thrown when an orphaned end-while/if/for/method is detected.</exception>
		///
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.StoredProgram#BOOSE_StoredProgram_Pop.html">
		/// BOOSE.StoredProgram.Pop
		/// </seealso>
        public override ConditionalCommand Pop()
        {
            try
            {
                return conditionalPair.Pop();
            }
            catch (InvalidOperationException)
            {
                throw new StoredProgramException("Orphaned end-while/if/for/method");
            }
        }

        /// <summary>
        /// Runs the stored program.
        /// </summary>
		///
        /// <exception cref="StoredProgramException">Thrown when an error is encountered during execution or if an infinite loop is detected.</exception>
        ///
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.StoredProgram#BOOSE_StoredProgram_Run.html">
		/// BOOSE.StoredProgram.Run
		/// </seealso>
		public override void Run()
        {
            int num = 0;

            while (base.Commandsleft())
            {
                ICommand command = (ICommand)base.NextCommand();
                try
                {
                    num++;
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

            if (conditionalPair.Count != 0)
            {
                Pop();
                base.SyntaxOk = false;
                throw new StoredProgramException("Missing end");
            }
        }
    }
}
