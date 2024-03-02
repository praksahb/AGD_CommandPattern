using Command.Player;

namespace Command.Commands
{
    public abstract class IUnitCommand : ICommand
    {
        private CommandData _commandData;

        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;

        public void SetTargetUnit(UnitController targetUnit) => this.targetUnit = targetUnit;

        public abstract void Execute();

        public abstract bool WillHitTarget();
    }
}