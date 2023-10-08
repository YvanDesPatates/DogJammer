namespace DefaultNamespace
{
    public class DashCommand : ICommand
    {
        public void Execute(PlayerFacadeScript player)
        {
            player.Dash();
        }
    }
}