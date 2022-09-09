using UnityEngine;
using System.Collections;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using PolyNav;

namespace NodeCanvas.Tasks.Actions
{

    [Name("Wander")]
    [Category("PolyNav")]
    public class PolyNavWander : ActionTask<PolyNavAgent>
    {

        public BBParameter<float> speed = 4;
        public BBParameter<float> keepDistance = 0.1f;
        public BBParameter<float> minWanderDistance = 5;
        public BBParameter<float> maxWanderDistance = 20;
        public bool repeat = true;

        protected override void OnExecute() {
            agent.maxSpeed = speed.value;
            DoWander();
        }

        protected override void OnUpdate() {
            if ( !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + keepDistance.value ) {
                if ( repeat ) {
                    DoWander();
                } else {
                    EndAction();
                }
            }
        }

        void DoWander() {
            var min = minWanderDistance.value;
            var max = maxWanderDistance.value;
            min = Mathf.Clamp(min, 0.01f, max);
            max = Mathf.Clamp(max, min, max);
            var wanderPos = agent.position;
            while ( ( wanderPos - agent.position ).sqrMagnitude < min || !agent.map.PointIsValid(wanderPos) ) {
                wanderPos = ( Random.insideUnitCircle * max ) + agent.position;
            }

            if ( agent.map.PointIsValid(wanderPos) ) {
                agent.SetDestination(wanderPos);
            }
        }

        protected override void OnPause() { OnStop(); }
        protected override void OnStop() {
            agent.Stop();
        }
    }
}