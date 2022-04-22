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
        public static Dictionary<char, bool> Row(List<char> vars, int row)
        {
            if (vars.Count == 0) throw new Exception("Не указаны имена переменных");
            Dictionary<char, bool> result = new Dictionary<char, bool>();
            foreach (char c in vars)
                result.Add(c, false);
            if (vars.Count != 1)
            {
                if ((row < 0) || (row > vars.Count * vars.Count - 1)) throw new Exception("Не строки с указанным индексом не существует");
                
                int i = vars.Count - 1;
                while (row != 0)
                {
                    if (row % 2 == 0) result[vars[i]] = false;
                    else result[vars[i]] = true;
                    i--;
                    row /= 2;
                }
            }
            else
            {
                if ((row < 0) || (row > 1)) throw new Exception("Не строки с указанным индексом не существует");
                if (row == 1) result[vars[0]] = true;
            }
            return result;
        }
    }
}
