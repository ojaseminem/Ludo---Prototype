namespace Managers
{
    public class EnumManager
    {
        
    }
    
    public enum GameStates
    {
        PreGame,
        Playing,
        Paused,
        Won,
        Lost,
        Quit
    }

    public enum PlayerType
    {
        Player1,
        Player2,
        Player3,
        Player4,
        AI1,
        AI2,
        AI3,
        AI4
    }
    
    public enum CellType
    {
        White,
        Red,
        Green,
        Blue,
        Yellow,
        ArrowR,
        ArrowG,
        ArrowB,
        ArrowY,
        SafeZone
    }

    public enum PieceType
    {
        Blue,
        Red,
        Green,
        Yellow,
        ResetLoop
    }

    public enum HomeCellType
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public enum UITypes
    {
        StartScreen,
        PlayerDataScreen,
        
    }
}