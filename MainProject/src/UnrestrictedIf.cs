using BOOSE;

namespace MainProject
{
	public class UnrestrictedIf : CompoundCommand, ICommand
	{
		public UnrestrictedIf()
		{
			ReduceRestrictions();
		}

        public override void Restrictions() { }
	}
}
