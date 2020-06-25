using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAssistant {

    using static F;

    public static partial class F {

        public static Option<T> Some<T>(T value)
            => new Option.Some<T>(value);

        public static Option.None None
            => Option.None.Default;
    }

    public struct Option<T> {

        private readonly bool isSome;
        private readonly T value;

        private Option(T value) {
            this.isSome = true;
            this.value = value;
        }

        public static implicit operator Option<T>(Option.None _)
            => new Option<T>();

        public static implicit operator Option<T>(Option.Some<T> some)
            => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value)
            => value == null ? None : Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => isSome ? Some(value) : None();
    }

    namespace Option {

        public struct None {

            internal static readonly None Default = new None();
        }

        public struct Some<T> {

            internal T Value { get; }

            internal Some(T value) {
                if (value == null) throw new ArgumentNullException();
                Value = value;
            }
        }
    }
}
