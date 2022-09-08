using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using PolyNav;

namespace NodeCanvas.Tasks.Actions
{

    [Name("Wander2D")]
    [Category("PolyNav")]
    public class Wandeer2D : ActionTask<PolyNavAgent>
    {

        private BBParameter<Vector2> targetPosition;
        public BBParameter<float> maxDisPerStep = 0.6f;
        public BBParameter<float> minDisPerStep = 0.4f;
        public BBParameter<float> maxMoveDis = 1.0f;
        public BBParameter<float> maxWaitTime = 0.8f;
        public BBParameter<float> minWaitTime = 0.4f;

        public BBParameter<float> speed = 4f;

        // private BBParameter<GameObject> selfObj;
        private Vector2 curPos, orgPos;
        private bool isOrg = true;
        protected override string info
        {
            get { return string.Format("GoTo {0}", targetPosition); }
        }

        protected override void OnExecute()
        {
            if (isOrg == true)
            {
                orgPos = agent.transform.position;
                isOrg = false;
            }
            curPos = agent.transform.position;
            agent.maxSpeed = speed.value;

            agent.position = curPos;
            Vector2 offSet2D;
            float rdm=Random.Range(minDisPerStep.value, maxDisPerStep.value);
            while(true){
                offSet2D = Random.insideUnitCircle.normalized;
                if(Vector2.Distance(orgPos,curPos + offSet2D * rdm)<maxMoveDis.value)
                break;
            }
            targetPosition = curPos + offSet2D * rdm;
            float waitTime=Random.Range(minWaitTime.value,maxWaitTime.value);
            DoWalk2D();
            // Invoke("DoWalok2D",waitTime);
            Debug.Log(elapsedTime);
        }

        private void DoWalk2D(){
            if (!agent.SetDestination(targetPosition.value, (bool canGo) => { EndAction(canGo); }))
                EndAction(false);
        }
        protected override void OnStop()
        {
            agent.Stop();   
        }
    }
}