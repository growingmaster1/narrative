using UnityEngine;
using System.Collections;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using PolyNav;

namespace NodeCanvas.Tasks.Actions
{

    [Name("Flee")]
    [Category("PolyNav")]
    public class PolyNavFlee : ActionTask<PolyNavAgent>
    {

        public BBParameter<GameObject> target;
        public BBParameter<float> speed = 4f;
        public BBParameter<float> fledDistance = 10f;
        public BBParameter<float> lookAhead = 2f;


        protected override string info {
            get { return string.Format("Flee from {0}", target); }
        }

        protected override void OnExecute() {
            if ( target == null ) { EndAction(false); return; }
            agent.maxSpeed = speed.value;
            if ( ( agent.position - (Vector2)target.value.transform.position ).magnitude >= fledDistance.value ) {
                EndAction(true);
                return;
            }
        }

        protected override void OnUpdate() {
            if ( target == null ) { EndAction(false); return; }
            var targetPos = (Vector2)target.value.transform.position;
            if ( ( agent.position - targetPos ).magnitude >= fledDistance.value ) {
                EndAction(true);
                return;
            }

            var fleePos = targetPos + ( agent.position - targetPos ).normalized * ( fledDistance.value + lookAhead.value + agent.stoppingDistance );
            if ( !agent.SetDestination(fleePos) ) {
                EndAction(false);
            }
        }

        protected override void OnPause() { OnStop(); }
        protected override void OnStop() {
            agent.Stop();
        }
    }
}