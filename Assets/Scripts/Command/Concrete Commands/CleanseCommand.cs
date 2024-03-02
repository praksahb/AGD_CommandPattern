using Command.Main;

namespace Command.Commands
{
    public class CleanseCommand : IUnitCommand
    {
        private CommandData _commandData;

        private bool willHitTarget;


        public CleanseCommand(CommandData commandData)
        {
            _commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}