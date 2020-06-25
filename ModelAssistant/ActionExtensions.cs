using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;

namespace ModelAssistant {

    using static F;

    public static partial class F {

        public static Unit Unit()
            => default(Unit);
    }

    public static class ActionExtensions {

        public static Func<Unit> ToFunc(this Action action)
            => () => { action(); return Unit(); };

        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
            => (t) => { action(t); return Unit(); };

        public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
            => (t1, t2) => { action(t1, t2); return Unit(); };

        public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> action)
            => (t1, t2, t3) => { action(t1, t2, t3); return Unit(); };

        public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
            => (t1, t2, t3, t4) => { action(t1, t2, t3, t4); return Unit(); };
    }
}
