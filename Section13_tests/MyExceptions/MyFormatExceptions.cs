using System;

namespace MyExceptions {
    class MyPersonalExceptions : Exception {

        public MyPersonalExceptions(string msg) : base(msg) {
        }
    }
}