using BOOSE;

namespace MainProject
{
	public class UnrestrictedReal : Real, ICommand
	{
        public override void Restrictions() { }
	}
}
