using Command.Commands;
using Command.Main;
using Command.Player;

namespace Command.Input
{
    public class InputService
    {
        private MouseInputHandler mouseInputHandler;

        private InputState currentState;
        private CommandType selectedCommandType;
        private TargetType targetType;

        public InputService()
        {
            mouseInputHandler = new MouseInputHandler(this);
            SetInputState(InputState.INACTIVE);
            SubscribeToEvents();
        }

        public void SetInputState(InputState inputStateToSet) => currentState = inputStateToSet;

        private void SubscribeToEvents() => GameService.Instance.EventService.OnActionSelected.AddListener(OnActionSelected);

        public void UpdateInputService()
        {
            if (currentState == InputState.SELECTING_TARGET)
                mouseInputHandler.HandleTargetSelection(targetType);
        }

        public void OnActionSelected(CommandType selectedCommandType)
        {
            this.selectedCommandType = selectedCommandType;
            SetInputState(InputState.SELECTING_TARGET);
            TargetType targetType = SetTargetType(selectedCommandType);
            ShowTargetSelectionUI(targetType);
        }

        private void ShowTargetSelectionUI(TargetType selectedTargetType)
        {
            int playerID = GameService.Instance.PlayerService.ActivePlayerID;
            GameService.Instance.UIService.ShowTargetOverlay(playerID, selectedTargetType);
        }

        private TargetType SetTargetType(CommandType selectedActionType) => targetType = GameService.Instance.ActionService.GetTargetTypeForAction(selectedActionType);

        public void OnTargetSelected(UnitController targetUnit)
        {
            // Set the input state to EXECUTING_INPUT when a target unit is selected.
            SetInputState(InputState.EXECUTING_INPUT);

            // Create a UnitCommand based on the selected target unit.
            IUnitCommand commandToProcess = CreateUnitCommand(targetUnit);

            // This line passes the created command to the GameService for further Processsing.
            GameService.Instance.ProcessUnitCommand(commandToProcess);
        }

        private CommandData CreateCommandData(UnitController targetUnit)
        {
            return new CommandData
                (
                    GameService.Instance.PlayerService.ActiveUnitID,
                    targetUnit.UnitID, GameService.Instance.PlayerService.ActivePlayerID,
                    targetUnit.Owner.PlayerID
                );
        }

        private IUnitCommand CreateUnitCommand(UnitController targetUnit)
        {
            CommandData commandData = CreateCommandData(targetUnit);

            return selectedCommandType switch
            {
                CommandType.Attack => (IUnitCommand)new AttackCommand(commandData),
                CommandType.Heal => (IUnitCommand)new HealCommand(commandData),
                CommandType.AttackStance => (IUnitCommand)new AttackStanceCommand(commandData),
                CommandType.Cleanse => (IUnitCommand)new CleanseCommand(commandData),
                CommandType.BerserkAttack => (IUnitCommand)new BerserkAttackCommand(commandData),
                CommandType.Meditate => (IUnitCommand)new MeditateCommand(commandData),
                CommandType.ThirdEye => (IUnitCommand)new ThirdEyeCommand(commandData),
                _ => throw new System.Exception($"No Command found of type: {selectedCommandType}"),// If the selectedCommandType is not recognized, throw an exception.
            };
        }
    }
}