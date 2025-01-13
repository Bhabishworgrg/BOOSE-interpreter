using BOOSE;

namespace MainProject
{
	public class UnrestrictedWhile : CompoundCommand
	{
		public UnrestrictedWhile()
		{
			ReduceRestrictions();
		}
        
		public override void Restrictions() { }
	}
}
