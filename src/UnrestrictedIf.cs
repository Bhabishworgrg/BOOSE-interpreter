using BOOSE;

namespace MainProject
{
    /// <summary>
    /// Represents an unrestricted If command in BOOSE with reduced restrictions.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.If.html">
	/// BOOSE.If
	/// </seealso>
    public class UnrestrictedIf : CompoundCommand, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnrestrictedIf"/> class, reducing restrictions for the command.
        /// </summary>
        public UnrestrictedIf()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// Override restrictions to remove them.
        /// </summary>
        public override void Restrictions() { }
    }
}
