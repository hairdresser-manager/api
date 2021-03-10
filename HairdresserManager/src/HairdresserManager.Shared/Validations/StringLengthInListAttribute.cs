using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Validations
{
    public class StringLengthInListAttribute : ValidationAttribute
    {
        private static int _stringLength = 50;

        public StringLengthInListAttribute(int stringLength)
        {
            _stringLength = stringLength;
        }
        
        public override bool IsValid(object value)
        {
            var list = value as IList;

            if (list != null)
                foreach (var index in list)
                {
                    var stringIndex = index as string;

                    if (stringIndex.Length > _stringLength)
                    {
                        return false;
                    }
                }

            return true;
        }
    }
}