using BOOSE;

namespace BOOSE.Interpreter
{
    /// <summary>
    /// Represents the unrestricted 'real' command for handling real numbers.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Real.html">
	/// BOOSE.Real
	/// </seealso>
    public class UnrestrictedReal : Real, ICommand
    {
        /// <summary>
        /// Removes restrictions on the 'real' command (overridden method).
        /// </summary>
        public override void Restrictions() { }
    }
}
