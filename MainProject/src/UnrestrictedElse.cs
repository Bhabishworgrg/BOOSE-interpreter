using BOOSE;

namespace MainProject
{
	public class UnrestrictedElse : Else, ICommand
	{
		public UnrestrictedElse()
		{
			ReduceRestrictions();
		}

		public override void Restrictions() { }
	}
}
