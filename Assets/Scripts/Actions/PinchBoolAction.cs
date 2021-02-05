using Interfaces;
using Services;
using UnityEngine;
using Zinnia.Action;
using Zinnia.Process;

namespace Actions {
    public class PinchBoolAction : BooleanAction, IProcessable {

        [SerializeField]
        private OVRHand.Hand hand;
        [SerializeField]
        private OVRHand.HandFinger finger;

        private IGestureChecker gestureChecker;

        protected override void Start() {
            gestureChecker = ServiceLocator.GetService<IGestureChecker>();
        }

        public void Process() {
            Receive(gestureChecker.GetPinchGesture(hand, finger));
        }
    }
}