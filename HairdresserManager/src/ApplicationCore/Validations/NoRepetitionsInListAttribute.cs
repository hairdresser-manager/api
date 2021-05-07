using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Validations
{
    public class NoRepetitionsInListAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;

            if (list == null)
                return true;

            var tempList = new List<object>();

            foreach (var listObject in list)
            {
                if (tempList.Contains(listObject))
                    return false;

                tempList.Add(listObject);
            }

            return true;
        }
    }
}