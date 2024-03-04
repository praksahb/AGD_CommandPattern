using Command.Main;

namespace Command.Commands
{
    public class AttackStanceCommand : IUnitCommand
    {
        private CommandData _commandData;

        private bool willHitTarget;


        public AttackStanceCommand(CommandData commandData)
        {
            base.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}