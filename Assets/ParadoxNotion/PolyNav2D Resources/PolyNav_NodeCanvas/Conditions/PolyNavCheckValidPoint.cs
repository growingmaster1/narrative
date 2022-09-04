using UnityEngine;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using PolyNav;

namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check Valid Point")]
    [Category("PolyNav")]
    public class PolyNavCheckValidPoint : ConditionTask
    {

        public BBParameter<Vector2> position;

        protected override string info {
            get { return string.Format("{0} is valid", position); }
        }

        protected override bool OnCheck() {
            if ( !PolyNavMap.current )
                return false;
            return PolyNavMap.current.PointIsValid(position.value);
        }
    }
}