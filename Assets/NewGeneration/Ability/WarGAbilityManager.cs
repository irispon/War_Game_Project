using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarGAbilityManager : SingletonObject<WarGAbilityManager>
{
    WDictionary<string, WarGameAbility> abilitiesDictionary;

    private void Start()
    {
        abilitiesDictionary = new WDictionary<string, WarGameAbility>();

    }

    public void AddAbility(WarGameAbility warGameAbility)
    {
        abilitiesDictionary.Add(warGameAbility.uniqId, warGameAbility);

    }

    public WarGameAbility GetAbility(string uniqId)
    {


        return (WarGameAbility)abilitiesDictionary[uniqId].Clone();
    }


}
