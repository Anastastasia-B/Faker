using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class ExampleClass
    {
        public string StringProp { get; set; }
        public char CharProp { get; set; }
        public decimal DecimalProp { get; set; }
        public int IntProp { get; }
        public long LongProp { get; }

        public ExampleClass(int i, long l, char c)
        {
            IntProp = i;
            LongProp = l;
            CharProp = c;
        }
    }

    public struct ExampleStruct
    {
        public string StringField { get; set; }
        public char CharField { get; set; }
    }
}
