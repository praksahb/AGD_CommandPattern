using Command.Main;

namespace Command.Commands
{
    public class HealCommand : IUnitCommand
    {
        private bool willHitTarget;

        public HealCommand(CommandData commandData)
        {
            base.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}