using Gestures;
using Interfaces;
using Services;
using UnityEngine;
using Zinnia.Action;
using Zinnia.Process;

namespace Actions {
    public class CustomGestureBoolAction : BooleanAction, IProcessable {

        [SerializeField]
        private OVRHand.Hand hand;
        [SerializeField]
        private CustomGestures gesture;

        private IGestureChecker gestureChecker;

        protected override void Start() {
            gestureChecker = ServiceLocator.GetService<IGestureChecker>();
        }

        public void Process() {
            Receive(gestureChecker.GetCustomGesture(hand, gesture));
        }
    }
}