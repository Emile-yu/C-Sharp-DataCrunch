using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace ViewModel.AOP
{
    public class ParameterCheckBehavior : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get { return true; }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            foreach (var item in input.Inputs)
            {
                String var = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            }
            return getNext().Invoke(input, getNext);
        }
    }
}
