using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;

namespace ModelAssistant {

    public static class Extensions {

        public static int? ToNullableInt(this string s) {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> func) where TDisp : IDisposable {
            using (disposable) return func(disposable);
        }

        public static T TimeSpend<T>(Func<T> func) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            T t = func();
            sw.Stop();
            return t;
        }

        public static void TimeSpend(Action action)
            => TimeSpend<Unit>(action.ToFunc());

        public static T Retry<T>(this Func<T> function) {
            int retry = 0;
            T result = default(T);
            bool success = false;
            do {
                try {
                    result = function();
                    success = true;
                }
                catch {
                    retry++;
                }
            } while (!success && retry < 3);

            return result;
        }
    }
}
