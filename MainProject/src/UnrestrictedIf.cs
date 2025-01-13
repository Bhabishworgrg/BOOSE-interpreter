using BOOSE;

namespace MainProject
{
	public class UnrestrictedIf : CompoundCommand
	{
		public UnrestrictedIf()
		{
			ReduceRestrictions();
		}

        public override void Restrictions() { }
	}
}
