using System.Collections.Generic;
using System.Linq;

namespace ConsolePizza
{
    public class Employee
    {
        public Employee(long id, long boss)
        {
            this.Members = new List<long>();
            this.ID = id;
            this.Boss = boss;
        }

        public long ID { get; private set; }

        public long Boss { get; private set; }

        public List<long> Members { get; private set; }

        public void SetMembers(List<Employee> employees)
        {
            this.Members.Clear();
            foreach (Employee i in employees)
            {
                if (i.ID != this.ID)
                {
                    List<long> stackID = new();
                    Employee emp = i;
                    while (emp is not null && 0 < emp.Boss)
                    {
                        if (stackID.Contains(emp.ID)) break; // 無限ループ回避
                        stackID.Add(emp.ID);
                        if (emp.Boss == this.ID)
                        {
                            this.Members.Add(i.ID);
                            break;
                        }
                        else
                        {
                            emp = employees.FirstOrDefault(e => e.ID == emp.Boss);
                        }
                    }
                }
            }
        }
    }
}
