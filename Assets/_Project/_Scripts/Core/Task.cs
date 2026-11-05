using System;
using UnityEngine;

[System.Serializable]
public class Task
{
    [SerializeField] private int requiredProgress = 1;
    private int currentProgress = 0;

    public event Action<bool> OnCompletionChanged;

    public void IncreaseProgress()
    {
        bool wasCompleted = IsCompleted();

        if (currentProgress < requiredProgress)
            currentProgress++;

        if (wasCompleted != IsCompleted())
            OnCompletionChanged?.Invoke(IsCompleted());
    }

    public void DecreaseProgress()
    {
        bool wasCompleted = IsCompleted();

        if (currentProgress > 0)
            currentProgress--;

        if (wasCompleted != IsCompleted())
            OnCompletionChanged?.Invoke(IsCompleted());
    }

    public bool IsCompleted()
    {
        return currentProgress >= requiredProgress;
    }
}