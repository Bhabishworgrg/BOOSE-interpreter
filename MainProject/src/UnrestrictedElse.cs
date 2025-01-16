using BOOSE;

namespace MainProject
{
    /// <summary>
    /// Represents an unrestricted Else command in BOOSE with reduced restrictions.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Else.html">
	/// BOOSE.Else
	/// </seealso>
    public class UnrestrictedElse : Else, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnrestrictedElse"/> class.
        /// </summary>
        public UnrestrictedElse()
        {
            ReduceRestrictions();
        }

        /// <summary>
		/// Override the restrictions to remove them.
        /// </summary>
        public override void Restrictions() { }
    }
}
