public struct Range
{
   public bool Absolute;//true => 절대적 값, flase =>상대적인 값
   public float ragne;//사거리
   public float area;//범위 면적(1=>반지름? 지름 정도로 보면 될듯)
   public bool friendlyActivate;
   public int applyMax;//적용 최대값 -1=>무제한
    //Target target
}

public struct Attack
{
    public bool activate;
    public bool selfApply;
    public float power;
    public Range ragne;
    public StatePhase state;
    //Target target;

    

}


/*상태이상은 따로 빼자*/
public struct Buff//아군에게 주는 상태
{
    public bool activate;
    public bool selfApply;
    public float time;
    public StatePhase state;
    public Range range;
}

public struct DeBuff//적군에게 주는 상태
{
    public bool activate;
    public bool selfApply;
    public bool time;// -1 무제한
    public StatePhase state;
    public Range range;


}


