using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCalculator
{
    public class LogicCalculator
    {
        private string postfix;
        public LogicCalculator(string problem, int type)
        {
            if(type == 2)
            {
                if (!LogicFormConv.OkPostfix(problem)) throw new Exception("Не корректный ввод");
                postfix = problem;
            }
            else
            {
                LogicFormConv lc = new LogicFormConv(problem, type);
                postfix = lc.Postfix;
            }
        }
        public bool Calculate(Dictionary<char, bool> values)
        {
            Stack<bool> st = new Stack<bool>();
            foreach (char c in postfix)
            {
                if (char.IsLetter(c)) st.Push(values[c]);
                else
                {
                    if(c != '¬')
                    {
                        bool op2 = st.Pop();
                        bool op1 = st.Pop();
                        switch(c)
                        {
                            
                            case '⋀':
                                st.Push(op1&op2);
                                break;
                            case '⋁':
                                st.Push(op1 || op2);
                                break;
                            case '⊕':
                                st.Push((op1 || op2) && (!op1 || !op2));
                                break;
                            case '→':
                                st.Push(!op1 || op2);
                                break;
                            case '↔':
                                st.Push(op1 == op2);
                                break;
                        }
                    }
                    else
                    {
                        st.Push(!st.Pop());
                    }
                }
            }
            return st.Peek();
        }
    }
}
