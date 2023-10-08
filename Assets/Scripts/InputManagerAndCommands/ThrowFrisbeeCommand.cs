namespace DefaultNamespace
{
    public class ThrowFrisbeeCommand : ICommand
    {
        public void Execute(PlayerFacadeScript player)
        {
            player.ThrowFrisbee();
        }
    }
}