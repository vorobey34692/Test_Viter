using System;

public class EventManager
{
    public static event Action Start;
    public static event Action Loose;
    public static event Action Win;

    public static void OnStart() => Start?.Invoke();
    public static void OnLoose() => Loose?.Invoke();
    public static void OnWin() => Win?.Invoke();
}
