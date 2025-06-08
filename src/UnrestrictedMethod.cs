using BOOSE;
using System.Reflection;

namespace BOOSE.Main
{
    /// <summary>
    /// Represents an unrestricted method command in BOOSE with reduced restrictions.
    /// </summary>
    public class UnrestrictedMethod : Method
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnrestrictedMethod"/> class, reducing restrictions and resetting counts.
        /// </summary>
        public UnrestrictedMethod()
        {
            base.ReduceRestrictions();
        	SetRestrictionVariablesToZero();
		}

        /// <summary>
		/// Sets the restriction variable to zero.
        /// </summary>
        public void SetRestrictionVariablesToZero()
        {
            FieldInfo? fieldInfo = typeof(Method).GetField("뇔", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
			fieldInfo?.SetValue(null, 0);
        }

		/// <summary>
		/// Removes restrictions on Boolean.
		/// </summary>
		public override void Restrictions() { }
    }
}
