using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class Graph : MonoBehaviour
    {

        public GameObject CloneCube;
        public List<Transform> Listtr=new List<Transform>();
        void Start() 
        {
//        print(Math.Pow(3,2));
            CreatGraph();
            if (Input.anyKeyDown)
            {
                Debug.Log(Input.anyKey);
                
            }
        }
	
       
        void Update () {
            for (int i = 0; i < Listtr.Count; i++)
            {
                Listtr[i].position=new Vector3(Listtr[i].position.x,0.5f*(float)Math.Sin(Math.PI * (Listtr[i].position.x + Time.time))+1,Listtr[i].position.z);
            }
        }

        void CreatGraph()
        {
            for (float i = -5; i < 5; i+=0.2f)
            {
                if (CloneCube)
                {
                    GameObject go=	Instantiate(CloneCube, new Vector3(i, GetYValue(i), 0), Quaternion.identity);
                    go.transform.SetParent(transform);
                    Listtr.Add(go.transform);
                }
            }
        }
        float GetYValue(float XValue)
        {
//		double x=Math.Pow((XValue - 1), 4) + Math.Pow(XValue, 3) * 5 - Math.Pow(XValue, 2) * 8 + XValue * 3;
            double x=Math.Sin(XValue);
            return (float) x;
        }
    }
}