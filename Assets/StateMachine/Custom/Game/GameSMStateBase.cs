using UnityEngine;
using System.Collections;

namespace StateMachine.GameSM
{
    public class GameSMStateBase : StateBase
    {
        protected GameSMContext context;
        public override void Setup(IStateMachineContext _context)
        {
            context = _context as GameSMContext;
        }
    }
}
