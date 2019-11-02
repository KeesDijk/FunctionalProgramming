using System;

namespace InfraStrcuture
{
    public struct InjectedParam
    {
        public Type TypeOfParam;
        public Object Value;

        public InjectedParam(Type type, object value)
        {
            TypeOfParam = type;
            Value = value;
        }
    }
}