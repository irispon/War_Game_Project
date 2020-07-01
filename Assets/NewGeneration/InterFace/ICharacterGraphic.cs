

using UnityEngine;

public interface ICharacterGraphic
{
    void Forward();
    void Back();
    void Right();
    void Left();
    void SetChip(WarGameUnitGhraphic graphic);
    void Destroy();

}
