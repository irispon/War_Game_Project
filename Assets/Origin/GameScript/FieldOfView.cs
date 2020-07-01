﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask[] targetMask;
    public LayerMask[] obstacleMask;
    public bool test =true;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
      //  StartCoroutine("FindTargetsWithDelay", .2f);
      //  StartCoroutine(FindTargetsWithDelay(.2f));
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
          // FindVisibleTargets();
        }
    }

    public List<Transform> GetTargetsTransform(Act act=null)
    {
        visibleTargets.Clear();
        Debug.Log("targetMask" + targetMask);
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, LayerMaskUtill.Composit(targetMask));
       Debug.Log("루틴 테스트"+ targetsInViewRadius.Length);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;// 방향 설정
            if (Vector3.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, LayerMaskUtill.Composit(obstacleMask)))
                {
                   
                        visibleTargets.Add(target);
                        act(target);
                    

                }
            }
        }
        return visibleTargets;
    }

    public List<Collider2D> GetTargetsCollider2D(Act act=null)
    {
        visibleTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, LayerMaskUtill.Composit(targetMask));
        List<Collider2D> targetCollider = new List<Collider2D>();
        Debug.Log("루틴 테스트" + targetsInViewRadius.Length);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;// 방향 설정
            if (Vector3.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, LayerMaskUtill.Composit(obstacleMask)))
                {
                    targetCollider.Add(targetsInViewRadius[i]);
                    act(target);
                }
            }
        }

        return targetCollider;
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


    public static FieldOfView GetComponent(GameObject gameObject)
    {
        FieldOfView fieldOfView= gameObject.GetComponent<FieldOfView>();

        if (gameObject.GetComponent<FieldOfView>() == null)
        {
            fieldOfView = gameObject.AddComponent<FieldOfView>();
        }
       
        return fieldOfView;
    }


    public delegate void Act(Transform transform);
}