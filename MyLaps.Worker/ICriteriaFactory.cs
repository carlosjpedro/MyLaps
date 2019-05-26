using System;
using System.Collections.Generic;
using System.Text;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    public interface ICriteriaFactory
    {
        Func<Runner, bool> GenerateNumericCriteria(int minValue, int maxValue);
        Func<Runner, bool> GenerateGenderCriteria(Gender gender);
    }
}
