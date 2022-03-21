using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ShowPath : MonoBehaviour
{
    NavMeshAgent agent;
    LineRenderer lr;
    public WaveCreator m_Creator;
    RoundPlayButton roundPlayButton;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lr = GetComponent<LineRenderer>();
        roundPlayButton = FindObjectOfType<RoundPlayButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roundPlayButton.getRoundStatus())
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position); //set the line's origin

            agent.SetDestination(m_Creator.m_destination.position); //create the path

            DrawPath(agent.path);
        } else
        {
            lr.enabled = false;
        }
    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        lr.positionCount = path.corners.Length;

        for (var i = 1; i < path.corners.Length; i++)
        {
            lr.SetPosition(i, path.corners[i]); //go through each corner and set that to the line renderer's position
        }
    }
}
