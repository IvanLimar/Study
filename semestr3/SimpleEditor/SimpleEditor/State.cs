using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEditor
{
    public class State
    {
        private List<List<Line>> previousStates;
        private List<List<Line>> canceledStates;

        public State()
        {
            previousStates = new List<List<Line>>();
            canceledStates = new List<List<Line>>();
        }

        public void UpdateState(List<Line> state)
        {
            previousStates.Add(state);
        }

        public List<Line> PreviousState(List<Line> currentState)
        {
            if (previousStates.Count != 0)
            {
                canceledStates.Add(currentState);
                List<Line> temp = previousStates[previousStates.Count - 1];
                previousStates.RemoveAt(previousStates.Count - 1);
                return temp;
            }
            return null;
        }

        public List<Line> CanceledState(List<Line> currentState)
        {
            if (canceledStates.Count != 0)
            {
                int index = canceledStates.Count - 1;
                previousStates.Add(currentState);
                List<Line> temp = canceledStates[index];
                canceledStates.RemoveAt(index);
                return temp;
            }
            return null;
        }
    }
}
