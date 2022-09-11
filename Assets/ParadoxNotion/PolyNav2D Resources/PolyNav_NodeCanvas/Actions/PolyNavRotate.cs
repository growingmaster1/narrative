using UnityEngine;
using System.Collections;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using PolyNav;
namespace narrative.Assets.ParadoxNotion.PolyNav2D_Resources.PolyNav_NodeCanvas.Actions
{
    [Name("Rotate")]
    [Category("PolyNav")]
    public class PolyNavRotate : ActionTask<PolyNavAgent>
    {
        public BBParameter<float> speed = 4;
        public BBParameter<GameObject> targetObject;

        public BBParameter<float> maxDis = 3;
        public BBParameter<float> minDis = 1;
        // private GameObject gameObject;
        private BBParameter<GameObject> selfObject;

        public BBParameter<float> rotateAngle = 50.0f;


        protected override void OnExecute()
        {
            float targetAngle;
            agent.maxSpeed = speed.value;
            Vector2 cur=(targetObject.value.transform.position-agent.transform.position).normalized;
            float angle=Vector2.Angle(new Vector2(1,0),cur);
            targetAngle=angle+rotateAngle.value;
            Vector3 targetVec=new Vector3(Mathf.Cos(targetAngle),Mathf.Sin(targetAngle),0);
            // targetObject.value.transform.position=Random.Range(minDis.value,maxDis.value)*targetVec+agent.position;
            // if()
            // if(targetVec)
            if (!agent.SetDestination(targetObject.value.transform.position+Random.Range(minDis.value,maxDis.value)*targetVec, (bool canGo) => { EndAction(canGo); }))
                EndAction(false);
        }

        protected override void OnStop()
        {
            agent.Stop();
        }
    }
}