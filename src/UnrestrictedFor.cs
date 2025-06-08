using BOOSE;

namespace MainProject
{
    /// <summary>
    /// Represents an unrestricted For command in BOOSE with reduced restrictions.
    /// </summary>
	///
	/// <seealso href="https://dmullier.github.io/BOOSE-Docs/BOOSE.For.html">
	/// BOOSE.For
	/// </seealso>
    public class UnrestrictedFor : For, ICommand
    {
        /// <summary>
		/// Override the restrictions to remove them.
        /// </summary>
        public override void Restrictions() { }
    }
}
