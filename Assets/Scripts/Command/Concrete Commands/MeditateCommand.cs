using Command.Main;

namespace Command.Commands
{
    public class MeditateCommand : IUnitCommand
    {
        private bool willHitTarget;


        public MeditateCommand(CommandData commandData)
        {
            base.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}