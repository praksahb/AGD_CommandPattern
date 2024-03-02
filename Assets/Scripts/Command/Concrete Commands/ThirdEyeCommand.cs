using Command.Main;

namespace Command.Commands
{
    public class ThirdEyeCommand : IUnitCommand
    {
        private CommandData _commandData;

        private bool willHitTarget;


        public ThirdEyeCommand(CommandData commandData)
        {
            _commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}