using BOOSE;

namespace BOOSE.Main
{
    /// <summary>
    /// Represents an unrestricted while loop command.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.While.html">
	/// BOOSE.While
	/// </seealso>
    public class UnrestrictedWhile : CompoundCommand, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnrestrictedWhile"/> class.
        /// </summary>
        public UnrestrictedWhile()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// Removes any restrictions on the command.
        /// </summary>
		///
		/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.Boolean#BOOSE_Boolean_Restrictions.html">
		/// BOOSE.Boolean.Restictions
		/// </seealso>
        public override void Restrictions() { }
    }
}
