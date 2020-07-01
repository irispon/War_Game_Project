using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonBasicAI:MonoBehaviour,ISlave,IMaster
{
    protected Tendency tendency;
    protected float mentality;
    protected float motivate;
    List<WonBasicAI> slaves;
    WarGameUnit unit;
    IMaster master;
    AIUnitAdater aiUnitAdater;
    BoxCollider2D boxCollider2D;
    FieldOfView fieldOfView;
    //주 종 슬레이브. 관리자->커맨더->병사로 계보를 이음.


    public virtual List<Transform> Search()
    {
        List<Transform> targets= fieldOfView.GetTargetsTransform(Act);
        targets.Remove(transform);
        foreach (Transform transform in targets)
        {
           Debug.Log(transform.name);

        }
        return null;

    }
    public virtual void Active(Targeter targeter)
    {

    }
    public virtual void Patroll(Vector2 start,Vector2 destination)
    {

    }
    public void Start()
    {
        aiUnitAdater = AIUnitAdater.GetAIUnitAdater(gameObject);
        aiUnitAdater.wonBasicAI = this;
        boxCollider2D = GetComponent<BoxCollider2D>();
        fieldOfView = FieldOfView.GetComponent(gameObject);

    }
    public void Update()
    {
     //   Search();
    }
    public void Destroy()
    {

        Destroy(this);

    }

    public virtual void MoveTo(Vector2 start, Vector2 destination)
    {
        
    }

    public void Release(ISlave slave)//Master
    {
        slaves.Remove((WonBasicAI)slave);
    }

    public void Join(ISlave slave)//Master
    {
        slaves.Add((WonBasicAI)slave);
    }

    public static T GetAI<T>(GameObject gameObject) where T: WonBasicAI
    {

        T ai = gameObject.GetComponent<T>();

        if (ai == null)
        {
            ai = gameObject.AddComponent<T>();
        }     

        return ai;
         
    }

    public T Change<T>(WonBasicAI ai,GameObject gameObject) where T : WonBasicAI
    {
        Destroy(this);
        ai = GetAI<T>(gameObject);
        return GetAI<T>(gameObject);


    }
    void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward*5,Color.red);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 들어감");
        Debug.Log(other.transform);



    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("트리거 나감");
    }

    void OnTriggerStay(Collider other)
    {

        Debug.Log("test");
    }

    public void Act(Transform transform)
    {
        Debug.Log(transform.name);

    }
}
