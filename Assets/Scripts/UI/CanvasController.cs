
public class CanvasController 
{
    private CanvasView _canvasView;
    private PlayerModel _playerModel;

    public CanvasController(CanvasView canvasView, PlayerModel playerModel)
    {
        _canvasView = canvasView;
        _playerModel = playerModel;
        _playerModel.OnBonusCollect += AddBonus;
    }

    private void AddBonus(Bonus bonus)
    {
        _canvasView.AddBonus(bonus.BonusData.Item);
    }
}
 