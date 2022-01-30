using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goaltype;
    public Interact player;

    public bool foundObject()
    {
        return player.hasStone;
    }
}

public enum GoalType
{
    Gathering
}