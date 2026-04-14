using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int targetCount,
        int bonus,
        int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal is already complete.");
            return 0;
        }

        _amountCompleted++;

        if (_amountCompleted >= _targetCount)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetCount;
    }

    public override string GetDetailsString()
    {
        return $"{GetStatusSymbol()} {GetShortName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_targetCount}|{_amountCompleted}";
    }
}