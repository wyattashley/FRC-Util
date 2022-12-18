using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace FRC_Utility_Software
{
    public class StepList
    {
        private List<StepContainer> steps = new List<StepContainer>();
        int length = 0;
        
        public StepList()
        {
            
        }

        public StepList(StepList list)
        {
            foreach(StepContainer step in list.getList())
            {
                steps.Add(step.copy());
            }
        }

        public void addStep(StepContainer step)
        {
            steps.Add(step);
            step.changePosition(steps.Count);
        }

        public void insertBeginningStep(StepContainer step)
        {
            steps.Insert(0, step);
            step.changePosition(steps.Count);
        }

        public void removeStep(int position)
        {
            steps.RemoveAt(position);
            reNumber();
        }

        public void flipStep(int pos1, int pos2)
        {
            StepContainer step = steps[pos1];
            steps[pos1] = steps[pos2];
            steps[pos2] = step;

            steps[pos1].changePosition(pos1);
            steps[pos2].changePosition(pos2);
        }

        public List<StepContainer> getList()
        {
            return steps;
        }

        public void forEachType(Dictionary<string, Func<StepContainer, bool>> methods, EventHandler eventHandler)
        {
            foreach(StepContainer step in steps)
            {
                string command = step.actionComboBox.Text.ToLower();
                if (methods.ContainsKey(command))
                {
                    if (methods[command].Invoke(step))
                        eventHandler.Invoke(this, new EventArgs());
                }
                else if (methods.ContainsKey("default"))
                {
                    if (methods["default"].Invoke(step))
                        eventHandler.Invoke(this, new EventArgs());
                }
            }
        }

        public StepContainer get(int position)
        {
            return steps[position];
        }

        public StepContainer getStepNumberInType(string command, int pos)
        {
            return getStepNumberInType(command, pos, false);
        }

        public StepContainer getStepNumberInType(string command, int pos, bool notCommand)
        {
            int occurance = -1;
            for (int i = 0; i < steps.Count(); i++)
            {
                if (notCommand ? !steps[i].actionComboBox.Text.ToLower().Equals(command) : steps[i].actionComboBox.Text.ToLower().Equals(command))
                {
                    occurance++;
                }

                if (occurance == pos)
                {
                    return steps[i];
                }
            }

            return steps[0];
        }

        public void removeStepNumberInWaypoints(int pos)
        {
            removeStepNumberInType(new string[] { "drive", "setposition" }, pos, false);
        }

        public void removeStepNumberInType(string[] commands, int pos, bool notCommand)
        {
            int occurance = -1;
            for (int i = 0; i < steps.Count(); i++)
            {
                foreach (string str in commands)
                {
                    if (notCommand ? !steps[i].actionComboBox.Text.ToLower().Equals(str) : steps[i].actionComboBox.Text.ToLower().Equals(str))
                    {
                        occurance++;
                    }
                }

                if (occurance == pos)
                {
                    removeStep(i);
                }
            }
        }

        public void addAllToControl(ControlCollection controlCollection)
        {
            controlCollection.Clear();
            foreach(StepContainer step in steps)
            {
                step.addToControl(controlCollection);
            }
        }

        public void clear()
        {
            steps.Clear();
            length = 0;
        }

        public void reNumber()
        {
            for (int i = 0; i < steps.Count(); i++)
            {
                steps[i].changePosition(i);
            }
        }

        public int getLength()
        {
            return steps.Count();
        }
    }
}
