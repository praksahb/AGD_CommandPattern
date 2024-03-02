using Command.Main;

namespace Command.Commands
{

    public class AttackCommand : IUnitCommand
    {
        private CommandData _commandData;

        private bool willHitTarget;


        public AttackCommand(CommandData commandData)
        {
            _commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}