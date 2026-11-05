using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GamePhase phase;
    public event Action<GamePhase> OnPhaseChanged;

    public GamePhase CurrentPhase => phase;

    public void ChangePhase(GamePhase phase)
    {
        if (this.phase == phase)
            return;

        this.phase = phase;
        OnPhaseChanged?.Invoke(this.phase);
    }
}