using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class Employee
    {
        private String fName;
        private String lName;
        private double hrRate;
        private double hrsWorked;
        private double earnings;
        private static readonly double FULLTIME = 40;
        private static readonly double OVERTIMERATE = 1.5;

        public Employee(String f, String l, double r, double hr)
        {
            fName = f;
            lName = l;
            hrRate = r;
            hrsWorked = hr;
            calculatePay();
        }

        public String getFirstName()
        {
            return fName;
        }

        public String getLastName()
        {
            return lName;
        }

        public double getPayRate()
        {
            return hrRate;
        }

        public double getHrsWorked()
        {
            return hrsWorked;
        }

        public double getEarnings()
        {
            return earnings;
        }

        private void calculatePay()
        {
            if (hrsWorked > FULLTIME)
            {
                double overtime = hrsWorked - FULLTIME;
                earnings = hrRate * FULLTIME + (overtime * hrRate * OVERTIMERATE);
            }
            else
                earnings = hrRate * hrsWorked;
        }
    }
}
