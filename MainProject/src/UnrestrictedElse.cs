using BOOSE;

namespace MainProject
{
	public class UnrestrictedElse : Else 
	{
		public UnrestrictedElse()
		{
			ReduceRestrictions();
		}

		public override void Restrictions() { }
	}
}
