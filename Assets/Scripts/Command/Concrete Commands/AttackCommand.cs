using Command.Main;

namespace Command.Commands
{

    public class AttackCommand : IUnitCommand
    {
        private bool willHitTarget;


        public AttackCommand(CommandData commandData)
        {
            base.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}