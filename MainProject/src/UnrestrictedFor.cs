using BOOSE;

namespace MainProject
{
	public class UnrestrictedFor : For, ICommand
	{
		public override void Restrictions() { }
	}
}
