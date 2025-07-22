using UnityEngine;

namespace Cobra.Utilities
{
    public class Illion
    {
        private class Section
        {
            private int tri;
            private Section next;
            public int Value => GetValue();

            private int GetValue() // use keyword checked
            {
                int thou = tri;
                if (next != null)
                {
                    thou += next.Value * 1000;
                }
                return thou;
            }

            public void Add(int value)
            {
                //make sure this section doesn't get too big
                //else
                tri += value;
                int extra = tri / 1000;
                tri %= 1000;
                Propagate(extra);
            }

            private void Propagate(int value)
            {
                if (value > 0)
                {
                    if (next == null)
                    {
                        next = new Section(value);
                        return;
                    }
                    next.Add(value);
                }
            }

            public Section(int value)
            {
                // make sure not too big
                tri = value;
            }
        }
        
        private Section section;
        public int Value => GetValue();

        private int GetValue()
        {
            return section.Value;
        }

        public static Illion operator +(Illion self, int value)
        {
            self.Add(value);
            return self;
        }
        public static Illion operator -(Illion self, int value)
        {
            self.Subtract(value);
            return self;
        }

        private void Add(int value)
        {
            section.Add(value);
        }

        private void Subtract(int value)
        {

        }


        public Illion(int value)
        {
            section = new Section(value);
        }
        public static implicit operator int(Illion illion) => illion.Value;
        public static implicit operator Illion(int v) => new Illion(v);
        public override string ToString()
        {
            return "Illion";
        }
    }
}