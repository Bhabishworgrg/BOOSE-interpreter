using BOOSE;

namespace MainProject
{
	public class UnrestrictedWhile : CompoundCommand, ICommand
	{
		public UnrestrictedWhile()
		{
			ReduceRestrictions();
		}
        
		public override void Restrictions() { }
	}
}
