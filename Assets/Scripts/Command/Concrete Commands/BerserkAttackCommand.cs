using Command.Main;

namespace Command.Commands
{
    public class BerserkAttackCommand : IUnitCommand
    {
        private CommandData _commandData;

        private bool willHitTarget;


        public BerserkAttackCommand(CommandData commandData)
        {
            _commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}