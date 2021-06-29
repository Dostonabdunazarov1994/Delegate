using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_3
{
    
    class Account
    {
        AccountHandler del;
        public void RegisterHandler(AccountHandler d)
        {
            del = d;
        }
        public string Name { get; set; }
        public double Sum { get; set; }
        public Account(string name)
        {
            Name = name;
        }
        public void Put(double sum)
        {
            Sum += sum;
            if (del != null)
                del($"На счет {Name} пришло: {sum}p {DateTime.Now}");
        }
        public void Withdraw(double sum)
        {
            if(del != null)
            {
                if (sum <= Sum)
                {
                    Sum -= sum;
                    del($"Со счета {Name} снято: {sum}p {DateTime.Now}");
                }
                else
                {
                    del($"На счете {Name} не достаточна средств! {DateTime.Now}");
                }
            }
        }
        public string Fullinfo()
        {
            return String.Format($"{Name}, баланс: {Sum}");
        }
    }
}
