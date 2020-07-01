using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUnitAdater :MonoBehaviour
{
    public IWarGameUnit warGameUnit;
    public WonBasicAI wonBasicAI;

    public static AIUnitAdater GetAIUnitAdater(GameObject gameObject)
    {
        AIUnitAdater aiUnitAdater = gameObject.GetComponent<AIUnitAdater>();
        if (aiUnitAdater == null)
        {
            aiUnitAdater = gameObject.AddComponent<AIUnitAdater>();
        }
        return aiUnitAdater;
    }
    
}
